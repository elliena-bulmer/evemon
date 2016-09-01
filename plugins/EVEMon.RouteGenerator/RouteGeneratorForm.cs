using EVEMon.Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEMon.RouteGenerator
{
    public partial class RouteGeneratorForm : Form
    {

        private readonly IEnumerable<Constellation> _constelations;
        private readonly IEnumerable<Common.Data.Region> _regions;
        private readonly IEnumerable<SolarSystem> _solarSystems;

        public RouteGeneratorForm(IEnumerable<Constellation> constellations, IEnumerable<Common.Data.Region> regions, IEnumerable<SolarSystem> solarSystems)
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
