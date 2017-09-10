using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimOnline.Web.Models
{
    public class AppUserViewModel
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public DateTime BirthDay { set; get; }

        public string AgentID { set; get; }
        [ForeignKey("AgentID")]
        public virtual AgentViewModel Agent { set; get; }

        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }

        public string PhoneNumber { set; get; }

        public IEnumerable<AppGroupViewModel> Groups { set; get; }
    }
}