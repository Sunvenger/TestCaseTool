
namespace TestCaseTool2
{
    partial class IntervalEditor
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
            this.cmbBP1Incl = new System.Windows.Forms.ComboBox();
            this.cmbBP2Incl = new System.Windows.Forms.ComboBox();
            this.lbBPName1 = new System.Windows.Forms.Label();
            this.lbBPName2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBP1Incl
            // 
            this.cmbBP1Incl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBP1Incl.FormattingEnabled = true;
            this.cmbBP1Incl.Location = new System.Drawing.Point(456, 30);
            this.cmbBP1Incl.Name = "cmbBP1Incl";
            this.cmbBP1Incl.Size = new System.Drawing.Size(296, 28);
            this.cmbBP1Incl.TabIndex = 0;
            // 
            // cmbBP2Incl
            // 
            this.cmbBP2Incl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBP2Incl.FormattingEnabled = true;
            this.cmbBP2Incl.Location = new System.Drawing.Point(456, 64);
            this.cmbBP2Incl.Name = "cmbBP2Incl";
            this.cmbBP2Incl.Size = new System.Drawing.Size(296, 28);
            this.cmbBP2Incl.TabIndex = 1;
            // 
            // lbBPName1
            // 
            this.lbBPName1.AutoSize = true;
            this.lbBPName1.Location = new System.Drawing.Point(213, 37);
            this.lbBPName1.Name = "lbBPName1";
            this.lbBPName1.Size = new System.Drawing.Size(60, 20);
            this.lbBPName1.TabIndex = 2;
            this.lbBPName1.Text = "Name1";
            this.lbBPName1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbBPName2
            // 
            this.lbBPName2.AutoSize = true;
            this.lbBPName2.Location = new System.Drawing.Point(213, 67);
            this.lbBPName2.Name = "lbBPName2";
            this.lbBPName2.Size = new System.Drawing.Size(60, 20);
            this.lbBPName2.TabIndex = 3;
            this.lbBPName2.Text = "Name2";
            this.lbBPName2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Low boundary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "High boundary";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(619, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(133, 54);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(49, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 54);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // IntervalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(809, 209);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbBPName2);
            this.Controls.Add(this.lbBPName1);
            this.Controls.Add(this.cmbBP2Incl);
            this.Controls.Add(this.cmbBP1Incl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IntervalEditor";
            this.Text = "IntervalEditor";
            this.Load += new System.EventHandler(this.IntervalEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBP1Incl;
        private System.Windows.Forms.ComboBox cmbBP2Incl;
        private System.Windows.Forms.Label lbBPName1;
        private System.Windows.Forms.Label lbBPName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}