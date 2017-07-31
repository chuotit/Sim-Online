using System;
using System.Collections.Generic;

namespace SimOnline.Web.Models
{
    public class ConsignerViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string ConsignerCode { set; get; }

        public string Website { set; get; }

        public string Email { set; get; }

        public string Hotline { set; get; }

        public string Address { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }

        public virtual IEnumerable<ConsignerLevelViewModel> ConsignerLevels { set; get; }

        public virtual IEnumerable<SimNumberViewModel> SimNumbers { set; get; }
    }
}