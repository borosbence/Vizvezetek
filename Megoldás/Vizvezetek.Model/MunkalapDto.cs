using System;

namespace Vizvezetek.DTO
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

        public override string ToString()
        {
            return $"Azonosító: {id}\n" +
                $"Beadás dátuma: {beadas_datum.ToString("d")}\n" +
                $"Javítás dátuma: {javitas_datum.ToString("d")}\n" +
                $"Helyszín: {helyszin}\n" +
                $"Szerelő: {szerelo}\n" +
                $"Munkaóra: {munkaora}\n" +
                $"Anyagár: {anyagar}";
        }
    }
}
