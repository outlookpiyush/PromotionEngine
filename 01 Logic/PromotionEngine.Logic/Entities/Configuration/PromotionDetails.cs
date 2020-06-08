namespace PromotionEngine.Logic.Entities.Configuration
{
    /// <summary>
    /// Define Promotion Details
    /// </summary>
    public class PromotionDetails
    {
        /// <summary>
        /// Get Or Set PromotionID
        /// </summary>
        public int PromotionID { get; set; }
        /// <summary>
        /// Get or Set Promotion Description
        /// </summary>
        public string PromotionDescription { get; set; }
        /// <summary>
        /// Get or Set IsItemDisc 
        /// </summary>
        public bool IsItemDisc { get; set; }
        /// <summary>
        /// Get or Set IsFlat
        /// </summary>
        public bool IsFlat { get; set; }
        /// <summary>
        /// Get or Set SKUID
        /// </summary>
        public int SKUID { get; set; }
        /// <summary>
        /// Get or Set Promotion Qty
        /// </summary>
        public int PromotionQty { get; set; }
        /// <summary>
        /// Get or Set Sell Price
        /// </summary>
        public decimal PromotionAmount { get; set; }
        /// <summary>
        /// Get or Set ReferSKUID
        /// </summary>
        public int ReferSKUID { get; set; }
        /// <summary>
        /// Get or Set ReferSKU Qty.
        /// </summary>
        public int ReferSKUQty { get; set; }
    }
}
