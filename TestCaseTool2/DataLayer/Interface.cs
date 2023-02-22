using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
namespace TestCaseTool2.DataLayer
{
    public enum EInterfaceType
    {
        INPUT,
        OUTPUT,
        CALIBRATION
    }

    public enum EValidity
    {
        V,
        I,
    }

    public enum EIntervalPointType
    {
        INCLUSIVE_INTERVAL,
        EXCLUSIVE_INTERVAL,
        DISCRETE_POINT
    }

    public class PointGroup
    {
        public int Id { get; set; }
        public Dictionary<BreakingPoint, EIntervalPointType> BreakingPoints { get; set; }
    }

    public class Interface
    {

        public string Name { get; set; }

        public string Comment { get; set; }

        public EInterfaceType Type { get; set; }

        public List<BreakingPoint> BreakingPoints { get; set; }


        public static string Serialize(List<Interface> interfaces)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(interfaces, settings);
        }

        public static List<Interface> Deserialize(string json)
        {
            var interfaces = JsonConvert.DeserializeObject<List<Interface>>(json);

            // Nastavenie referencii rodičovského objektu
            foreach (var intf in interfaces)
            {
                foreach (var bp in intf.BreakingPoints)
                {
                    bp.ParentInterface = intf;

                }
            }

            return interfaces;
        }

    }

    public class BreakingPoint
    {
        [DataMemberAttribute]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataMemberAttribute]
        public EValidity Validity { get; set; }

        public Interface ParentInterface { get; set; }

        public BreakingPoint(string name, EValidity validity, Interface parentInterface)
        {
            Name = name;
            Validity = validity;
            ParentInterface = parentInterface;
        }
    }

    public class EquivalenceClass
    {
        public string Name { get; set; }
        public List<EquivalenceClassColumn> Columns { get; set; }
        public List<EquivalenceClassColumn> UnsortedColumns { get; set; }
        public List<Interface> Interfaces { get; set; }
        public EquivalenceClass(List<Interface> interfaces, List<PointGroup> pointGroupList)
        {
            Interfaces = interfaces;
            Name = "Equivalence Class";
            Columns = new List<EquivalenceClassColumn>();
            UnsortedColumns = new List<EquivalenceClassColumn>();
            foreach (Interface intf in interfaces)
            {
                EquivalenceClassColumn column = new EquivalenceClassColumn(intf, pointGroupList);
                UnsortedColumns.Add(column);
            }

            foreach (EquivalenceClassColumn col in UnsortedColumns)
            {
                if (col.Validity == EValidity.V)
                    Columns.Add(col);
            }

            foreach (EquivalenceClassColumn col in UnsortedColumns)
            {
                if (col.Validity == EValidity.I)
                    Columns.Add(col);
            }
        }


        public int GetMaxValidCount()
        {
            int maxValidCount = 0;
            foreach (EquivalenceClassColumn column in Columns)
            {
                int validCount = column.ValidValues.Count;
                if (validCount > maxValidCount)
                {
                    maxValidCount = validCount;
                }
            }
            return maxValidCount;
        }

        public int GetMaxInvalidCount()
        {
            int maxInvalidCount = 0;
            foreach (EquivalenceClassColumn column in Columns)
            {
                int invalidCount = column.InvalidValues.Count;
                if (invalidCount > maxInvalidCount)
                {
                    maxInvalidCount = invalidCount;
                }
            }
            return maxInvalidCount;
        }
    }

    public class EquivalenceClassColumn
    {
        enum E_IntervalStateMachine { FIRST_INTERVAL_POINT, LAST_INTERVAL_POINT };
        public Interface Interface { get; set; }
        public List<string> ValidValues { get; set; }
        public List<string> InvalidValues { get; set; }
        public EValidity Validity { get; set; }

        public EquivalenceClassColumn(Interface intf, List<PointGroup> pointGroupList)
        {
            E_IntervalStateMachine interval_state_machine;

            Interface = intf;
            ValidValues = new List<string>();
            InvalidValues = new List<string>();
            // Dôležitá poznámka, EPointType by mal byť vlastnostou skupiny a nie BreakingPointov pretože pre jednu skupinu môžu byť INCLUSIVE_INTERVAL a pre inú EXCLUSIVE_INTERVAL :)
            // Implementovať bod ktorý patrí do viacerých intervalov(BreakingPoint musí obsahovať viacero referencii na PointGroup)

            // napríklad pre prípad [ERR0, L[| [L, H] | ]H, ERR1]. validitu intervalu je potom možné vyhodnotiť tak, že ak akspoň jeden z bodov je invalid, Valid potom musí byť EXCLUDE
            // vtedy by sa logika inklúzie pri vytvárani intervalu v IntervalEditor mala automaticky prepínať aby sa interval obsahujúci valid a invalid zlomové body nemohli krížiť.
            // Validita intervalu sa teda bude riadiť logikou ak aspoňjeden z bodov ktorý je Valid a je typu INCLUSIVE_INTERVAL, potom druhý pokial je valid musí byť typu EXCLUSIVE_INTERVAL
            // Výsledkom bude invalid interval zobrazený v invalid stĺpci EQ tabulky a platí to aj pre validný INCLUSIVE_INTERVAL
            // PointGroup s BreakingPoint-ami typu DISCRETE_POINT nesmie obsahovať valid aj invalid BreakingPoint-y


            // TODO:
            // 1. Presunúť pointType z BreakingPoint do PointGroup.
            // 2. Implementovať možnosť priradenia bodu do viacerých skupín intervalov.
            // 3. Pre implementáciu bodu č. 2, je nutné upraviť logiku vytvárania intervalov tak, aby bolo možné správne vyhodnotiť validitu intervalov, ktoré obsahujú bod patiaci do viacerých skupín. Platí to aj pre typ intervalu INCLUSIVE_INTERVAL, kde pre druhú skupinu musí byť tento bod EXCLUSIVE_INTERVAL.
            // 4. Pri vytváraní EQ tabuľky, pri zobrazovaní intervalov, sa bude brať do úvahy PointType z PointGroup a nie z BreakingPoint.
            // 5. Implementovať správnu redukciu stĺpcov EQ tabuľky.
            // 6. Opraviť algoritmus na získanie hodnôt pre stĺpce EQ tabuľky tak, aby výstup bol správny. Pri tomto bude nutné zohľadniť body patriace do viacerých skupín intervalov.
            // 7. Pre daný BreakingPoint v rôznych skupinách by nemalo byť možné vyberať 2-krát ten istý PointType.
            // 8. V interval editore povoliť výber bodov typu EXCLUSIVE_INTERVAL len v skupinách, kde už existuje bod typu INCLUSIVE_INTERVAL.


            interval_state_machine = E_IntervalStateMachine.FIRST_INTERVAL_POINT;
            List<BreakingPoint> isObservedList = new List<BreakingPoint>(); // slúži na to aby body, ktoré niesú zahrnuté v skupine/intervale už neboli zobrazované ako samostatné stĺpce
            //Avšak treba zvážiť Či body patriace do intervalu EXCLUSIVE_INTERVAL
            if (pointGroupList == null) pointGroupList = new List<PointGroup>();//group list not initialized yet

            //get point group list to work with
            List<PointGroup> pointGroupsToWorkWith = new List<PointGroup>();
            foreach (BreakingPoint bp in intf.BreakingPoints)
            {
                var groups = from p_gs in pointGroupList where p_gs.BreakingPoints.ContainsKey(bp)select p_gs;
                foreach (PointGroup pg in groups)
                {
                    if (!pointGroupsToWorkWith.Contains(pg))
                    {
                        pointGroupsToWorkWith.Add(pg);
                    }
                }
                

            }
            




            foreach (PointGroup pg in pointGroupsToWorkWith)
            {
                string Text = "";
                int IntervalCursor = 0;

                foreach (BreakingPoint bp in pg.BreakingPoints.Keys)
                {
                    if (pg.BreakingPoints[bp] == EIntervalPointType.INCLUSIVE_INTERVAL)
                    {
                        if (IntervalCursor == 0)
                        {
                            Text = $"[{bp.Name}, ";
                            isObservedList.Add(bp);
                            IntervalCursor++;
                        }
                        else if (IntervalCursor == 1)
                        {
                            Text += $"{bp.Name}]";
                            isObservedList.Add(bp);

                            IntervalCursor = 0;

                            if (bp.Validity == EValidity.V)
                            {
                                Validity = EValidity.V;
                                ValidValues.Add(Text);
                            }
                            if (bp.Validity == EValidity.I)
                            {
                                Validity = EValidity.I;
                                InvalidValues.Add(Text);
                            }
                        }

                    }

                    if (pg.BreakingPoints[bp] == EIntervalPointType.EXCLUSIVE_INTERVAL)
                    {
                        if (IntervalCursor == 0)
                        {
                            Text = $"]{bp.Name}, ";
                            isObservedList.Add(bp);
                            IntervalCursor++;
                        }
                        else if (IntervalCursor == 1)
                        {
                            Text += $"{bp.Name}[";
                            isObservedList.Add(bp);
                            IntervalCursor = 0;

                            if (bp.Validity == EValidity.V)
                            {
                                Validity = EValidity.V;
                                ValidValues.Add(Text);
                            }
                            if (bp.Validity == EValidity.I)
                            {
                                Validity = EValidity.I;
                                InvalidValues.Add(Text);
                            }

                        }

                    }
                }



            }
            foreach (BreakingPoint bp in intf.BreakingPoints)
            {
                if (bp.Validity == EValidity.V && !isObservedList.Contains(bp))
                {

                    ValidValues.Add(bp.Name);
                }

                if (bp.Validity == EValidity.I && !isObservedList.Contains(bp))
                {

                    InvalidValues.Add(bp.Name);
                }
            }
        }
    }

}
