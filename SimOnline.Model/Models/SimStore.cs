using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimOnline.Model.Abstract;

namespace SimOnline.Model.Models
{
    [Table("SimStores")]
    public class SimStore
    {
        [Key, Required, Column(TypeName = "varchar"), MaxLength(11), MinLength(10)]
        public string SimID { set; get; }

        [Required, Column(TypeName = "varchar"), MaxLength(25)]
        public string SimName { set; get; }

        [Required]
        public int NetWorkID { set; get; }
        [ForeignKey("NetWorkID")]
        public virtual SimNetwork SimNetwork { set; get; }
        
        [Required]
        public string AgentID { set; get; }
        [ForeignKey("AgentID")]
        public virtual Agent Agent { set; get; }

        public int Discount { set; get; }

        [Required]
        public decimal Price { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}