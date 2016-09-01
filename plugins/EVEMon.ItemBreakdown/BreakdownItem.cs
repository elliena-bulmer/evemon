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
    }
}
