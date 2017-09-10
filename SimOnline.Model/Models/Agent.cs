using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Model.Models
{
    [Table("Agents")]
    public class Agent
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, MaxLength(128)]
        public string AgentId { set; get; }

        [Required]
        public string Name { set; get; }

        [MaxLength(40), DataType("varchar")]
        public string AgentCode { set; get; }

        [MaxLength(255)]
        public string Website { set; get; }

        [MaxLength(255)]
        public string Email { set; get; }

        [MaxLength(255)]
        public string Hotline { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        public DateTime? CreateDate { set; get; }

        [MaxLength(255)]
        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        [MaxLength(255)]
        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }

        public virtual IEnumerable<AgentLevel> AgentLevels { set; get; }

        public virtual IEnumerable<AppUser> AppUsers { set; get; }

        public virtual IEnumerable<SimStore> SimStores { set; get; }
    }
}