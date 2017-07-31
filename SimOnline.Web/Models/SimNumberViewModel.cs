using System;

namespace SimOnline.Web.Models
{
    public class SimNumberViewModel
    {
        public string SimID { set; get; }

        public string SimName { set; get; }

        public int NetWorkID { set; get; }
        public virtual SimNetworkViewModel SimNetwork { set; get; }

        public int ConsignerID { set; get; }
        public virtual ConsignerViewModel Consigner { set; get; }

        public int Discount { set; get; }

        public decimal Price { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}