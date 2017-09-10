using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Model.Models
{
    [Table("AgentLevels")]
    public class AgentLevel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string AgentID { set; get; }
        [ForeignKey("AgentID")]
        private Agent Agent { set; get; }

        public string Name { set; get; }

        [Required]
        public decimal? PriceFrom { set; get; }

        [Required]
        public decimal? PriceTo { set; get; }

        [Required,]
        public int Percent { set; get; }

        public DateTime? CreateDate { set; get; }

        [MaxLength(255)]
        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        [MaxLength(255)]
        public string UpdateBy { set; get; }

        public int? DisplayOrder { set; get; }
    }
}