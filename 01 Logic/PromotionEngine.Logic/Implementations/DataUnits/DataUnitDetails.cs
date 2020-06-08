using PromotionEngine.Logic.Entities.Transactions;
using PromotionEngine.Logic.Implementations.DataTags.Transaction;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Implementations.DataUnits
{
    public class DataUnitDetails
    {
        #region Variable Declaraction

        CardItemDetailsData cardItemDetailsData;
        #endregion Variable Declaraction

        #region Constructor

        /// <summary>
        /// Constructor Implementation
        /// </summary>
        /// <param name="dataStructure">dataStructure as IDataStructure Object</param>
        public DataUnitDetails()
        {
            cardItemDetailsData = new CardItemDetailsData();
        }
        #endregion Constructor

        #region CardItems Public Method

        public List<CartItemDetails> GetBillDetails(List<CartItemDetails> cartItemDetails)
        {
            return cardItemDetailsData.GetBill(cartItemDetails);
        }

        #endregion Cart Itmes Public Method
    }
}
