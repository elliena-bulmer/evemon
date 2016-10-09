using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEMon.ItemBreakdown
{
    public partial class ManualInputForm : Form
    {
        public int ValueSelected = 0;

        public ManualInputForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numValue_ValueChanged(object sender, EventArgs e)
        {
            ValueSelected = (int)numValue.Value;
        }
    }
}
