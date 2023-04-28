using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace Övning_5
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
            #region Deklararar alla variabler
            int indexof = 0;
            int nummer = 0;
            int select = 0;
            int temp = 0;
            int antalbindesträck;
            char tempchar;
            string inmatat = "";
            string tempstring = "";
            List<string> språk1 = new List<string>();
            List<string> språk2 = new List<string>();
            List<string> felsvar = new List<string>();
            List<int> felsvarindex = new List<int>();
            int poäng = 0;
            Random rnd = new Random();
            Console.OutputEncoding = Encoding.UTF8;
            #endregion
            while (true)
            {
                #region Intro meny
                Console.WriteLine("Välkommen till Förhörningsprogramet\u2122 välj en av följande alternativ:");
                Console.WriteLine("-------------");
                Console.WriteLine("Lägg till glosor manuelt (1)");
                Console.WriteLine("Lägg till många glosor samtidigt (2)");
                Console.WriteLine("Testa dig (3)");
                Console.WriteLine("Kolla vilka glosor som är inskrivna (4)");
                Console.WriteLine("Byta plats på frågor och svar (5)");
                Console.WriteLine("Stäng av (6)");
                Console.WriteLine("------------");
                #endregion
                //kollar vad användaren har matat in och ifall det är en siffra
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    #region Lägger till glosor (1)
                    if (select == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in ett vad du vill få som fråga följt av svaret separerat med ett \"-\" ex blomma-flower");
                        Console.WriteLine("När du är klar skriv \"klar\"");
                        Console.WriteLine("Vill du ta bort alla glosor skriver du \"ta bort\"");
                        Console.WriteLine("------------");
                        #region Lägga till glosor
                        while (true)
                        {
                            Console.Write("Glosa " + (nummer + 1) + ":");
                            inmatat = Console.ReadLine();
                            antalbindesträck = 0;
                            //kollar antal bindesträck för att man inte ska kunna skriva fler än ett
                            foreach (char tecken in inmatat)
                            {
                                if (tecken == '-')
                                {
                                    antalbindesträck++;
                                }
                            }
                            if (inmatat == "klar")
                            {
                                break;
                            }
                            else if (inmatat == "ta bort")
                            {
                                språk1.Clear();
                                språk2.Clear();
                                nummer = 0;
                                Console.WriteLine("Alla glosor är borttagna");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Skriv in ett ord följt av ett andra separerat med ett \"-\" ex blomma-flower");
                                Console.WriteLine("När du är klar skriv \"klar\"");
                                Console.WriteLine("Vill du ta bort alla glosor skriver du \"ta bort\"");
                            }
                            else if (inmatat.ToLower().Contains("-") && antalbindesträck == 1)
                            {
                                #region Ta bort mellanslag innan och efter inskriven text samt separerar in i listorna
                                indexof = inmatat.IndexOf("-");
                                while (true)
                                {
                                    //tar bort alla mellanslag efter ordet innan bindesträcket
                                    while (true)
                                    {
                                        tempchar = inmatat[indexof - 1];
                                        if (tempchar != ' ')
                                        {

                                            break;
                                        }
                                        else
                                        {
                                            inmatat = inmatat.Remove(indexof - 1, 1);
                                            indexof = inmatat.IndexOf("-");
                                        }

                                    }
                                    //tar bort alla mellanslag innan ordet innan bindesträcket
                                    tempchar = inmatat[0];
                                    if (tempchar != ' ')
                                    {
                                        språk1.Add(inmatat.Remove(indexof));
                                        break;
                                    }
                                    else
                                    {
                                        inmatat = inmatat.Remove(0, 1);
                                        indexof = inmatat.IndexOf("-");
                                    }
                                }
                                while (true)
                                {
                                    //tar bort alla mellanslag efter ordet efter bindesträcket
                                    while (true)
                                    {
                                        tempchar = inmatat[inmatat.Length - 1];
                                        if (tempchar != ' ')
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            inmatat = inmatat.Remove(inmatat.Length - 1);
                                            indexof = inmatat.IndexOf("-");
                                        }
                                    }
                                    //tar bort alla mellanslag innan ordet efter binderstäcket
                                    tempchar = inmatat[indexof + 1];
                                    if (tempchar != ' ')
                                    {
                                        språk2.Add(inmatat.Remove(0, indexof + 1));
                                        break;
                                    }
                                    else
                                    {
                                        inmatat = inmatat.Remove(indexof + 1, 1);
                                        indexof = inmatat.IndexOf("-");
                                    }
                                }
                                #endregion
                                nummer++;
                            }
                            else
                            {
                                Console.WriteLine("Du har formaterat fel gör om gör rätt");
                            }

                        }
                        #endregion
                        Console.Clear();
                    }
                    #endregion
                    #region Lägget till glosor mindre manulet (2)
                    else if (select == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Kopiera in alla dina glosor i formatet \"blomma-flower|göra-do|hålla-hold\"");
                        Console.WriteLine("Var noga med att formatet korrekt eftersom denna kod är känsligare än manuella koden");
                        Console.WriteLine("Vill du gå tillbaks kan du skriva \"\"");
                        Console.WriteLine("------------");
                        Console.Write("här: ");
                        inmatat = Console.ReadLine();

                        if (inmatat != "klar")
                        {
                            nummer = 0;
                            while (true)
                            {
                                if (inmatat.Contains('|'))
                                {
                                    indexof = inmatat.IndexOf('|');
                                    tempstring = inmatat.Remove(indexof);
                                    inmatat = inmatat.Remove(0, indexof + 1);
                                    indexof = tempstring.IndexOf('-');
                                    språk1.Add(tempstring.Remove(indexof));
                                    språk2.Add(tempstring.Remove(0, indexof + 1));
                                }
                                else if (inmatat != "")
                                {
                                    tempstring = inmatat;
                                    indexof = tempstring.IndexOf('-');
                                    språk1.Add(tempstring.Remove(indexof));
                                    språk2.Add(tempstring.Remove(0, indexof + 1));
                                    break;
                                }
                            }
                        }
                        Console.Clear();
                    }
                    #endregion
                    #region Testet (3)
                    else if (select == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Testet");
                        Console.WriteLine("------------");
                        poäng = 0;
                        temp = rnd.Next(0, 101);
                        Shuffle(språk1, temp);
                        Shuffle(språk2, temp);
                        for (int i = 0; i < språk1.Count; i++)
                        {

                            Console.Write(språk1[i] + ": ");
                            inmatat = Console.ReadLine();
                            if (inmatat == språk2[i])
                            {
                                poäng++;
                            }
                            else
                            {
                                felsvar.Add(inmatat);
                                felsvarindex.Add(i);
                            }

                        }
                        Console.WriteLine("Du fick " + poäng + "/" + språk1.Count);
                        if (felsvar.Count > 0)
                        {
                            for (int i = 0; i < felsvar.Count; i++)
                            {
                                Console.Write("Fel " + (i + 1) + ": ");
                                Console.WriteLine($"Du skrev {felsvar[i]} istället för {språk2[felsvarindex[i]]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du skrev alla rätt! Hurra!");
                        }
                        felsvar.Clear();
                        felsvarindex.Clear();
                        Console.ReadLine();
                        Console.Clear();
                    }
                    #endregion
                    #region Skriver ut glororna som matats in (4)
                    else if (select == 4)
                    {
                        Console.Clear();
                        if (språk1.Count > 0)
                        {
                            Console.WriteLine("Här kommer en lista på alla glosorna(klicka enter för att gå vidare):");
                            Console.WriteLine("------------");
                            for (int i = 0; i < språk1.Count; i++)
                            {
                                Console.WriteLine($"{språk1[i]}-{språk2[i]}");
                            }
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Du har inte lagt till några glosor än(klicka enter för att gå vidare)");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                    #endregion
                    #region Byter plats på frågor och svar (5)
                    else if (select == 5)
                    {
                        //byter plats på allt skit
                        for (int i = 0; i < språk1.Count; i++)
                        {
                            tempstring = språk1[i];
                            språk1[i] = språk2[i];
                            språk2[i] = tempstring;
                        }
                        tempstring = "";
                        //enbart visuell laddningskärm för att det är kul
                        for (int i = 0; i < 15; i++)
                        {
                            tempstring += "&";
                            Console.Clear();
                            Console.WriteLine(tempstring);
                            Thread.Sleep(50);
                            tempstring = tempstring.Remove(tempstring.Length - 1, 1);
                            tempstring += "%";
                            Console.Clear();
                            Console.WriteLine(tempstring);
                            Thread.Sleep(50);
                            tempstring = tempstring.Remove(tempstring.Length - 1, 1);
                            tempstring += "#";
                            Console.Clear();
                            Console.WriteLine(tempstring);
                            Thread.Sleep(50);
                        }
                        Console.Clear();
                        Console.WriteLine("Klar!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    #endregion
                    #region Avslutar programet (6)
                    else if (select == 6)
                    {
                        break;
                    }
                    #endregion
                    //felhantering
                    else
                    {
                        Console.WriteLine("Skriv ett nummer mellan 1 och 5 (kringe)");
                    }
                }
                //felhantering
                else
                {
                    Console.WriteLine("Vänligen skriv ett nummer");
                }
            }


        }
    }
}
