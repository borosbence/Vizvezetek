using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VizvezetekAPI.Models
{
    public partial class szerelo
    {
        public szerelo()
        {
            munkalap = new HashSet<munkalap>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nev { get; set; }
        [Column(TypeName = "int(4)")]
        public int kezdes_ev { get; set; }

        [InverseProperty("szerelo")]
        public virtual ICollection<munkalap> munkalap { get; set; }
    }
}
