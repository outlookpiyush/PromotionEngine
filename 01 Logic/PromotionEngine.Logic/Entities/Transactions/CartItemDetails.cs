namespace PromotionEngine.Logic.Entities.Transactions
{
    /// <summary>
    /// Define Cart Item
    /// </summary>
    public class CartItemDetails
    {
        /// <summary>
        /// Get or Set SKU Name
        /// </summary>
        public string SKUName { get; set; }
        /// <summary>
        /// Get or Set SKU Qty.
        /// </summary>
        public int SKUQty { get; set; }
        /// <summary>
        /// Get or Set Promotion Description
        /// </summary>
        public string PromotionDescription { get; set; }
        /// <summary>
        /// Get or Set Price
        /// </summary>
        public decimal SellPrice { get; set; }
        /// <summary>
        /// Get or Set Discount
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Get or Set Total Amount
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Get or Set Apply Promotion
        /// </summary>
        public bool IsApplyPromo { get; set; }
    }
}
