using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimOnline.Model.Abstract;

namespace SimOnline.Model.Models
{
    [Table("SimNumbers")]
    public class SimNumber
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
        public int ConsignerID { set; get; }
        [ForeignKey("ConsignerID")]
        public virtual Consigner Consigner { set; get; }

        public int Discount { set; get; }

        [Required]
        public decimal Price { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}