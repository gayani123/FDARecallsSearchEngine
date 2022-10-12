using FDARecallsSearchEngine.Business;
using FDARecallsSearchEngine.Common.Interfaces;
using FDARecallsSearchEngine.Common;
using FDARecallsSearchEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDARecallsSearchEngine
{
    public class RecallItemFinder
    {
        IRecallItemBusiness recallItemBusiness;

        public RecallItemFinder()
        {
            recallItemBusiness = new RecallItemBusiness();
        }


        public List<RecallItemModel> GetRecallItems(string period)
        {
            var recallItemModels = new List<RecallItemModel>();

            var response = recallItemBusiness.GetRecallItems(period);

            if (response.Result != null)
            {
                foreach (var item in response.Result)
                {
                    var recallItem = new RecallItemModel();
                    //string classificationDate = string.Format(item.CenterClassificationDate, "yyyy/MM/dd");

                    recallItem.Classification = item.Classification;
                    recallItem.ClassificationDate = item.CenterClassificationDate;
                    recallItem.Country = item.Country;
                    recallItem.ProductDescription = item.ProductDescription;
                    recallItem.ReasonForRecall = item.ReasonForRecall;
                    recallItemModels.Add(recallItem);

                    
                    
                }

            }

            return recallItemModels;
        }
    }
}
