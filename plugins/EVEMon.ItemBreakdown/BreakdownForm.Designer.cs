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
            this.treeMaterials = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.lblMatEfficiency = new System.Windows.Forms.Label();
            this.numMatEfficiency = new System.Windows.Forms.NumericUpDown();
            this.lblRunCount = new System.Windows.Forms.Label();
            this.numRunCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMatEfficiency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMaterials
            // 
            this.treeMaterials.Location = new System.Drawing.Point(12, 74);
            this.treeMaterials.Name = "treeMaterials";
            this.treeMaterials.Size = new System.Drawing.Size(331, 324);
            this.treeMaterials.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(13, 13);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 13);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Item Name:";
            // 
            // cboItemName
            // 
            this.cboItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(80, 10);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(263, 21);
            this.cboItemName.TabIndex = 4;
            this.cboItemName.TextChanged += new System.EventHandler(this.cboItemName_TextChanged);
            // 
            // lblMatEfficiency
            // 
            this.lblMatEfficiency.AutoSize = true;
            this.lblMatEfficiency.Location = new System.Drawing.Point(13, 41);
            this.lblMatEfficiency.Name = "lblMatEfficiency";
            this.lblMatEfficiency.Size = new System.Drawing.Size(96, 13);
            this.lblMatEfficiency.TabIndex = 5;
            this.lblMatEfficiency.Text = "Material Efficiency:";
            // 
            // numMatEfficiency
            // 
            this.numMatEfficiency.Location = new System.Drawing.Point(115, 39);
            this.numMatEfficiency.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMatEfficiency.Name = "numMatEfficiency";
            this.numMatEfficiency.Size = new System.Drawing.Size(43, 20);
            this.numMatEfficiency.TabIndex = 6;
            this.numMatEfficiency.ValueChanged += new System.EventHandler(this.numMatEfficiency_ValueChanged);
            // 
            // lblRunCount
            // 
            this.lblRunCount.AutoSize = true;
            this.lblRunCount.Location = new System.Drawing.Point(179, 41);
            this.lblRunCount.Name = "lblRunCount";
            this.lblRunCount.Size = new System.Drawing.Size(61, 13);
            this.lblRunCount.TabIndex = 7;
            this.lblRunCount.Text = "Run Count:";
            // 
            // numRunCount
            // 
            this.numRunCount.Location = new System.Drawing.Point(246, 39);
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
            this.numRunCount.TabIndex = 8;
            this.numRunCount.ThousandsSeparator = true;
            this.numRunCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRunCount.ValueChanged += new System.EventHandler(this.numRunCount_ValueChanged);
            // 
            // BreakdownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 434);
            this.Controls.Add(this.numRunCount);
            this.Controls.Add(this.lblRunCount);
            this.Controls.Add(this.numMatEfficiency);
            this.Controls.Add(this.lblMatEfficiency);
            this.Controls.Add(this.cboItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.treeMaterials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BreakdownForm";
            this.Text = "Item Breakdown";
            ((System.ComponentModel.ISupportInitialize)(this.numMatEfficiency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeMaterials;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.Label lblMatEfficiency;
        private System.Windows.Forms.NumericUpDown numMatEfficiency;
        private System.Windows.Forms.Label lblRunCount;
        private System.Windows.Forms.NumericUpDown numRunCount;
    }
}