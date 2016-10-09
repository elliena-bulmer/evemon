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

        private TreeNode _selectedItem;
        private BreakdownItem _currentTree;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Constructor for the BreakdownForm.
        /// </summary>
        /// <param name="bpList">The IEnumerable of Blueprint to use.</param>
        public BreakdownForm(IEnumerable<Blueprint> bpList)
        {
            InitializeComponent();

            // Add the list of blueprints to the combobox.
            _blueprintList = bpList;
            foreach (Blueprint bp in bpList)
            {
                if (bp.MaterialRequirements.Any())
                {
                    cboItemName.Items.Add(bp.Name);
                }
            }
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
                bpFound = bpFound.Where(bp => bp.Name.Equals(_itemName, StringComparison.OrdinalIgnoreCase));
            }

            if (bpFound.Count() == 1)
            {
                cboItemName.Text = bpFound.First().Name;
                _itemName = cboItemName.Text;

                _selectedBlueprint = bpFound.First();

                UpdateMaterialList(true);
            }
        }

        /// <summary>
        /// Event handler for the change of material efficiency value.
        /// </summary>
        /// <param name="sender">control sender</param>
        /// <param name="e">event args</param>
        private void numMatEfficiency_ValueChanged(object sender, EventArgs e)
        {
            _currentTree.matEfficiency = (int)numMatEfficiency.Value;
            _currentMatEfficiency = (int)numMatEfficiency.Value;
            _currentTree.matEfficiency = (int)numMatEfficiency.Value;
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
            _currentTree.Quantity = (int)numRunCount.Value;
            UpdateMaterialList();
        }

        #endregion Event Handler

        #region Methods

        /// <summary>
        /// Method that tries to update the material list.
        /// </summary>
        /// <remarks>Will fail if already updating.</remarks>
        private void UpdateMaterialList(bool isUpdatinngTree = false)
        {
            if (_isUpdating || _selectedBlueprint == null)
            {
                return;
            }

             Task.Run(() => UpdateTask(isUpdatinngTree));
        }

        /// <summary>
        /// Method used in a thread in order to not queue updated if the values of the form changed too quickly.
        /// </summary>
        /// <returns>The treenode object containing the whole tree.</returns>
        private void UpdateTask(bool isUpdatinngTree = false)
        {
            _isUpdating = true;

            if (_currentTree == null || isUpdatinngTree)
            {
                ComputeBreakdownItemList();
            }

            // Display the full extensive list.
            TreeNode outputNodeExtensive = RecursiveBuildExtensiveList(1, _currentTree);
            outputNodeExtensive.Tag = _currentTree;

            // Only display the end levels totals.
            TreeNode outputNodeCompressed = new TreeNode(string.Format("{0:N0} {1} ({2}%)", _currentTree.Quantity, _currentTree.Name, _currentTree.matEfficiency));
            outputNodeCompressed.Tag = _currentTree;

            List<BreakdownItem> itemList = RecursiveBuildCondensedList(_currentTree);
            IEnumerable<TreeNode> nodeList = CondenseAndGenerateTreeNodeFromCondensedList(itemList);
            foreach (TreeNode node in nodeList)
            {
                outputNodeCompressed.Nodes.Add(node);
            }

            // update the trees
            if (treeBreakdown.InvokeRequired)
            {
                treeBreakdown.BeginInvoke((MethodInvoker)delegate ()
                {
                    treeBreakdown.Nodes.Clear();
                    treeBreakdown.Nodes.Add(outputNodeExtensive);
                    treeBreakdown.ExpandAll();
                });
            }
            if (treeCondensed.InvokeRequired)
            {
                treeCondensed.BeginInvoke((MethodInvoker)delegate ()
                {
                    treeCondensed.Nodes.Clear();
                    treeCondensed.Nodes.Add(outputNodeCompressed);
                    treeCondensed.ExpandAll();
                });
            }

            _isUpdating = false;
        }

        private void ComputeBreakdownItemList()
        {
            // Compute the list of needed items.
            BreakdownItem root = new BreakdownItem()
            {
                Name = _selectedBlueprint.Name,
                Quantity = 1,
                matEfficiency = 0
            };
            foreach (var mat in _selectedBlueprint.MaterialRequirements)
            {
                BreakdownItem toAdd = RecursiveItemBreakdownComputing(mat, mat.Quantity, root);
                if (toAdd != null)
                {
                    root.MaterialList.Add(toAdd);
                }
            }
            _currentTree = root;
        }

        /// <summary>
        /// Recursive method that walks through the required materials and tries to fetch blueprints associated with these materials.
        /// </summary>
        /// <param name="mats">The material information required by the blueprint.</param>
        /// <param name="qte">The quantity of the material.</param>
        /// <returns>A partial BreakdownItem object</returns>
        private BreakdownItem RecursiveItemBreakdownComputing(StaticRequiredMaterial mats, long qte, BreakdownItem parentItem)
        {
            if (mats.Activity == Common.Enumerations.BlueprintActivity.Manufacturing)
            {
                BreakdownItem root = new BreakdownItem()
                {
                    Name = mats.Name,
                    Quantity = qte,
                    Parent = parentItem
                };
                
                IEnumerable<Blueprint> subBp = _blueprintList.Where(bp => bp.Name.Equals(mats.Name + " blueprint", StringComparison.OrdinalIgnoreCase));
                if (subBp.Count() == 1)
                {
                    foreach (var mat in subBp.First().MaterialRequirements)
                    {
                        BreakdownItem toAdd = RecursiveItemBreakdownComputing(mat, mat.Quantity, root);
                        if (toAdd != null)
                        {
                            root.MaterialList.Add(toAdd);
                        }
                    }
                }
                return root;
            }
            return null;
        }

        /// <summary>
        /// Method that recursively builds the Extended List of material according to a BreakdownItem input.
        /// </summary>
        /// <param name="input">the Partial or not BreakdownItem object</param>
        /// <returns>A Treenode containing all the extensive information.</returns>
        private TreeNode RecursiveBuildExtensiveList(long runCount, BreakdownItem input)
        {
            string textValue;
            int parentEfficiency = 0;
            long parentRunCount = 1;
            if (input.Parent != null)
            {
                parentEfficiency = input.Parent.matEfficiency;
                parentRunCount = input.Parent.Quantity;
            }
            long matCount = GetMaterialAmount(input.Quantity,  parentRunCount, parentEfficiency);
            if (input.isBlueprint())
            {
                textValue = string.Format("{0:N0} {1} ({2}%)", matCount, input.Name, input.matEfficiency);
            }
            else
            {
                textValue = string.Format("{0:N0} {1}", matCount, input.Name);
            }
            TreeNode node = new TreeNode(textValue);
            node.Tag = input;
            foreach (var mat in input.MaterialList)
            {
                TreeNode toAdd = RecursiveBuildExtensiveList(matCount, mat);
                if (toAdd != null)
                {
                    node.Nodes.Add(toAdd);
                }
            }
            return node;
        }

        /// <summary>
        /// Method that recursively builds the flatten List of material according to a BreakdownItem input.
        /// </summary>
        /// <param name="input">the Partial or not BreakdownItem object</param>
        /// <returns>A List of BreakdownItem containing the condensed information.</returns>
        private List<BreakdownItem> RecursiveBuildCondensedList(BreakdownItem input)
        {
            List<BreakdownItem> list = new List<BreakdownItem>();
            if (input.MaterialList.Any())
            {
                foreach (var mat in input.MaterialList)
                {
                    list.AddRange(RecursiveBuildCondensedList(mat));
                }
            }
            else
            {
                list.Add(new BreakdownItem() { Name = input.Name, Quantity = GetMaterialAmount(input.Quantity, input.Parent.Quantity, input.Parent.matEfficiency), Parent = input, matEfficiency = input.matEfficiency} );
            }
            return list;
        }

        /// <summary>
        /// Method that will condense and generate a Treenode from the BreakdownItem flat list.
        /// </summary>
        /// <param name="breakdownList">A Flatten list of BreakdownItems</param>
        /// <returns>A Treenode containing all the flatten information.</returns>
        private IEnumerable<TreeNode> CondenseAndGenerateTreeNodeFromCondensedList(List<BreakdownItem> breakdownList)
        {
            List<TreeNode> output = new List<TreeNode>();

            var orderedList = breakdownList.OrderBy(item => item.Name);
            var outputList = new List<BreakdownItem>();
            foreach (var item in orderedList)
            {
                // if we don't have any in the output list yet, handle this item type
                if (!outputList.Any(x => x.Name == item.Name))
                {
                    BreakdownItem newItem = new BreakdownItem()
                    {
                        Name = item.Name,
                        Parent = item
                    };
                    long count = 0;
                    var sameItemList = orderedList.Where(x => x.Name == item.Name);
                    foreach (var sameItem in sameItemList)
                    {
                        count += sameItem.Quantity;
                    }
                    newItem.Quantity = count;
                    outputList.Add(newItem);
                }
            }

            foreach (BreakdownItem item in outputList)
            {
                output.Add(new TreeNode(string.Format("{0:N0} {1}", item.Quantity, item.Name)));
            }

            return output;
        }
        
        /// <summary>
        /// Method that will return the amount of material required depending on the initial value and the curent input of the user.
        /// </summary>
        /// <param name="qte">The initial material quantity.</param>
        /// <returns>The quantity of material required with the current input provided.</returns>
        private long GetMaterialAmount(long qte, long runCount, int efficiency)
        {
            double multiplier = (double)(1.0 + ((double)efficiency / 100.0));
            return (long)Math.Ceiling(((double)(runCount * qte) / multiplier));
        }

        #endregion Methods

        private void UpdateEfficiency(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            int desiredEff = 0;
            string menuItemText = menu.Text.Substring(0, menu.Text.Length-1);
            if (menuItemText.Equals("Manual Input..", StringComparison.OrdinalIgnoreCase))
            {
                // show window for input
                ManualInputForm inputForm = new ManualInputForm();
                DialogResult inputValue = inputForm.ShowDialog();
                if (inputValue == DialogResult.OK)
                {
                    desiredEff = inputForm.ValueSelected;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (!int.TryParse(menuItemText, out desiredEff))
                {
                    // we don't want to continue if we fail to parse the efficiency
                    return;
                }
            }

            if (_selectedItem.Tag != null)
            {
                BreakdownItem currentItem = RecursiveFindItemInTree(_selectedItem.Tag as BreakdownItem, _currentTree);
                if (currentItem.isBlueprint())
                {
                    currentItem.matEfficiency = desiredEff;
                    UpdateMaterialList();
                }
            }
        }

        private BreakdownItem RecursiveFindItemInTree(BreakdownItem input, BreakdownItem searchNode)
        {

            if (input.Name == searchNode.Name)
            {
                if (input.Parent == null || input.Parent == searchNode.Parent)
                {
                    return searchNode;
                }                
            }

            foreach(BreakdownItem item in searchNode.MaterialList)
            {
                BreakdownItem child = RecursiveFindItemInTree(input, item);
                if (child != null)
                {
                    return child;
                }
            }

            return null;
        }

        private void treeBreakdown_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeBreakdown.SelectedNode = e.Node;
            _selectedItem = e.Node;

            if (e.Button == MouseButtons.Right)
            {
                // show context menu
                BreakdownItem currentItem = RecursiveFindItemInTree(_selectedItem.Tag as BreakdownItem, _currentTree);
                if (currentItem != null && currentItem.isBlueprint())
                {
                    cmnuBreakdown.Show(treeBreakdown, e.X, e.Y);
                }                
            }            
        }
    }
}
