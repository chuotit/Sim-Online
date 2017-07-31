using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimOnline.Model.Models
{
    [Table("Consigners")]
    public class Consigner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required, MaxLength(40), Column(TypeName = "varchar")]
        public string ConsignerCode { set; get; }

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

        public virtual IEnumerable<ConsignerLevel> ConsignerLevels { set; get; }

        public virtual IEnumerable<SimNumber> SimNumbers { set; get; }
    }
}