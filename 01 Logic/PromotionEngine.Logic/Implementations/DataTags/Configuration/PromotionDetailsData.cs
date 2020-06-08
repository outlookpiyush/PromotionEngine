using Newtonsoft.Json;
using PromotionEngine.Logic.Entities.Configuration;
using PromotionEngine.Logic.Implementations.DataTag.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PromotionEngine.Logic.Implementations.DataTags.Configuration
{
    public class PromotionDetailsData : IPromotionDetailsData
    {
        /// <summary>
        /// Get Promotion
        /// </summary>
        /// <param name="SKUID">SKUID as integer value</param>
        /// <returns></returns>
        public PromotionDetails GetPromotionBySKU(int SKUID)
        {
            IList<PromotionDetails> promotionDetails = GetAllPromotions();
            return promotionDetails.Where(x => x.SKUID == SKUID).FirstOrDefault();
        }
        /// <summary>
        /// Get All Promotional Details List
        /// </summary>
        /// <returns></returns>
        public IList<PromotionDetails> GetAllPromotions()
        {
            string jsonText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JSONData\\SKUPromotion.json"));
            return JsonConvert.DeserializeObject<IList<PromotionDetails>>(jsonText).ToList();
        }
    }
}
