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
    public partial class BreakingPointEditor : Form
    {
        public enum EMode {EDIT, NEW, UNKNOWN};
        EMode mode;
        public BreakingPoint breakingPoint;
        public BreakingPointEditor(EMode mod, BreakingPoint bp, List<Interface> interfaces)
        {
            InitializeComponent();
            breakingPoint = bp;
            foreach (EValidity val in Enum.GetValues(typeof(EValidity)))
            {
                cmbValidity.Items.Add(val.ToString());
            }
            mode = mod;
            tbName.Text = bp.Name;
            cmbValidity.SelectedItem = bp.Validity.ToString();
        }

        private void BreakingPointEditor_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            breakingPoint.Name = tbName.Text;
            breakingPoint.Validity = (EValidity)cmbValidity.SelectedIndex;

            if (mode == EMode.NEW)
            {
               // breakingPoint.ParentInterface.BreakingPoints.Add(breakingPoint);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
