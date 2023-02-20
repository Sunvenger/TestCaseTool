
namespace TestCaseTool2
{
    partial class InterfaceEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInterfaceName = new System.Windows.Forms.TextBox();
            this.cmbInterfaceType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // tbInterfaceName
            // 
            this.tbInterfaceName.Location = new System.Drawing.Point(142, 33);
            this.tbInterfaceName.Name = "tbInterfaceName";
            this.tbInterfaceName.Size = new System.Drawing.Size(162, 26);
            this.tbInterfaceName.TabIndex = 2;
            // 
            // cmbInterfaceType
            // 
            this.cmbInterfaceType.FormattingEnabled = true;
            this.cmbInterfaceType.Location = new System.Drawing.Point(143, 98);
            this.cmbInterfaceType.Name = "cmbInterfaceType";
            this.cmbInterfaceType.Size = new System.Drawing.Size(160, 28);
            this.cmbInterfaceType.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(229, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(132, 46);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InterfaceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 243);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbInterfaceType);
            this.Controls.Add(this.tbInterfaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InterfaceEditor";
            this.Text = "InterfaceEditor";
            this.Load += new System.EventHandler(this.InterfaceEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInterfaceName;
        private System.Windows.Forms.ComboBox cmbInterfaceType;
        private System.Windows.Forms.Button btnOk;
    }
}