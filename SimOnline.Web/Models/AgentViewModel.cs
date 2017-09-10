using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimOnline.Web.Models
{
    public class AgentViewModel
    {
        public string AgentId { set; get; }

        [Display(Name="Tên đại lý")]
        public string Name { set; get; }


        public string AgentCode { set; get; }

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

        public virtual IEnumerable<AgentLevelViewModel> AgentLevels { set; get; }

        public virtual IEnumerable<AppUserViewModel> AppUsers { set; get; }

        public virtual IEnumerable<SimStoreViewModel> SimStores { set; get; }
    }
}