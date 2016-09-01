using System;
using System.Windows.Forms;
using System.Collections.Generic;

using EVEMon.Common.PluginSytem;

namespace EVEMon.ItemBreakdown
{
    public class PluginItemBreakdown : IPluginMenuItem
    {

        #region Fields

        private ToolStripMenuItem _mnuItemBreakdown;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Constructor for the Plugin Item Breakdown.
        /// </summary>
        public PluginItemBreakdown()
        {
            ToolStripMenuItem mnuItemBreakdown = new ToolStripMenuItem();
            mnuItemBreakdown.Name = "mnuItemBreakdown";
            mnuItemBreakdown.Size = new System.Drawing.Size(114, 20);
            mnuItemBreakdown.Text = "Item Breakdown...";
            mnuItemBreakdown.Click += new System.EventHandler(mnuItemBreakdown_Click);

            _mnuItemBreakdown = mnuItemBreakdown;
        }

        #endregion Constructor


        #region Properties

        /// <summary>
        /// Method that returns the Menu item list for the plugin generator.
        /// </summary>
        public IEnumerable<ToolStripMenuItem> MenuItemList
        {
            get
            {
                var list = new List<ToolStripMenuItem>();
                list.Add(_mnuItemBreakdown);
                return list;
            }
        }

        #endregion Properties


        #region Event Handler

        /// <summary>
        /// Event handling for when the Menu item is clicked.
        /// </summary>
        /// <param name="sender">the control sending.</param>
        /// <param name="e">event args</param>
        private void mnuItemBreakdown_Click(object sender, EventArgs e)
        {
            BreakdownForm form = new BreakdownForm();
            form.Show();
        }

        #endregion Event Handler


        #region Method

        /// <summary>
        /// Method that returns the plugin Name to the system.
        /// </summary>
        /// <returns>A string representation of the Plugin's name.</returns>
        public string PluginName()
        {
            return "ItemBreakdown";
        }

        #endregion Method

    }
}
