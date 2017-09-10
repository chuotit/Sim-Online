using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Web.Models
{
    public class AgentLevelViewModel
    {
        public int ID { set; get; }

        public string AgentID { set; get; }
        [ForeignKey("AgentID")]
        private AgentViewModel Agent { set; get; }

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