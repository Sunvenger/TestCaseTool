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

namespace TestCaseTool2
{
    public partial class IntervalEditor : Form
    {
        public List<PointGroup> PointGroupList { get; set; }
        BreakingPoint bp1 = null;
        BreakingPoint bp2 = null;
        public PointGroup newPG { get; set; }
        public IntervalEditor(BreakingPoint breaking_point1, BreakingPoint breaking_point2, List<PointGroup> pg_list)
        {
            bp1 = breaking_point1;
            bp2 = breaking_point2;
            PointGroupList = pg_list;
            InitializeComponent();
            lbBPName1.Text = bp1.Name;
            lbBPName2.Text = bp2.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IntervalEditor_Load(object sender, EventArgs e)
        {


            // 7. Pre daný BreakingPoint v rôznych skupinách by nemalo byť možné vyberať 2-krát ten istý PointType.
            //Alebo inak povedané 
            // Zistiť v ktorých skupinách sa breakingPoint bp1 alebo bp2 nachádza
            // máme zoznam skupín ak sa v listoch bp akejkolvek skupiny daný bp nachádza, extrahovať a vytvoriť slovník<skupina, bp>
            //následne bude možné podla skupím zostrojit

            //je potrebné prejsť všerky bp v skupinách a vytvoriť dict<pg, bp>
            //


            //nasledne prejdeme všetky kluče pg ak sa v dicte vachádta hladaný bp, zistímme jeho Intervalove vlastnosti vytvoríme List<EIntervalPointType> a môžeme operovať
            // 8. V interval editore povoliť výber bodov typu EXCLUSIVE_INTERVAL len v skupinách, kde už existuje bod typu INCLUSIVE_INTERVAL.

            if (PointGroupList == null) PointGroupList = new List<PointGroup>();

            foreach (EIntervalPointType interfaceType in Enum.GetValues(typeof(EIntervalPointType)))
            {
                if (interfaceType == EIntervalPointType.EXCLUSIVE_INTERVAL || interfaceType == EIntervalPointType.INCLUSIVE_INTERVAL)
                    cmbBP1Incl.Items.Add(interfaceType);
            }
            cmbBP1Incl.SelectedIndex = 0;

            foreach (EIntervalPointType interfaceType in Enum.GetValues(typeof(EIntervalPointType)))
            {
                if (interfaceType == EIntervalPointType.EXCLUSIVE_INTERVAL || interfaceType == EIntervalPointType.INCLUSIVE_INTERVAL)
                    cmbBP2Incl.Items.Add(interfaceType);
            }
            


            List<EIntervalPointType> bp1TypeList = new List<EIntervalPointType>();
            List<EIntervalPointType> bp2TypeList = new List<EIntervalPointType>();




            foreach (PointGroup pg in PointGroupList)
            { 
                foreach(BreakingPoint bp in pg.BreakingPoints.Keys)
               {
                    if (bp == bp1)
                        cmbBP1Incl.Items.Remove(pg.BreakingPoints[bp]);
                    if (bp == bp2)
                        cmbBP2Incl.Items.Remove(pg.BreakingPoints[bp]);
                    

                }

            }
            cmbBP1Incl.SelectedIndex = 0;
            cmbBP2Incl.SelectedIndex = 0;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            newPG = new PointGroup();
            newPG.BreakingPoints = new Dictionary<BreakingPoint, EIntervalPointType>();
            newPG.BreakingPoints[bp1] = (EIntervalPointType)cmbBP1Incl.SelectedItem;
            newPG.BreakingPoints[bp2] = (EIntervalPointType)cmbBP2Incl.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}

