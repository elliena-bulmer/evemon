namespace EVEMon.RouteGenerator
{
    partial class RouteGeneratorForm
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
            this.lblOrigin = new System.Windows.Forms.Label();
            this.cboOrigin = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cboDestination = new System.Windows.Forms.ComboBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.cgkAvoidHigh = new System.Windows.Forms.CheckBox();
            this.chkAvoidLow = new System.Windows.Forms.CheckBox();
            this.cgkAvoidNull = new System.Windows.Forms.CheckBox();
            this.lvRoute = new System.Windows.Forms.ListView();
            this.colRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJumpID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConstellation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(12, 9);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(37, 13);
            this.lblOrigin.TabIndex = 0;
            this.lblOrigin.Text = "Origin:";
            // 
            // cboOrigin
            // 
            this.cboOrigin.FormattingEnabled = true;
            this.cboOrigin.Location = new System.Drawing.Point(84, 6);
            this.cboOrigin.Name = "cboOrigin";
            this.cboOrigin.Size = new System.Drawing.Size(168, 21);
            this.cboOrigin.TabIndex = 1;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 33);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(63, 13);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "Destination:";
            // 
            // cboDestination
            // 
            this.cboDestination.FormattingEnabled = true;
            this.cboDestination.Location = new System.Drawing.Point(84, 30);
            this.cboDestination.Name = "cboDestination";
            this.cboDestination.Size = new System.Drawing.Size(168, 21);
            this.cboDestination.TabIndex = 3;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.cgkAvoidNull);
            this.grpOptions.Controls.Add(this.chkAvoidLow);
            this.grpOptions.Controls.Add(this.cgkAvoidHigh);
            this.grpOptions.Location = new System.Drawing.Point(15, 57);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(114, 89);
            this.grpOptions.TabIndex = 4;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // cgkAvoidHigh
            // 
            this.cgkAvoidHigh.AutoSize = true;
            this.cgkAvoidHigh.Location = new System.Drawing.Point(6, 19);
            this.cgkAvoidHigh.Name = "cgkAvoidHigh";
            this.cgkAvoidHigh.Size = new System.Drawing.Size(95, 17);
            this.cgkAvoidHigh.TabIndex = 1;
            this.cgkAvoidHigh.Text = "Avoid HghSec";
            this.cgkAvoidHigh.UseVisualStyleBackColor = true;
            // 
            // chkAvoidLow
            // 
            this.chkAvoidLow.AutoSize = true;
            this.chkAvoidLow.Location = new System.Drawing.Point(6, 42);
            this.chkAvoidLow.Name = "chkAvoidLow";
            this.chkAvoidLow.Size = new System.Drawing.Size(95, 17);
            this.chkAvoidLow.TabIndex = 2;
            this.chkAvoidLow.Text = "Avoid LowSec";
            this.chkAvoidLow.UseVisualStyleBackColor = true;
            // 
            // cgkAvoidNull
            // 
            this.cgkAvoidNull.AutoSize = true;
            this.cgkAvoidNull.Location = new System.Drawing.Point(6, 65);
            this.cgkAvoidNull.Name = "cgkAvoidNull";
            this.cgkAvoidNull.Size = new System.Drawing.Size(93, 17);
            this.cgkAvoidNull.TabIndex = 3;
            this.cgkAvoidNull.Text = "Avoid NullSec";
            this.cgkAvoidNull.UseVisualStyleBackColor = true;
            // 
            // lvRoute
            // 
            this.lvRoute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJumpID,
            this.colRating,
            this.colName,
            this.colDistance,
            this.colConstellation,
            this.colRegion});
            this.lvRoute.Location = new System.Drawing.Point(15, 153);
            this.lvRoute.Name = "lvRoute";
            this.lvRoute.Size = new System.Drawing.Size(431, 226);
            this.lvRoute.TabIndex = 5;
            this.lvRoute.UseCompatibleStateImageBehavior = false;
            // 
            // colRating
            // 
            this.colRating.DisplayIndex = 0;
            this.colRating.Text = "Rating";
            // 
            // colName
            // 
            this.colName.DisplayIndex = 1;
            this.colName.Text = "Name";
            // 
            // colJumpID
            // 
            this.colJumpID.DisplayIndex = 2;
            this.colJumpID.Text = "Jump";
            // 
            // colConstellation
            // 
            this.colConstellation.DisplayIndex = 3;
            this.colConstellation.Text = "Constellation";
            // 
            // colRegion
            // 
            this.colRegion.DisplayIndex = 4;
            this.colRegion.Text = "Region";
            // 
            // colDistance
            // 
            this.colDistance.DisplayIndex = 5;
            this.colDistance.Text = "Distance";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(371, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RouteGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 416);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvRoute);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.cboDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.cboOrigin);
            this.Controls.Add(this.lblOrigin);
            this.Name = "RouteGeneratorForm";
            this.Text = "Route Generator";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.ComboBox cboOrigin;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ComboBox cboDestination;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox cgkAvoidNull;
        private System.Windows.Forms.CheckBox chkAvoidLow;
        private System.Windows.Forms.CheckBox cgkAvoidHigh;
        private System.Windows.Forms.ListView lvRoute;
        private System.Windows.Forms.ColumnHeader colJumpID;
        private System.Windows.Forms.ColumnHeader colRating;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDistance;
        private System.Windows.Forms.ColumnHeader colConstellation;
        private System.Windows.Forms.ColumnHeader colRegion;
        private System.Windows.Forms.Button btnClose;
    }
}