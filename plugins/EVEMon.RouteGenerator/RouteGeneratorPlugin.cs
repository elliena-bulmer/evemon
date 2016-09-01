using System;
using System.Collections.Generic;


using EVEMon.Common.PluginSytem;
using System.Windows.Forms;
using EVEMon.Common.Data;

namespace EVEMon.RouteGenerator
{
    public class RouteGeneratorPlugin : IPluginMenuItem
    {
        #region Fields

        private ToolStripMenuItem _mnuRouteGeneratorPlugin;

        private const string _pluginName = "Route Generator";
        private const string _pluginVersion = "0.1";

        #endregion Fields


        #region Constructor

        public RouteGeneratorPlugin()
        {
            ToolStripMenuItem mnuRouteGeneratorPlugin = new ToolStripMenuItem();
            mnuRouteGeneratorPlugin.Name = "mnuRouteGeneratorPlugin";
            mnuRouteGeneratorPlugin.Size = new System.Drawing.Size(114, 20);
            mnuRouteGeneratorPlugin.Text = "Route Generator...";
            mnuRouteGeneratorPlugin.Click += new System.EventHandler(mnuRouteGeneratorPlugin_Click);

            _mnuRouteGeneratorPlugin = mnuRouteGeneratorPlugin;
        }

        #endregion Constructor


        #region IPLuginMenuItem implementation

        public IEnumerable<ToolStripMenuItem> MenuItemList
        {
            get
            {
                var list = new List<ToolStripMenuItem>();
                list.Add(_mnuRouteGeneratorPlugin);
                return list;
            }
        }

        public string PluginName
        {
            get
            {
                return _pluginName;
            }

        }

        public string PluginVersion
        {
            get
            {
                return _pluginVersion;
            }
        }

        #endregion IPLuginMenuItem implementation


        #region Event Handler

        /// <summary>
        /// Event handling for when the Menu item is clicked.
        /// </summary>
        /// <param name="sender">the control sending.</param>
        /// <param name="e">event args</param>
        private void mnuRouteGeneratorPlugin_Click(object sender, EventArgs e)
        {
            RouteGeneratorForm form = new RouteGeneratorForm(StaticGeography.AllConstellations,
                                                             StaticGeography.AllRegions,
                                                             StaticGeography.AllSolarSystems);
            form.Show();
        }

        #endregion Event Handler
    }
}
