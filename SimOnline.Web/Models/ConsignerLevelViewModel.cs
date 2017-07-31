using System;

namespace SimOnline.Web.Models
{
    public class ConsignerLevelViewModel
    {
        public int ID { set; get; }

        public int ConsignerID { set; get; }

        private ConsignerViewModel Consigner { set; get; }

        public string Name { set; get; }

        public decimal? PriceFrom { set; get; }

        public decimal? PriceTo { set; get; }

        public int Percent { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public int? DisplayOrder { set; get; }
    }
}