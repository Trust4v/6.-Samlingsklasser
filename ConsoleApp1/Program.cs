using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nummer = new List<int>();
            int temp;
            double medelvärde = 0;
            Console.WriteLine("Skriv in tal tills du är nöjd och skriv sen in \"0\"");
            while (true)
            {
                temp = int.Parse(Console.ReadLine());
                if (temp != 0)
                {
                    nummer.Add(temp);
                }
                else
                {
                    break;
                }
            }
            foreach (int element in nummer)
            {
                medelvärde += element;
            }
            medelvärde /= nummer.Count;
            Console.WriteLine("Medelvärdet på alla talen är " + medelvärde);
        }
    }
}
