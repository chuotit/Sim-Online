using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Web.Models
{
    public class SimStoreViewModel
    {
        public string SimID { set; get; }

        public string SimName { set; get; }

        public int NetWorkID { set; get; }
        public virtual SimNetworkViewModel SimNetwork { set; get; }

        public string AgentID { set; get; }
        [ForeignKey("AgentID")]
        public virtual AgentViewModel Agent { set; get; }

        public int Discount { set; get; }

        public decimal Price { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}