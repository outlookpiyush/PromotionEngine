using PromotionEngine.Logic.Entities.Transactions;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Implementations.DataTag.Transactions
{
    /// <summary>
    /// Define Transaction Value
    /// </summary>
    interface ICartItemDetails
    {
        /// <summary>
        /// Design Transaction in Data
        /// </summary>
        /// <param name="cartItemDetails">cardItemDetails as CardItemDetails Object</param>
        /// <returns>return CartItemDetails List Object</returns>
        List<CartItemDetails> GetBill(List<CartItemDetails> cartItemDetails);
    }
}
