using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleApp
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("******Menu******");
            Console.WriteLine("1) Vis biler på lager");
            Console.WriteLine("2) Vis biler i indkøbskurven");
            Console.WriteLine("3) Gå til kassen(Checkout)");
            Console.WriteLine("4) Afslut");
            Console.WriteLine("****************");
        }
        static void Main(string[] args)
        {
            Store store = new Store();
            Console.WriteLine("Start med at tilføj tre biler til lagerbeholdningen.");
            Console.WriteLine("F.eks. ved at skrive Toyota, Yaris, Blue, 10000\n");
            while (true)
            {
                Console.WriteLine("Indtast bilmærke: ");
                string cBrand = Console.ReadLine();
                Console.WriteLine("Indtast model: ");
                string cModel = Console.ReadLine();
                Console.WriteLine("Indtast farve: ");
                string cColor = Console.ReadLine();
                Console.WriteLine("Indtast pris: ");
                int cprice = Convert.ToInt32(Console.ReadLine());
                Car car = new Car(cBrand, cModel, cColor, cprice);
                store.AddToStore(car);
                Console.WriteLine("Ny bil tilføjet til lagerbeholdningen.");
                Console.WriteLine("Tast enter for at tilføje endnu en bil eller tast q for at afslutte indtastningen...");
                char ch = Console.ReadKey().KeyChar;
                if (ch == 'q')
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
            while (true)
            {
                Console.Clear();
                ShowMenu();
                Console.WriteLine("\nIndtast et nummer fra menuen og tast enter: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    store.ShowStore();
                    Console.WriteLine("\nIndtast nummeret på en bil og tast enter for at putte den i indkøbskurven:");
                    Console.WriteLine("\nHvis du taster enter uden at taste et nummer, så vender du tilbage til hovedmeuen,");
                    Console.WriteLine("uden at have puttet nogen varer i kurven.");
                    string num = Console.ReadLine();
                    try
                    {
                        int value = Convert.ToInt32(num);
                        store.AddToCart(value);
                    }
                    catch (FormatException)
                    {
                    }
                }
                if (choice == "2")
                {
                    Console.Clear();
                    store.ShowCart();
                    Console.WriteLine("\nTast enter for at gå tilbage til hovedmenuen...");
                    Console.ReadKey();
                }
                if (choice == "3")
                {
                    Console.Clear();
                    store.CheckOut();
                    Console.ReadKey();
                    break;
                }
                if (choice == "4")
                {
                    break;
                }
            }
        }
    }

    class Car
    {
        public string brand, model, color;
        public int price;

        public Car(string a, string b, string c, int d) //constructor
        {
            brand = a;
            model = b;
            color = c;
            price = d;
        }

    }

    class Store
    {
        List<Car> stock = new List<Car>();
        List<Car> cart = new List<Car>();

        public void AddToStore(Car newcar)
        {
            Console.Clear();
            stock.Add(newcar);
        }

        public void ShowStore()
        {
            Console.Clear();
            Console.WriteLine("Antal biler på lager: " + stock.Count + "\n");
            for (int x = 0; x < stock.Count; x++)
            {
                Console.WriteLine("Bil nr. " + (x + 1));
                Console.WriteLine("Bilmærke: " + stock[x].brand);
                Console.WriteLine("Model: " + stock[x].model);
                Console.WriteLine("Farve: " + stock[x].color);
                Console.WriteLine("Pris: " + stock[x].price);
                Console.WriteLine("------------");
            }
        }
        public void AddToCart(int x)
        {
            cart.Add(stock[x - 1]);
        }

        public void ShowCart()
        {
            Console.WriteLine("Her vises indkøbskurven.\n");
            for (int x = 0; x < cart.Count; x++)
            {
                Console.WriteLine("Bilmærke: " + cart[x].brand);
                Console.WriteLine("Model: " + cart[x].model);
                Console.WriteLine("Farve: " + cart[x].color);
                Console.WriteLine("Pris: " + cart[x].price);
                Console.WriteLine("------------");
            }
        }
        public void CheckOut()
        {
            int totalPrice = 0, c = 0;
            for (int x = 0; x < cart.Count; x++)
            {
                totalPrice += cart[x].price;
                c++;
            }
            Console.WriteLine("Samlet pris for " + c + " bil(er) = " + totalPrice + " kr.");
            Console.WriteLine("\nTast enter for at afslutte!");
        }
    }
}