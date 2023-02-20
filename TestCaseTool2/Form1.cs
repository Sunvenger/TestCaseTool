using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCaseTool2.DataLayer;
using TestCaseTool2.ViewLayer;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace TestCaseTool2
{

    public partial class TestToolkitMain : Form
    {
        public List<Interface> interfaces;
        public List<PointGroup> point_groups;
        private Dictionary<Interface, bool> TreeInterfaceStates;
        public TestToolkitMain()
        {
            InitializeComponent();
            TreeInterfaceStates = new Dictionary<Interface, bool>();
        }

        private void AddBreakingPointToInterface(Interface interfaceObject)
        {
            // Vytvor nový BreakingPointEditor s modom New a prázdymi dátami
            var newBreakingPoint = new BreakingPoint("Value", EValidity.I, interfaceObject);

            var editor = new BreakingPointEditor(BreakingPointEditor.EMode.NEW, newBreakingPoint, interfaces);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                interfaceObject.BreakingPoints.Add(editor.breakingPoint);
                PopulateTreeView();
            }
        }
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

        public static bool SaveToFile(List<Interface> interfaces)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files|*.json";
            saveFileDialog.Title = "Save Interfaces";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = Serialize(interfaces);
                    File.WriteAllText(saveFileDialog.FileName, json);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message);
                }
            }
            return false;
        }
        public static List<Interface> LoadFromFile()
        {
            List<Interface> interfaces = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    interfaces = Deserialize(json);
                }
            }
            return interfaces;
        }
        public void EditInterface(Interface interfaceObject)
        {

            using (var interfaceEditor = new InterfaceEditor(interfaceObject, InterfaceEditor.EMode.EDIT))
            {
                var result = interfaceEditor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // pridaj novy interface do zoznamu
                    var newInterface = interfaceEditor.newInterface;

                    // zobraz novy interface v TreeView a oznac ho
                    PopulateTreeView();
                    SelectNodeByTag(InterfaceTreeView, newInterface);
                }
            }
        }
        public void DeleteInterface(Interface interfaceObject)
        {


            DialogResult result = MessageBox.Show("Do you really want to delete the interface?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                interfaces.Remove(interfaceObject);
                PopulateTreeView();
            }
            else
            {
                // User clicked No or closed the dialog, do nothing
            }
        }
        private void EditBreakingPoint(BreakingPoint breakingPoint)
        {
            var editor = new BreakingPointEditor(BreakingPointEditor.EMode.EDIT, breakingPoint, interfaces);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                var parentInterface = breakingPoint.ParentInterface;
                var breakingPointIndex = parentInterface.BreakingPoints.IndexOf(breakingPoint);
                parentInterface.BreakingPoints[breakingPointIndex] = editor.breakingPoint;
                PopulateTreeView();
            }
        }

        public void DeleteBreakingPoint(BreakingPoint breakingPoint)
        {
            var parentInterface = breakingPoint.ParentInterface;
            DialogResult result = MessageBox.Show("Do you really want to delete the breaking point?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                parentInterface.BreakingPoints.Remove(breakingPoint);
                PopulateTreeView();
            }
            else
            {
                // User clicked No or closed the dialog, do nothing
            }
        }

        public void DefineInterval(List<BreakingPoint> breakingPoints)
        {
            var ie = new IntervalEditor(breakingPoints[0], breakingPoints[1]);
            DialogResult = ie.ShowDialog();
            if(DialogResult == DialogResult.OK)
            {
                var new_pg = new PointGroup();

                int uniqueId = 1;

                if (point_groups == null)
                    point_groups = new List<PointGroup>();
                while ((from p_g in point_groups select p_g.Id).Contains(uniqueId))
                    uniqueId++;

                new_pg.Id = uniqueId;
                new_pg.BreakingPoints = new List<BreakingPoint>();

                new_pg.BreakingPoints.Add(breakingPoints[0]);
                new_pg.BreakingPoints.Add(breakingPoints[0]);
                point_groups.Add(new_pg);
                breakingPoints[0].pointGroupId = new_pg.Id;
                breakingPoints[1].pointGroupId = new_pg.Id;

                breakingPoints[0].PointGroup = new_pg;
                breakingPoints[1].PointGroup = new_pg;
            }
        }
        private void CreateGroup(List<BreakingPoint> breakingPoints)
        {
            DialogResult result = MessageBox.Show("Do you want to create a new group with selected breaking points?", "Create Group", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PointGroup pointGroup = new PointGroup();
                pointGroup.Id = point_groups.Max(pg => pg.Id) + 1;
                foreach (BreakingPoint bp in breakingPoints)
                {
                    bp.PointGroup = pointGroup;
                    bp.pointGroupId = pointGroup.Id;
                }
                point_groups.Add(pointGroup);
            }
        }
        public void PopulateTreeView()
        {
            InterfaceTreeView.Nodes.Clear();
            foreach (var inter in interfaces)
            {
                var interNode = new TreeNode(inter.Name + " (" + inter.Type + ")");

                // Set color based on interface type
                if (inter.Type == EInterfaceType.INPUT)
                {
                    interNode.ForeColor = Color.Orange;
                }
                else if (inter.Type == EInterfaceType.OUTPUT)
                {
                    interNode.ForeColor = Color.Blue;
                }

                interNode.Tag = inter;
                foreach (var bp in inter.BreakingPoints)
                {
                    var bpNode = new TreeNode(bp.Name + " (" + bp.Validity + ")");
                    bpNode.Tag = bp;

                    // Set color based on breaking point validity
                    if (bp.Validity == EValidity.V)
                    {
                        bpNode.ForeColor = Color.Green;
                    }
                    else if (bp.Validity == EValidity.I)
                    {
                        bpNode.ForeColor = Color.Red;
                    }

                    interNode.Nodes.Add(bpNode);
                }
                if (TreeInterfaceStates.ContainsKey(interNode.Tag as Interface))
                {
                    if (TreeInterfaceStates[interNode.Tag as Interface] == true) interNode.Expand();
                    else interNode.Collapse();
                }

                InterfaceTreeView.Nodes.Add(interNode);
            }
        }


        private void TestToolkitMain_Load(object sender, EventArgs e)
        {
            interfaces = new List<Interface>();
            for (int i = 0; i < 5; i++)
            {
                var newInterface = new Interface
                {
                    Name = $"tst_out - {i}",
                    Type = EInterfaceType.INPUT,
                    BreakingPoints = new List<BreakingPoint>()
                };

                newInterface.BreakingPoints.Add(new BreakingPoint("L", EValidity.V, newInterface));
                newInterface.BreakingPoints.Add(new BreakingPoint("H", EValidity.V, newInterface));
                newInterface.BreakingPoints.Add(new BreakingPoint("Err", EValidity.I, newInterface));

                interfaces.Add(newInterface);
            }
            PopulateTreeView();
        }


        private void ShowInterfaceContextMenu(TreeNode node, Point position)
        {
            if (node.Tag is Interface interfaceObject)
            {
                Interface inter = node.Tag as Interface;
                ContextMenuStrip interfaceMenuStrip = new ContextMenuStrip();
                if (inter.Type == EInterfaceType.INPUT || inter.Type == EInterfaceType.CALIBRATION)
                {

                    interfaceMenuStrip.Items.Add("Add Breaking Point", null, (s, e) => { AddBreakingPointToInterface(interfaceObject); });
                }
                interfaceMenuStrip.Items.Add("Edit Interface", null, (s, e) => { EditInterface(interfaceObject); });
                interfaceMenuStrip.Items.Add("Delete Interface", null, (s, e) => { DeleteInterface(interfaceObject); });
                interfaceMenuStrip.Show(InterfaceTreeView, position);



            }
        }

        private void ShowBreakingPointContextMenu(TreeNode node, Point position)
        {
            if (node.Tag is BreakingPoint breakingPointObject)
            {
                ContextMenuStrip breakingPointMenuStrip = new ContextMenuStrip();
                breakingPointMenuStrip.Items.Add("Edit Breaking Point", null, (s, e) => { EditBreakingPoint(breakingPointObject); });
                breakingPointMenuStrip.Items.Add("Delete Breaking Point", null, (s, e) => { DeleteBreakingPoint(breakingPointObject); });
                breakingPointMenuStrip.Show(InterfaceTreeView, position);

                TreeNodeCollection nodes = node.Parent.Nodes;
                List<TreeNode> selectedNodes = new List<TreeNode>();
                List<BreakingPoint> selectedBp = new List<BreakingPoint>();
                foreach (TreeNode n in nodes)
                {
                    if (n.Checked)
                    {
                        selectedNodes.Add(n);
                    }
                }

                if (selectedNodes.Count == 2)
                {
                    selectedBp = (from s_n in selectedNodes select s_n.Tag as BreakingPoint).ToList();
                    breakingPointMenuStrip.Items.Add("Define interval", null, (s, e) => { DefineInterval(selectedBp); });
                }

                if (selectedNodes.Count >= 2)
                {
                    selectedBp = (from s_n in selectedNodes select s_n.Tag as BreakingPoint).ToList();
                    breakingPointMenuStrip.Items.Add("Create group", null, (s, e) => { CreateGroup(selectedBp); });
                }
            }
        }


        private void InterfaceTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Tag != null)
                {
                    if (e.Node.Tag is Interface)
                    {
                        ShowInterfaceContextMenu(e.Node, e.Location);
                    }
                    else if (e.Node.Tag is BreakingPoint)
                    {
                        ShowBreakingPointContextMenu(e.Node, e.Location);
                    }
                }
            }
        }

        private void InterfaceTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Interface interfaceObject)
            {
                TreeInterfaceStates[interfaceObject] = false;
            }
        }

        private void InterfaceTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Interface interfaceObject)
            {
                TreeInterfaceStates[interfaceObject] = true;
            }
        }
        public static TreeNode SelectNodeByTag(TreeView treeView, object tag)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode foundNode = FindNodeByTag(node, tag);
                if (foundNode != null)
                {
                    treeView.SelectedNode = foundNode;
                    return foundNode;
                }
            }
            return null;
        }

        private static TreeNode FindNodeByTag(TreeNode node, object tag)
        {
            if (node.Tag == tag)
            {
                return node;
            }
            else if (node.Tag is Interface)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    TreeNode foundNode = FindNodeByTag(childNode, tag);
                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }
            }
            else if (node.Tag is BreakingPoint)
            {
                foreach (TreeNode childNode in node.Parent.Nodes)
                {
                    if (childNode.Tag == tag)
                    {
                        return childNode;
                    }
                }
            }
            return null;
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            // zistíme, ktorý prvok je označený a či je to BreakingPoint alebo Interface
            var selectedTag = InterfaceTreeView.SelectedNode?.Tag;
            if (selectedTag is null) return;

            if (selectedTag is BreakingPoint selectedBreakingPoint)
            {
                // nájdeme rodiča označeného prvku (interface)
                var parentInterface = InterfaceTreeView.SelectedNode?.Parent?.Tag as Interface;
                if (parentInterface is null) return;

                // nájdeme index označeného prvku
                var selectedIndex = parentInterface.BreakingPoints.IndexOf(selectedBreakingPoint);
                if (selectedIndex == -1) return;

                // ak je prvý, tak nemôžeme posunúť hore
                if (selectedIndex == 0) return;

                // vymeníme prvok s tým nad ním
                parentInterface.BreakingPoints[selectedIndex] = parentInterface.BreakingPoints[selectedIndex - 1];
                parentInterface.BreakingPoints[selectedIndex - 1] = selectedBreakingPoint;

                // zrekonštruujeme TreeView
                InterfaceTreeView.BeginUpdate();
                PopulateTreeView();
                InterfaceTreeView.EndUpdate();

                // označíme prvok podľa jeho tagu
                SelectNodeByTag(InterfaceTreeView, selectedTag);
            }
            else if (selectedTag is Interface selectedInterface)
            {
                // nájdeme index označeného interfacu
                var selectedIndex = interfaces.IndexOf(selectedInterface);
                if (selectedIndex == -1) return;

                // ak je prvý, tak nemôžeme posunúť hore
                if (selectedIndex == 0) return;

                // vymeníme prvok s tým nad ním
                interfaces[selectedIndex] = interfaces[selectedIndex - 1];
                interfaces[selectedIndex - 1] = selectedInterface;

                // zrekonštruujeme TreeView
                InterfaceTreeView.BeginUpdate();
                PopulateTreeView();
                InterfaceTreeView.EndUpdate();

                // označíme prvok podľa jeho tagu
                SelectNodeByTag(InterfaceTreeView, selectedTag);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (InterfaceTreeView.SelectedNode == null || InterfaceTreeView.Nodes.Count == 0)
            {
                return;
            }

            // Ziskame aktualne oznaceny TreeNode a jeho tag
            var selectedNode = InterfaceTreeView.SelectedNode;
            var selectedTag = selectedNode.Tag;

            // Ak je tag typu Interface, menime poradie v zozname interfaces
            if (selectedTag is Interface selectedInterface)
            {
                var index = interfaces.IndexOf(selectedInterface);

                // Nemozeme posunut nizsie posledny Interface v zozname
                if (index == interfaces.Count - 1)
                {
                    return;
                }

                interfaces.RemoveAt(index);
                interfaces.Insert(index + 1, selectedInterface);
            }
            // Ak je tag typu BreakingPoint, menime poradie vo vnútri jeho rodičovského interface
            else if (selectedTag is BreakingPoint selectedBreakingPoint)
            {
                // Najdeme rodiča BreakingPointu (t.j. jeho interface) a jeho zoznam breaking points
                var parentInterface = (Interface)selectedNode.Parent.Tag;
                var breakingPoints = parentInterface.BreakingPoints;
                var index = breakingPoints.IndexOf(selectedBreakingPoint);

                // Nemozeme posunut nizsie posledny BreakingPoint v zozname
                if (index == breakingPoints.Count - 1)
                {
                    return;
                }

                breakingPoints.RemoveAt(index);
                breakingPoints.Insert(index + 1, selectedBreakingPoint);
            }

            // Znovu vygenerujeme strom
            PopulateTreeView();

            // Najdeme v strome uzol s tagom selectedTag a oznacime ho
            SelectNodeByTag(InterfaceTreeView, selectedTag);
        }

        private void btnAddInterface_Click(object sender, EventArgs e)
        {
            using (var interfaceEditor = new InterfaceEditor(null, InterfaceEditor.EMode.NEW))
            {

                var result = interfaceEditor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // pridaj novy interface do zoznamu
                    var newInterface = interfaceEditor.newInterface;

                    interfaces.Add(newInterface);

                    // zobraz novy interface v TreeView a oznac ho
                    PopulateTreeView();
                    SelectNodeByTag(InterfaceTreeView, newInterface);
                }
            }
        }

        private void btnClbImport_Click(object sender, EventArgs e)
        {
            // Vymažeme existujúce interfac-y z globálneho zoznamu
            if (interfaces != null)
            {
                interfaces.Clear();
            }
            else
                interfaces = new List<Interface>();
            // Skopírovaný obsah uložíme do premenného typu string z clipboardu
            string clipboardText = Clipboard.GetText();

            // Rozdelíme text na riadky
            string[] lines = clipboardText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Prvý riadok obsahuje názvy stĺpcov, preskočíme ho
            if (lines.Length < 2)
            {
                MessageBox.Show("Invalid table data. Ensure that Interface table has correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                // Rozdelíme riadok na stĺpce pomocou tabulátoru
                if (lines[i] == "") break;
                string[] columns = lines[i].Split('\t');

                string[] headerColumns = lines[0].Split('\t');
                if (headerColumns.Length != 3)
                {
                    MessageBox.Show("Invalid table header. Ensure that Interface table has correct format");
                    return;
                }
                // Vytvoríme nový Interface objekt s informáciami zo stĺpcov
                EInterfaceType t = EInterfaceType.INPUT;
                switch (columns[1].ToLower())
                {
                    case "input":
                        t = EInterfaceType.INPUT;
                        break;
                    case "output":
                        t = EInterfaceType.OUTPUT;
                        break;
                    case "calibration":
                        t = EInterfaceType.CALIBRATION;
                        break;
                }
                Interface newInterface = new Interface

                {
                    Name = columns[0],
                    Type = t,
                    Comment = columns[2]

                };

                // Pridáme nový Interface objekt do globálneho zoznamu
                newInterface.BreakingPoints = new List<BreakingPoint>();
                interfaces.Add(newInterface);
            }

            // Aktualizujeme zobrazenie stromu
            PopulateTreeView();
        }
        public void ShowEquivalenceClassTable(EquivalenceClass eqClass, DataGridView gv)
        {
            gv.Rows.Clear();
            gv.Columns.Clear();

            // Add Name column
            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                ReadOnly = true
            };
            gv.Columns.Add(nameColumn);

            // Add Valid columns
            int maxValidCount = eqClass.GetMaxValidCount();
            for (int i = 1; i <= maxValidCount; i++)
            {
                DataGridViewColumn validColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = $"V{i}",
                    DataPropertyName = $"Valid{i}",
                    ReadOnly = true
                };
                gv.Columns.Add(validColumn);
            }

            // Add Invalid columns
            int maxInvalidCount = eqClass.GetMaxInvalidCount();
            for (int i = 1; i <= maxInvalidCount; i++)
            {
                DataGridViewColumn invalidColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = $"I{i}",
                    DataPropertyName = $"Invalid{i}",
                    ReadOnly = true
                };
                gv.Columns.Add(invalidColumn);
            }

            // Add rows
            foreach (EquivalenceClassColumn column in eqClass.Columns)
            {
                int rowIndex = gv.Rows.Add();
                gv.Rows[rowIndex].Cells["Name"].Value = column.Interface.Name;

                for (int i = 0; i < column.ValidValues.Count; i++)
                {
                    gv.Rows[rowIndex].Cells[$"Valid{i + 1}"].Value = column.ValidValues[i];
                }

                for (int i = 0; i < column.InvalidValues.Count; i++)
                {
                    gv.Rows[rowIndex].Cells[$"Invalid{i + 1}"].Value = column.InvalidValues[i];
                }
            }
        }

        private DataTable ConvertToDataTable(string[,] tableData, string[] columnNames)
        {
            DataTable dt = new DataTable();

            // Pridáme stĺpce do tabuľky
            for (int i = 0; i < columnNames.Length; i++)
            {
                dt.Columns.Add(columnNames[i]);
            }

            // Pridáme riadky do tabuľky
            for (int i = 0; i < tableData.GetLength(0); i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < tableData.GetLength(1); j++)
                {
                    row[j] = tableData[i, j];
                }
                dt.Rows.Add(row);
            }

            return dt;
        }


        private void btnGenerateEq_Click(object sender, EventArgs e)
        {
            List<Interface> filteredInterfaces = interfaces.Where(i => i.Type == EInterfaceType.INPUT || i.Type == EInterfaceType.CALIBRATION).ToList();
            EquivalenceClass eq = new EquivalenceClass(filteredInterfaces, point_groups);
            EQTableView eqv = new EQTableView(eq, point_groups);
            DataTable dt = ConvertToDataTable(eqv.TableData, eqv.ColumnNames);
            EQTableGrid.DataSource = dt;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToFile(interfaces);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            interfaces = LoadFromFile();
            PopulateTreeView();
        }
    }

}
