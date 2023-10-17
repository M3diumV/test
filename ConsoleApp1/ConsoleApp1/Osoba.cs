using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace zlota_mysl
{
    internal class mysliKlasa
    {
        List<string> mysli = new List<string>();
        string input;
        int selector;
        Random rand = new Random();
        int index;

        public mysliKlasa()
        {
            mysli.Add("Wojna to pokój.");
            mysli.Add("Wolność to niewola.");
            mysli.Add("Ignorancja to siła");
        }

        public void showMenu()
        {
            Console.Clear();
            Console.Write("\nWitaj, wybierz opcję:" +
            "\n1.Dodaj myśl" +
            "\n2.Edytuj myśl" +
            "\n3.Usuń myśl" +
            "\n4.Zamknij program" +
            "\n5.Pokaż złote myśli" +
            "\n6.Pokaż losową myśl" +
            "\nWybierz: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out _))
            {
                selector = Convert.ToInt32(input);
                switch (selector)
                {
                    case 1:
                        Console.Clear();
                        addMysl();
                        break;
                    case 2:
                        Console.Clear();
                        editMysl();
                        break;
                    case 3:
                        Console.Clear();
                        removeMysl();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wychodzenie...");
                        Thread.Sleep(1000);
                        Environment.Exit(1);
                        break;
                    case 5:
                        Console.Clear();
                        showMysli();
                        Console.WriteLine("\n\nNapisz \"ok\" by wyjść: ");
                        string exit = Convert.ToString(Console.ReadLine());

                        for (; ; )
                        {
                            if (exit == "ok")
                            {
                                showMenu();
                            }
                            else
                            {

                                showMysli();
                            }
                        }
                        break;

                    case 6:
                        Console.Clear();
                        randomMysl();
                        Thread.Sleep(2000);
                        showMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine(mysli.Last());
                        showMenu();
                        break;
                }

            }

            else
            {
                Console.WriteLine("Zły wybór!");
                showMenu();
            }
        }

        public void addMysl()
        {
            Console.Write("\nNapisz myśl do dodania: ");
            input = Console.ReadLine();
            mysli.Add(input);
            showMenu();
        }
        public void editMysl()
        {
            Console.WriteLine("\nLista złotych myśli:");
            showMysli();
            Console.Write("\nWybierz myśl do edycji:");
            input = Console.ReadLine();
            selector = Convert.ToInt32(input);

            Console.Write("\nWpisz edytowaną myśl:");
            input = Console.ReadLine();
            mysli[selector] = input;
            showMenu();

        }
        public void removeMysl()
        {
            Console.WriteLine("\nLista złotych myśli:");
            showMysli();
            Console.Write("\nWybierz myśl do usunięcia:");
            input = Console.ReadLine();
            selector = Convert.ToInt32(input);
            mysli.RemoveAt(selector);
            showMenu();
        }
        public void showMysli()
        {
            for (int i = 0; i < mysli.Count; i++)
            {
                Console.WriteLine(i + ". " + mysli[i]);
            }
            Console.WriteLine();
        }

        public void randomMysl()
        {
            Console.WriteLine();
            index = rand.Next(0, mysli.Count);
            string myslText = mysli[index];
            Console.WriteLine(myslText);
        }
    }
}
