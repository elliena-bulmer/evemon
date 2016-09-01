using EVEMon.Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEMon.ItemBreakdown
{
    /// <summary>
    /// Form for the ItemBreakdown module.
    /// </summary>
    public partial class BreakdownForm : Form
    {
        #region Fields

        private IEnumerable<Blueprint> _blueprintList;
        private Blueprint _selectedBlueprint;
        private int _currentMatEfficiency = 0;
        private int _currentRunCount = 1;
        private string _itemName;
        private bool _isUpdating = false;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Constructor for the BreakdownForm.
        /// </summary>
        public BreakdownForm()
        {
            InitializeComponent();

            // init SDE data
            LoadSDEInfo();
        }

        #endregion Constructor

        #region Event Handler

        /// <summary>
        /// Event handler for the close button.
        /// </summary>
        /// <param name="sender">control sender</param>
        /// <param name="e">event args</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event handler for the change of selected item.
        /// </summary>
        /// <param name="sender">control sender</param>
        /// <param name="e">event args</param>

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            _itemName = cboItemName.Text;

            // search and compile if found
            IEnumerable<Blueprint> bpFound = _blueprintList.Where(bp => bp.Name.ToLower().Contains(_itemName.ToLower()));

            if (bpFound.Count() > 1)
            {
                bpFound = bpFound.Where(bp => bp.Name.ToLower().Equals(_itemName.ToLower(), StringComparison.OrdinalIgnoreCase));
            }

            if (bpFound.Count() == 1)
            {
                cboItemName.Text = bpFound.First().Name;
                _itemName = cboItemName.Text;

                _selectedBlueprint = bpFound.First();

                UpdateMaterialList();
            }
        }

        /// <summary>
        /// Event handler for the change of material efficiency value.
        /// </summary>
        /// <param name="sender">control sender</param>
        /// <param name="e">event args</param>
        private void numMatEfficiency_ValueChanged(object sender, EventArgs e)
        {
            _currentMatEfficiency = (int)numMatEfficiency.Value;
            UpdateMaterialList();
        }

        /// <summary>
        /// Event handler for the change of run count value.
        /// </summary>
        /// <param name="sender">control sender</param>
        /// <param name="e">event args</param>

        private void numRunCount_ValueChanged(object sender, EventArgs e)
        {
            _currentRunCount = (int)numRunCount.Value;
            UpdateMaterialList();
        }

        #endregion Event Handler

        #region Methods

        /// <summary>
        /// Method to load the SDE information needed.
        /// </summary>
        private void LoadSDEInfo()
        {
            // TODO: add a check to know if the StaticBlueprint is fully loaded.

            _blueprintList = StaticBlueprints.AllBlueprints.OrderBy(b => b.Name);
            foreach(Blueprint bp in _blueprintList)
            {
                if (bp.MaterialRequirements.Any())
                {
                    cboItemName.Items.Add(bp.Name);
                }
            }            
        }

        /// <summary>
        /// Method that tries to update the material list.
        /// </summary>
        /// <remarks>Will fail if already updating.</remarks>
        private void UpdateMaterialList()
        {
            if (_isUpdating || _selectedBlueprint == null)
            {
                return;
            }

            Task<TreeNode> nodeResult = Task.Run(() => UpdateTask());           
        }

        /// <summary>
        /// Method used in a thread in order to not queue updated if the values of the form changed too quickly.
        /// </summary>
        /// <returns>The treenode object containing the whole tree.</returns>
        private TreeNode UpdateTask()
        {
            _isUpdating = true;

            TreeNode node = new TreeNode(string.Format("{0:N0} {1}", _currentRunCount, _selectedBlueprint.Name));

            List<TreeNode> childNodes = new List<TreeNode>();
            foreach (var mat in _selectedBlueprint.MaterialRequirements)
            {                
                TreeNode toAdd = RecursiveMaterialExpanding(mat, GetMaterialAmount(mat.Quantity));
                if (toAdd != null)
                {
                    childNodes.Add(toAdd);
                }
            }
            node.Nodes.AddRange(childNodes.ToArray());

            if (this.treeMaterials.InvokeRequired)
            {
                this.treeMaterials.BeginInvoke((MethodInvoker)delegate () 
                {
                    this.treeMaterials.Nodes.Clear();
                    this.treeMaterials.Nodes.Add(node);
                    this.treeMaterials.ExpandAll();
                });
            }

            _isUpdating = false;
            return node;
        }

        /// <summary>
        /// Recursive method that walks through the required materials and tries to fetch blueprints associated with these materials.
        /// </summary>
        /// <param name="mats">The material information required by the blueprint.</param>
        /// <param name="qte">The quantity of the material.</param>
        /// <returns>A partial Treenode </returns>
        private TreeNode RecursiveMaterialExpanding(StaticRequiredMaterial mats, long qte)
        {
            if (mats.Activity == Common.Enumerations.BlueprintActivity.Manufacturing)
            {
                TreeNode node = new TreeNode(string.Format("{0:N0} {1}", qte, mats.Name));

                IEnumerable<Blueprint> subBp = _blueprintList.Where(bp => bp.Name.Equals(mats.Name + " blueprint", StringComparison.OrdinalIgnoreCase));
                if (subBp.Count() == 1)
                {
                    List<TreeNode> childNodes = new List<TreeNode>();
                    foreach (var mat in subBp.First().MaterialRequirements)
                    {
                        TreeNode toAdd = RecursiveMaterialExpanding(mat, qte * GetMaterialAmount(mat.Quantity));
                        if (toAdd != null)
                        {
                            childNodes.Add(toAdd);
                        }
                    }
                    node.Nodes.AddRange(childNodes.ToArray());
                }
                return node;
            }
            return null;
        }

        /// <summary>
        /// Method that will return the amount of material required depending on the initial value and the curent input of the user.
        /// </summary>
        /// <param name="qte">The initial material quantity.</param>
        /// <returns>The quantity of material required with the current input provided.</returns>
        private long GetMaterialAmount(long qte)
        {
            double multiplier = (double)(1.0 - ((double)_currentMatEfficiency / 100.0));
            return (long)Math.Ceiling(_currentRunCount * ((double)qte * multiplier));
        }
        
        #endregion Methods
    }
}
