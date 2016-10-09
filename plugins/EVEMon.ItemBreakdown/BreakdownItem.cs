using System.Collections.Generic;

namespace EVEMon.ItemBreakdown
{
    public class BreakdownItem
    {
        /// <summary>
        /// The string representation of the item's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The long representation of the item's quantity.
        /// </summary>
        public long Quantity;

        /// <summary>
        /// The list of subBreakdownItems of the item.
        /// </summary>
        public List<BreakdownItem> MaterialList = new List<BreakdownItem>();

        public BreakdownItem Parent;

        public int timeEfficiency = 0;

        public int matEfficiency = 0;

        public bool isBlueprint()
        {
            return (MaterialList.Count > 0);
        }

        public override string ToString()
        {
            return string.Format("{0}x {1} @ {2}%", this.Quantity, this.Name, this.matEfficiency);
        }
    }
}
