using System.Collections.Generic;
using PromotionEngine.Logic.Entities.Configuration;

namespace PromotionEngine.Logic.Implementations.DataTag.Configuration
{
    /// <summary>
    /// Define SKU Data Interface
    /// </summary>
    interface ISKUDetailsData
    {
        /// <summary>
        /// Get SKU By ID
        /// </summary>
        /// <param name="skuID">skuID as integer</param>
        /// <returns></returns>
        SKUDetails GetSKUByID(int skuID);
        /// <summary>
        /// Get SKU By Name
        /// </summary>
        /// <param name="skuName">skuName as string</param>
        /// <returns></returns>
        SKUDetails GetSKUByName(string skuName);
        /// <summary>
        /// Get All SKU Details
        /// </summary>
        /// <returns></returns>
        IList<SKUDetails> GetAllSKU();
    }
}
