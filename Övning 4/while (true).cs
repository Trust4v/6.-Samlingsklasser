using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kortlek = new Dictionary<string, int>();
            Random rnd = new Random();
            int siffra;
            int last;
            #region Lägga till kort
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("h" + i, i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("k" + i, i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("s" + i, i);
            }
            for (int i = 2; i < 11; i++)
            {
                kortlek.Add("r" + i, i);
            }
            kortlek.Add("hE", 1);
            kortlek.Add("kE", 1);
            kortlek.Add("sE", 1);
            kortlek.Add("rE", 1);
            kortlek.Add("hKn", 11);
            kortlek.Add("kKn", 11);
            kortlek.Add("rKn", 11);
            kortlek.Add("sKn", 11);
            kortlek.Add("hD", 12);
            kortlek.Add("kD", 12);
            kortlek.Add("sD", 12);
            kortlek.Add("rD", 12);
            kortlek.Add("hK", 13);  
            kortlek.Add("kK", 13);
            kortlek.Add("sK", 13);
            kortlek.Add("rK", 13);
            #endregion

            while (true)
            {
                if (kortlek.Count > 0)
                {
                    siffra = rnd.Next(0, kortlek.Count);                    
                    
                }
                else
                {
                    break;
                }
            }
        }
    }
}
