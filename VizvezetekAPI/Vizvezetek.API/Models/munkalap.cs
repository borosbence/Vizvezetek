using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Vizvezetek.API.Models
{
    [Index(nameof(hely_id), Name = "hely_id")]
    [Index(nameof(szerelo_id), Name = "szerelo_id")]
    public partial class munkalap
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "date")]
        public DateTime beadas_datum { get; set; }
        [Column(TypeName = "date")]
        public DateTime javitas_datum { get; set; }
        [Column(TypeName = "int(11)")]
        public int hely_id { get; set; }
        [Column(TypeName = "int(11)")]
        public int szerelo_id { get; set; }
        [Column(TypeName = "int(11)")]
        public int munkaora { get; set; }
        [Column(TypeName = "int(11)")]
        public int anyagar { get; set; }

        [ForeignKey(nameof(hely_id))]
        [InverseProperty("munkalap")]
        public virtual hely hely { get; set; }
        [ForeignKey(nameof(szerelo_id))]
        [InverseProperty("munkalap")]
        public virtual szerelo szerelo { get; set; }
    }
}
