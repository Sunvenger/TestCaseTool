
namespace TestCaseTool2
{
    partial class TestToolkitMain
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
            this.InterfaceTab = new System.Windows.Forms.TabControl();
            this.TreeviewTest = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClbImport = new System.Windows.Forms.Button();
            this.btnAddInterface = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.InterfaceTreeView = new System.Windows.Forms.TreeView();
            this.EQClassGeneratorTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateEq = new System.Windows.Forms.Button();
            this.EQTableGrid = new System.Windows.Forms.DataGridView();
            this.InterfaceTab.SuspendLayout();
            this.TreeviewTest.SuspendLayout();
            this.EQClassGeneratorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EQTableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // InterfaceTab
            // 
            this.InterfaceTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterfaceTab.Controls.Add(this.TreeviewTest);
            this.InterfaceTab.Controls.Add(this.EQClassGeneratorTab);
            this.InterfaceTab.Location = new System.Drawing.Point(8, 8);
            this.InterfaceTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InterfaceTab.Name = "InterfaceTab";
            this.InterfaceTab.SelectedIndex = 0;
            this.InterfaceTab.Size = new System.Drawing.Size(782, 470);
            this.InterfaceTab.TabIndex = 0;
            // 
            // TreeviewTest
            // 
            this.TreeviewTest.BackColor = System.Drawing.Color.CadetBlue;
            this.TreeviewTest.Controls.Add(this.label1);
            this.TreeviewTest.Controls.Add(this.btnLoad);
            this.TreeviewTest.Controls.Add(this.btnSave);
            this.TreeviewTest.Controls.Add(this.btnClbImport);
            this.TreeviewTest.Controls.Add(this.btnAddInterface);
            this.TreeviewTest.Controls.Add(this.btnDown);
            this.TreeviewTest.Controls.Add(this.btnUp);
            this.TreeviewTest.Controls.Add(this.InterfaceTreeView);
            this.TreeviewTest.Location = new System.Drawing.Point(4, 22);
            this.TreeviewTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TreeviewTest.Name = "TreeviewTest";
            this.TreeviewTest.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TreeviewTest.Size = new System.Drawing.Size(774, 444);
            this.TreeviewTest.TabIndex = 1;
            this.TreeviewTest.Text = "Interfaces";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(171, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Interfaces";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(673, 63);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(96, 28);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load from file";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(672, 29);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClbImport
            // 
            this.btnClbImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClbImport.Location = new System.Drawing.Point(4, 358);
            this.btnClbImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClbImport.Name = "btnClbImport";
            this.btnClbImport.Size = new System.Drawing.Size(115, 38);
            this.btnClbImport.TabIndex = 4;
            this.btnClbImport.Text = "Import from clipboard";
            this.btnClbImport.UseVisualStyleBackColor = true;
            this.btnClbImport.Click += new System.EventHandler(this.btnClbImport_Click);
            // 
            // btnAddInterface
            // 
            this.btnAddInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddInterface.Location = new System.Drawing.Point(4, 400);
            this.btnAddInterface.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddInterface.Name = "btnAddInterface";
            this.btnAddInterface.Size = new System.Drawing.Size(115, 35);
            this.btnAddInterface.TabIndex = 3;
            this.btnAddInterface.Text = "Add interface";
            this.btnAddInterface.UseVisualStyleBackColor = true;
            this.btnAddInterface.Click += new System.EventHandler(this.btnAddInterface_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(46, 61);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(83, 29);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(46, 29);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(83, 28);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // InterfaceTreeView
            // 
            this.InterfaceTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterfaceTreeView.CheckBoxes = true;
            this.InterfaceTreeView.Location = new System.Drawing.Point(133, 29);
            this.InterfaceTreeView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InterfaceTreeView.Name = "InterfaceTreeView";
            this.InterfaceTreeView.Size = new System.Drawing.Size(537, 262);
            this.InterfaceTreeView.TabIndex = 0;
            this.InterfaceTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.InterfaceTreeView_AfterCollapse);
            this.InterfaceTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.InterfaceTreeView_AfterExpand);
            this.InterfaceTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.InterfaceTreeView_NodeMouseClick);
            // 
            // EQClassGeneratorTab
            // 
            this.EQClassGeneratorTab.BackColor = System.Drawing.Color.SteelBlue;
            this.EQClassGeneratorTab.Controls.Add(this.label2);
            this.EQClassGeneratorTab.Controls.Add(this.btnGenerateEq);
            this.EQClassGeneratorTab.Controls.Add(this.EQTableGrid);
            this.EQClassGeneratorTab.Location = new System.Drawing.Point(4, 22);
            this.EQClassGeneratorTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EQClassGeneratorTab.Name = "EQClassGeneratorTab";
            this.EQClassGeneratorTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EQClassGeneratorTab.Size = new System.Drawing.Size(774, 444);
            this.EQClassGeneratorTab.TabIndex = 2;
            this.EQClassGeneratorTab.Text = "EQClassGeneratorTab";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equivalence class table";
            // 
            // btnGenerateEq
            // 
            this.btnGenerateEq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateEq.Location = new System.Drawing.Point(561, 29);
            this.btnGenerateEq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerateEq.Name = "btnGenerateEq";
            this.btnGenerateEq.Size = new System.Drawing.Size(185, 37);
            this.btnGenerateEq.TabIndex = 1;
            this.btnGenerateEq.Text = "Generate EQ table";
            this.btnGenerateEq.UseVisualStyleBackColor = true;
            this.btnGenerateEq.Click += new System.EventHandler(this.btnGenerateEq_Click);
            // 
            // EQTableGrid
            // 
            this.EQTableGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EQTableGrid.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.EQTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EQTableGrid.Location = new System.Drawing.Point(20, 70);
            this.EQTableGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EQTableGrid.Name = "EQTableGrid";
            this.EQTableGrid.ReadOnly = true;
            this.EQTableGrid.RowHeadersVisible = false;
            this.EQTableGrid.RowHeadersWidth = 62;
            this.EQTableGrid.RowTemplate.Height = 28;
            this.EQTableGrid.Size = new System.Drawing.Size(488, 230);
            this.EQTableGrid.TabIndex = 0;
            // 
            // TestToolkitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(788, 486);
            this.Controls.Add(this.InterfaceTab);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TestToolkitMain";
            this.Text = "Test toolkit";
            this.Load += new System.EventHandler(this.TestToolkitMain_Load);
            this.InterfaceTab.ResumeLayout(false);
            this.TreeviewTest.ResumeLayout(false);
            this.TreeviewTest.PerformLayout();
            this.EQClassGeneratorTab.ResumeLayout(false);
            this.EQClassGeneratorTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EQTableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl InterfaceTab;
        private System.Windows.Forms.TabPage TreeviewTest;
        private System.Windows.Forms.TreeView InterfaceTreeView;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnAddInterface;
        private System.Windows.Forms.Button btnClbImport;
        private System.Windows.Forms.TabPage EQClassGeneratorTab;
        private System.Windows.Forms.DataGridView EQTableGrid;
        private System.Windows.Forms.Button btnGenerateEq;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

