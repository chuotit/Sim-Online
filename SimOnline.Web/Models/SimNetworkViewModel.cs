using System;
using System.Collections.Generic;

namespace SimOnline.Web.Models
{
    public class SimNetworkViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public string Image { set; get; }

        public string Description { set; get; }

        public bool HomeFlag { set; get; }

        public virtual IEnumerable<FirstNumberViewModel> FirstNumbers { set; get; }

        public virtual IEnumerable<SimStoreViewModel> SimStores { set; get; }

        public string MetaDescription { set; get; }

        public string MetaKeyword { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}