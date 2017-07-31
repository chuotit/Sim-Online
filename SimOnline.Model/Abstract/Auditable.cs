using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimOnline.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        [MaxLength(255)]
        public string MetaDescription { set; get; }

        [MaxLength(255)]
        public string MetaKeyword { set; get; }

        public DateTime? CreateDate { set; get; }

        [MaxLength(255)]
        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        [MaxLength(255)]
        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}
