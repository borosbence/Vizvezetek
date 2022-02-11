using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VizvezetekAPI.Models
{
    public partial class hely
    {
        public hely()
        {
            munkalap = new HashSet<munkalap>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string telepules { get; set; }
        [Required]
        [StringLength(75)]
        public string utca { get; set; }

        [InverseProperty("hely")]
        public virtual ICollection<munkalap> munkalap { get; set; }
    }
}
