using PromotionEngine.Logic.Entities.Configuration;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Implementations.DataTag.Configuration
{
    /// <summary>
    /// Define Promotion Details Interface
    /// </summary>
    interface IPromotionDetailsData
    {
        /// <summary>
        /// Get Promotion Details By SKUID
        /// </summary>
        /// <param name="SKUID">SKUID as integer</param>
        /// <returns></returns>
        PromotionDetails GetPromotionBySKU(int SKUID);
        /// <summary>
        /// Get All Promotional List
        /// </summary>
        /// <returns></returns>
        IList<PromotionDetails> GetAllPromotions();
    }
}
