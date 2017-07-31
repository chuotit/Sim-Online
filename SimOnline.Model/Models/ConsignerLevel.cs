using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Model.Models
{
    [Table("ConsignerLevels")]
    public class ConsignerLevel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ConsignerID { set; get; }

        [ForeignKey("ConsignerID")]
        private Consigner Consigner { set; get; }

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