using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimOnline.Model.Abstract;

namespace SimOnline.Model.Models
{
    [Table("FirstNumbers")]
    public class FirstNumber : Auditable
    {
        [Key, Required, Column(TypeName = "varchar"), MaxLength(4), MinLength(3)]
        public string FirstNumberID { set; get; }

        [Required]
        public int NetworkID { set; get; }
        [ForeignKey("NetworkID")]
        public virtual SimNetwork SimNetwork { set; get; }
        
        [Required, MaxLength(255)]
        public string FirstNumberName { set; get; }

        [Column(TypeName = "ntext")]
        public string Description { set; get; }

        [Required, Column(TypeName = "varchar"), MaxLength(255)]
        public string Alias { set; get; }

        [Required]
        public Boolean HomeFlag { set; get; }

        public virtual IEnumerable<SimStore> SimStores { set; get; }
    }
}