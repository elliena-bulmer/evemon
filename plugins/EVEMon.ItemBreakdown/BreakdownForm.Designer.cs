namespace EVEMon.ItemBreakdown
{
    partial class BreakdownForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.numRunCount = new System.Windows.Forms.NumericUpDown();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.numMatEfficiency = new System.Windows.Forms.NumericUpDown();
            this.lblMatEfficiency = new System.Windows.Forms.Label();
            this.tcMaterialView = new System.Windows.Forms.TabControl();
            this.tabBreakdown = new System.Windows.Forms.TabPage();
            this.treeBreakdown = new System.Windows.Forms.TreeView();
            this.tabCondensed = new System.Windows.Forms.TabPage();
            this.treeCondensed = new System.Windows.Forms.TreeView();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatEfficiency)).BeginInit();
            this.tcMaterialView.SuspendLayout();
            this.tabBreakdown.SuspendLayout();
            this.tabCondensed.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(297, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.numRunCount);
            this.grpInput.Controls.Add(this.lblItemName);
            this.grpInput.Controls.Add(this.lblRunCount);
            this.grpInput.Controls.Add(this.cboItemName);
            this.grpInput.Controls.Add(this.numMatEfficiency);
            this.grpInput.Controls.Add(this.lblMatEfficiency);
            this.grpInput.Location = new System.Drawing.Point(12, 3);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(360, 87);
            this.grpInput.TabIndex = 9;
            this.grpInput.TabStop = false;
            // 
            // numRunCount
            // 
            this.numRunCount.Location = new System.Drawing.Point(248, 42);
            this.numRunCount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numRunCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRunCount.Name = "numRunCount";
            this.numRunCount.Size = new System.Drawing.Size(97, 20);
            this.numRunCount.TabIndex = 14;
            this.numRunCount.ThousandsSeparator = true;
            this.numRunCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRunCount.ValueChanged += new System.EventHandler(this.numRunCount_ValueChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(15, 16);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 13);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "Item Name:";
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(181, 44);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(61, 13);
            this.lblRunCount.TabIndex = 13;
            this.lblRunCount.Text = "Run Count:";
            // 
            // cboItemName
            // 
            this.cboItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(82, 13);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(263, 21);
            this.cboItemName.TabIndex = 10;
            this.cboItemName.TextChanged += new System.EventHandler(this.cboItemName_TextChanged);
            // 
            // numMatEfficiency
            // 
            this.numMatEfficiency.Location = new System.Drawing.Point(117, 42);
            this.numMatEfficiency.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMatEfficiency.Name = "numMatEfficiency";
            this.numMatEfficiency.Size = new System.Drawing.Size(43, 20);
            this.numMatEfficiency.TabIndex = 12;
            this.numMatEfficiency.ValueChanged += new System.EventHandler(this.numMatEfficiency_ValueChanged);
            // 
            // lblMatEfficiency
            // 
            this.lblMatEfficiency.AutoSize = true;
            this.lblMatEfficiency.Location = new System.Drawing.Point(15, 44);
            this.lblMatEfficiency.Name = "lblMatEfficiency";
            this.lblMatEfficiency.Size = new System.Drawing.Size(96, 13);
            this.lblMatEfficiency.TabIndex = 11;
            this.lblMatEfficiency.Text = "Material Efficiency:";
            // 
            // tcMaterialView
            // 
            this.tcMaterialView.Controls.Add(this.tabBreakdown);
            this.tcMaterialView.Controls.Add(this.tabCondensed);
            this.tcMaterialView.Location = new System.Drawing.Point(12, 97);
            this.tcMaterialView.Name = "tcMaterialView";
            this.tcMaterialView.SelectedIndex = 0;
            this.tcMaterialView.Size = new System.Drawing.Size(360, 327);
            this.tcMaterialView.TabIndex = 10;
            // 
            // tabBreakdown
            // 
            this.tabBreakdown.Controls.Add(this.treeBreakdown);
            this.tabBreakdown.Location = new System.Drawing.Point(4, 22);
            this.tabBreakdown.Name = "tabBreakdown";
            this.tabBreakdown.Padding = new System.Windows.Forms.Padding(3);
            this.tabBreakdown.Size = new System.Drawing.Size(352, 301);
            this.tabBreakdown.TabIndex = 0;
            this.tabBreakdown.Text = "Breakdown";
            this.tabBreakdown.UseVisualStyleBackColor = true;
            // 
            // treeBreakdown
            // 
            this.treeBreakdown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeBreakdown.Location = new System.Drawing.Point(6, 7);
            this.treeBreakdown.Name = "treeBreakdown";
            this.treeBreakdown.Size = new System.Drawing.Size(340, 288);
            this.treeBreakdown.TabIndex = 1;
            // 
            // tabCondensed
            // 
            this.tabCondensed.Controls.Add(this.treeCondensed);
            this.tabCondensed.Location = new System.Drawing.Point(4, 22);
            this.tabCondensed.Name = "tabCondensed";
            this.tabCondensed.Padding = new System.Windows.Forms.Padding(3);
            this.tabCondensed.Size = new System.Drawing.Size(352, 301);
            this.tabCondensed.TabIndex = 1;
            this.tabCondensed.Text = "Condensed";
            this.tabCondensed.UseVisualStyleBackColor = true;
            // 
            // treeCondensed
            // 
            this.treeCondensed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeCondensed.Location = new System.Drawing.Point(6, 6);
            this.treeCondensed.Name = "treeCondensed";
            this.treeCondensed.Size = new System.Drawing.Size(340, 288);
            this.treeCondensed.TabIndex = 2;
            // 
            // BreakdownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 462);
            this.Controls.Add(this.tcMaterialView);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "BreakdownForm";
            this.Text = "Item Breakdown";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMatEfficiency)).EndInit();
            this.tcMaterialView.ResumeLayout(false);
            this.tabBreakdown.ResumeLayout(false);
            this.tabCondensed.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblMatEfficiency;
        private System.Windows.Forms.NumericUpDown numMatEfficiency;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.NumericUpDown numRunCount;
        private System.Windows.Forms.TabControl tcMaterialView;
        private System.Windows.Forms.TabPage tabBreakdown;
        private System.Windows.Forms.TreeView treeBreakdown;
        private System.Windows.Forms.TabPage tabCondensed;
        private System.Windows.Forms.TreeView treeCondensed;
    }
}