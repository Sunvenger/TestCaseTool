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
    public partial class InterfaceEditor : Form
    {
        public Interface newInterface;
        public enum EMode { EDIT, NEW, UNKNOWN };
        public EMode mode;
        public InterfaceEditor(Interface editInterface = null, EMode mod = EMode.UNKNOWN)
        {
            InitializeComponent();
            mode = mod;
            newInterface = editInterface;
            if (mode == EMode.EDIT)
            {
                cmbInterfaceType.SelectedItem = editInterface.Type;
                tbInterfaceName.Text = editInterface.Name;
            }
        }

        private void InterfaceEditor_Load(object sender, EventArgs e)
        {
            foreach (EInterfaceType interfaceType in Enum.GetValues(typeof(EInterfaceType)))
            {
                cmbInterfaceType.Items.Add(interfaceType);
            }
            cmbInterfaceType.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbInterfaceName.Text))
            {
                MessageBox.Show("Please enter interface name");
                return;
            }

            if (newInterface == null)
            {
                if (mode == EMode.NEW)
                {
                    var newInterface = new Interface
                    {
                        Name = tbInterfaceName.Text,
                        Type = (EInterfaceType)cmbInterfaceType.SelectedItem,
                        BreakingPoints = new List<BreakingPoint>()
                    };
                }
            }
            else
            {
                if (mode == EMode.EDIT)
                {
                    newInterface.Name = tbInterfaceName.Text;
                    newInterface.Type = (EInterfaceType)cmbInterfaceType.SelectedItem;
                }
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
