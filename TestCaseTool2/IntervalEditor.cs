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
        BreakingPoint bp1 = null;
        BreakingPoint bp2 = null;
        public IntervalEditor(BreakingPoint breaking_point1, BreakingPoint breaking_point2)
        {
            bp1 = breaking_point1;
            bp2 = breaking_point2;
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

            foreach (EPointType interfaceType in Enum.GetValues(typeof(EPointType)))
            {
                if( interfaceType == EPointType.EXCLUSIVE_INTERVAL || interfaceType == EPointType.INCLUSIVE_INTERVAL)
                cmbBP1Incl.Items.Add(interfaceType);
            }
            cmbBP1Incl.SelectedIndex = 0;

            foreach (EPointType interfaceType in Enum.GetValues(typeof(EPointType)))
            {
                if (interfaceType == EPointType.EXCLUSIVE_INTERVAL || interfaceType == EPointType.INCLUSIVE_INTERVAL)
                    cmbBP2Incl.Items.Add(interfaceType);
            }
            cmbBP2Incl.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bp1.PointType = (EPointType)cmbBP1Incl.SelectedItem;
            bp2.PointType = (EPointType)cmbBP2Incl.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
