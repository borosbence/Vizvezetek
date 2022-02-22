namespace Vizvezetek.DTO
{
    public class MunkalapKeresesDto
    {
        public MunkalapKeresesDto(string szerelo, string telepules)
        {
            this.szerelo = szerelo;
            this.telepules = telepules;
        }
        public string szerelo { get; set; }

        public string telepules { get; set; }
    }
}
