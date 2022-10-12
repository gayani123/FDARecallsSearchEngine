using FDARecallsSearchEngine.Business;
using FDARecallsSearchEngine.Common.Interfaces;
using FDARecallsSearchEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDARecallsSearchEngine
{
    public class RecallItemModel
    {
        //public string report_date { get; set; }
        public string Classification { get; set; }
        public string Country { get; set; }
        public string ClassificationDate { get; set; }
        public string ProductDescription { get; set; }
        public string ReasonForRecall { get; set; }
        //public RecallItem recallItem { get; set; }

    }
} 
