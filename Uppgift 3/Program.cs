using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3
{
    class Program
    {
        public static void Shuffle<T>(IList<T> list, int seed)
        {
            var rng = new Random(seed);
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        static void Main(string[] args)
        {
            
            List<string> kortlek = new List<string>();
            Random rnd = new Random();
            int siffra;
            #region Lägga till kort
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("h" + i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("k" + i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("s" + i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("r" + i);
            }
            kortlek.Add("hE");
            kortlek.Add("hKn");
            kortlek.Add("hD");
            kortlek.Add("hK");
            kortlek.Add("kE");
            kortlek.Add("kKn");
            kortlek.Add("kD");
            kortlek.Add("kK");
            kortlek.Add("sE");
            kortlek.Add("sKn");
            kortlek.Add("sD");
            kortlek.Add("sK");
            kortlek.Add("rE");
            kortlek.Add("rKn");
            kortlek.Add("rD");
            kortlek.Add("rK");
            kortlek.Sort();
            #endregion

            Shuffle(kortlek, 100);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(kortlek[i]);
            }
        }
    }
}
