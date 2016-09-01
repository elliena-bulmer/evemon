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

        private const string _pluginName = "ItemBreakdown";
        private const string _pluginVersion = "0.1";

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


        #region IPluginMenuItem Implementation

        /// <summary>
        /// property that returns the Menu item list for the plugin generator.
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

        /// <summary>
        /// property that returns the plugin Name to the system.
        /// </summary>
        public string PluginName
        {
            get { return _pluginName; }
        }

        /// <summary>
        /// property that returns the plugin version to the system.
        /// </summary>
        public string PluginVersion
        {
            get { return _pluginVersion; }
        }

        #endregion IPluginMenuItem Implementation


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

    }
}
