using System;

namespace VizvezetekAPI.DTOs
{
    public class MunkalapDto
    {
        public int id { get; set; }
        public DateTime beadas_datum { get; set; }
        public DateTime javitas_datum { get; set; }
        public string helyszin { get; set; }
        public string szerelo { get; set; }
        public int munkaora { get; set; }
        public int anyagar { get; set; }
    }
}
