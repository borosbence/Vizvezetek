using System;
using System.Collections.Generic;
using Vizvezetek.DTO;

namespace Vizvezetek.Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MunkalapRepository repo = new MunkalapRepository();
            List<MunkalapDto> munkalapok = new List<MunkalapDto>();
            //munkalapok = repo.GetAll().Result;

            //foreach (var munkalap in munkalapok)
            //{
            //    Console.WriteLine(munkalap);
            //}

            Console.WriteLine("Munkalap keresése...");
            Console.WriteLine("Kérem adjon meg egy munkalap azonosítót:");
            int sorszam = Convert.ToInt32(Console.ReadLine());
            MunkalapDto munkalapDto = repo.GetById(sorszam).Result;
            if (munkalapDto != null)
            {
                Console.WriteLine(munkalapDto);
            }
            else
            {
                Console.WriteLine("Nincs találat!");
            }

            Console.WriteLine("\nMunkalapok keresése...");
            Console.WriteLine("Kérem adjon meg egy szerelő nevet:"); // Tornyos Pál
            string szerelo = Console.ReadLine();
            Console.WriteLine("Kérem adjon meg egy település nevet:"); // Kőváros
            string helyszin = Console.ReadLine();

            MunkalapKeresesDto munkalapKereses = new MunkalapKeresesDto(szerelo,helyszin);
            munkalapok = repo.GetAll(munkalapKereses).Result;

            if (munkalapok != null)
            {
                foreach (var munkalap in munkalapok)
                {
                    Console.WriteLine(munkalap + "\n");
                }
            }
            else
            {
                Console.WriteLine("Nincs találat!");
            }

            Console.ReadKey();
        }
    }
}
