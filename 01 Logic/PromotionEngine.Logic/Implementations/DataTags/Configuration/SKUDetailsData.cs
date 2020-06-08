using Newtonsoft.Json;
using PromotionEngine.Logic.Entities.Configuration;
using PromotionEngine.Logic.Implementations.DataTag.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PromotionEngine.Logic.Implementations.DataTags.Configuration
{
    /// <summary>
    /// SKU Details Class
    /// </summary>
    public class SKUDetailsData : ISKUDetailsData
    {
        /// <summary>
        /// Get All SKU List By ID
        /// </summary>
        /// <param name="skuID">skuID as integer</param>
        /// <returns></returns>
        public SKUDetails GetSKUByID(int skuID)
        {
            IList<SKUDetails> SKUList = GetAllSKU();
            return SKUList.Where(x => x.SKUID == skuID).FirstOrDefault();
        }
        /// <summary>
        /// Get All SKU By Name
        /// </summary>
        /// <param name="skuName">skuName as string</param>
        /// <returns></returns>
        public SKUDetails GetSKUByName(string skuName)
        {
            IList<SKUDetails> SKUList = GetAllSKU();
            return SKUList.Where(x => x.SKU.ToUpper().Equals(skuName.ToUpper())).FirstOrDefault();
        }
        /// <summary>
        /// Get All SKU List
        /// </summary>
        /// <returns></returns>
        public IList<SKUDetails> GetAllSKU()
        {
            string jsonText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JSONData\\SKUDetails.json"));
            return JsonConvert.DeserializeObject<IList<SKUDetails>>(jsonText).ToList();
        }
    }
}
