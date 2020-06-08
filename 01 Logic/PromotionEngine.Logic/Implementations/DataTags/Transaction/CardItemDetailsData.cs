using PromotionEngine.Logic.Entities.Configuration;
using PromotionEngine.Logic.Entities.Transactions;
using PromotionEngine.Logic.Implementations.DataTag.Transactions;
using PromotionEngine.Logic.Implementations.DataTags.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Logic.Implementations.DataTags.Transaction
{
    /// <summary>
    /// Card Item Details Data Configuration
    /// </summary>
    public class CardItemDetailsData : ICartItemDetails
    {
        #region Public Method
        /// <summary>
        /// Get Bill Details
        /// </summary>
        /// <param name="cartItemDetails"></param>
        /// <returns></returns>
        public List<CartItemDetails> GetBill(List<CartItemDetails> cartItemDetails)
        {
            // Load SKU Details Here
            SKUDetailsData skuDetailsData = new SKUDetailsData();
            IList<SKUDetails> skuDetailsList = skuDetailsData.GetAllSKU();

            // Load All Promotion
            PromotionDetailsData promotionDetailsData = new PromotionDetailsData();
            IList<PromotionDetails> promotionDetails = promotionDetailsData.GetAllPromotions();
            
            for(int i=0;i<cartItemDetails.Count;i++)
            {
                var skuDetails = skuDetailsList.Where(sku => sku.SKU.ToUpper().Equals(cartItemDetails[i].SKUName.ToUpper())).FirstOrDefault();
                var promotionDetail = promotionDetails.Where(skuid => skuid.SKUID == skuDetails.SKUID).FirstOrDefault();

                if(promotionDetail != null)
                {
                    if(promotionDetail.ReferSKUID == 0)
                    {
                        #region Discount Apply Without Other Product
                        // Discount is Avaliable without Other Product
                        if (promotionDetail.IsFlat && promotionDetail.IsItemDisc) // Consider Promotion as Flat With Qty
                        {
                            if (promotionDetail.PromotionQty > cartItemDetails[i].SKUQty)
                            {
                                CalculateLineItem(cartItemDetails, skuDetails, promotionDetail, i);
                            }
                            else
                            {
                                if (cartItemDetails[i].SKUQty / promotionDetail.PromotionQty >= 0)
                                {
                                    cartItemDetails[i].SellPrice = skuDetails.SellPrice * cartItemDetails[i].SKUQty;
                                    cartItemDetails[i].TotalAmount = ((cartItemDetails[i].SKUQty / promotionDetail.PromotionQty) * promotionDetail.PromotionAmount) + ((cartItemDetails[i].SKUQty - ((cartItemDetails[i].SKUQty / promotionDetail.PromotionQty) * promotionDetail.PromotionQty)) * skuDetails.SellPrice);
                                    cartItemDetails[i].Discount = cartItemDetails[i].SellPrice - cartItemDetails[i].TotalAmount;
                                    cartItemDetails[i].IsApplyPromo = true;
                                }
                            }

                        }
                        else // Consider Promotion is Percentage basis
                        {
                            if (promotionDetail.PromotionQty > cartItemDetails[i].SKUQty)
                            {
                                CalculateLineItem(cartItemDetails, skuDetails, promotionDetail, i);
                            }
                            else
                            {
                                if (cartItemDetails[i].SKUQty / promotionDetail.PromotionQty >= 0)
                                {
                                    decimal percentageAmount = skuDetails.SellPrice - ((skuDetails.SellPrice * promotionDetail.PromotionAmount) / 100);

                                    cartItemDetails[i].SellPrice = percentageAmount * cartItemDetails[i].SKUQty;
                                    cartItemDetails[i].TotalAmount = ((cartItemDetails[i].SKUQty / promotionDetail.PromotionQty) * percentageAmount) + ((cartItemDetails[i].SKUQty - ((cartItemDetails[i].SKUQty / promotionDetail.PromotionQty) * promotionDetail.PromotionQty)) * skuDetails.SellPrice);
                                    cartItemDetails[i].Discount = cartItemDetails[i].SellPrice - cartItemDetails[i].TotalAmount;
                                    cartItemDetails[i].IsApplyPromo = true;
                                }
                            }
                        }

                        #endregion #region Discount Apply Without Other Product
                    }
                    else
                    {
                        #region Apply With Other Product

                        decimal refSKUSellPrice = skuDetailsData.GetSKUByID(promotionDetail.ReferSKUID).SellPrice;
                        var findRefSKUInCurrentItem = cartItemDetails.Where(find => find.SKUName.ToUpper().Equals(skuDetailsData.GetSKUByID(promotionDetail.ReferSKUID).SKU.ToUpper()) && find.IsApplyPromo == false).FirstOrDefault();
                        int PromotionIndex = cartItemDetails.FindIndex(find => find.SKUName.ToUpper().Equals(skuDetailsData.GetSKUByID(promotionDetail.ReferSKUID).SKU.ToUpper()) && find.IsApplyPromo == false);

                        if (findRefSKUInCurrentItem != null)
                        {
                            if(refSKUSellPrice < skuDetails.SellPrice)
                            {
                                cartItemDetails[i].SKUQty = cartItemDetails[i].SKUQty - promotionDetail.PromotionQty;
                                cartItemDetails[i].SellPrice = cartItemDetails[i].SKUQty * skuDetails.SellPrice;
                                cartItemDetails[i].Discount = (cartItemDetails[i].SKUQty - promotionDetail.ReferSKUQty) * skuDetails.SellPrice;
                                cartItemDetails[i].TotalAmount = cartItemDetails[i].SKUQty * skuDetails.SellPrice;
                                cartItemDetails[i].IsApplyPromo = true;

                                cartItemDetails[PromotionIndex].SKUQty = cartItemDetails[PromotionIndex].SKUQty + promotionDetail.ReferSKUQty;
                                cartItemDetails[PromotionIndex].SellPrice = cartItemDetails[PromotionIndex].SKUQty * refSKUSellPrice;
                                cartItemDetails[PromotionIndex].Discount = 0;
                                cartItemDetails[PromotionIndex].TotalAmount = cartItemDetails[PromotionIndex].SKUQty * refSKUSellPrice;
                                cartItemDetails[PromotionIndex].IsApplyPromo = true;
                            }
                            else
                            {
                                cartItemDetails[PromotionIndex].SKUQty = cartItemDetails[PromotionIndex].SKUQty - promotionDetail.ReferSKUQty;
                                cartItemDetails[PromotionIndex].SellPrice = cartItemDetails[PromotionIndex].SKUQty * refSKUSellPrice;
                                cartItemDetails[PromotionIndex].Discount = 0;
                                cartItemDetails[PromotionIndex].TotalAmount = cartItemDetails[PromotionIndex].SKUQty * refSKUSellPrice;
                                cartItemDetails[PromotionIndex].IsApplyPromo = true;

                                cartItemDetails[i].SKUQty = cartItemDetails[i].SKUQty + promotionDetail.PromotionQty;
                                cartItemDetails[i].SellPrice = cartItemDetails[i].SKUQty * refSKUSellPrice;
                                cartItemDetails[i].Discount = (cartItemDetails[i].SKUQty + promotionDetail.PromotionQty) * refSKUSellPrice;
                                cartItemDetails[i].TotalAmount = cartItemDetails[i].SKUQty * refSKUSellPrice;
                                cartItemDetails[i].IsApplyPromo = true;
                            }
                        }
                        else
                        {
                            CalculateLineItem(cartItemDetails, skuDetails, promotionDetail, i);
                        }

                        #endregion Apply With Other Product
                    }
                }
                else
                {
                    CalculateLineItem(cartItemDetails, skuDetails, promotionDetail, i);
                }
            }
            return cartItemDetails;
        }

        #endregion Public Method

        #region Private Method
        /// <summary>
        /// Get List Details Enter
        /// </summary>
        /// <param name="cartItemDetails"></param>
        /// <param name="skuDetails"></param>
        /// <param name="promotionDetail"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private List<CartItemDetails> CalculateLineItem(List<CartItemDetails> cartItemDetails, SKUDetails skuDetails, PromotionDetails promotionDetail,int currentIndex)
        {
            if (!cartItemDetails[currentIndex].IsApplyPromo)
            {
                cartItemDetails[currentIndex].SellPrice = skuDetails.SellPrice * cartItemDetails[currentIndex].SKUQty;
                cartItemDetails[currentIndex].Discount = 0;
                cartItemDetails[currentIndex].TotalAmount = skuDetails.SellPrice;
            }
            return cartItemDetails;
        }

        #endregion Private Method
    }
}
