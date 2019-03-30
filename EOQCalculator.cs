using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuRzAsg4 
{
    public class EOQCalculator
    {

        public static bool Valid(string s)
        {
            double number;
            if (!Double.TryParse(s, out number)) return false;
            if ((number < 0) || (number == 0)) return false;
            else return true;
        }

        public static bool ValidRD(string s)//judge the coffee is regular or decaf or illeagl
        {
            if (s.ToLower().Equals("r")|| s.ToLower().Equals("d")) return true;
            else 
            return false;
        }

        public static bool ValidDensity(string s)
        {
            if (s.ToLower().Equals("0")|| s.ToLower().Equals("1")|| s.ToLower().Equals("2")) return true;
            else
            return false;
        }

        public static int Pos(double num)
        {
            if ((num < 0) || (num == 0)) return 0;
            else return 1;
        }

        public static void PrintTableHead()
        {
            
            Console.WriteLine("Brand        C($)   Demand   Detail Q(lbs)    Tac($)  "); 
        }

         
        static void Main(String[] args)
        {

            Coffee[] aCoffee = new Coffee[2];
          

            while (1 < 2)
            {
                //Title
                if (Coffee.ccount == 0) Console.WriteLine("Welcome to the EOQ Calculator prepared by Ruize Xu");
                Console.WriteLine("Enter q to quit or the name of the coffee");
                //brand
                string brand = Console.ReadLine();
                if (brand.Equals("q")) break;

                //initialize all variables, for checking if user has typed in something 
                double d = 0; double c = 0;  string rd = ""; string Density = ""; double minQ = 0;

                //ask D
                while (Pos(d) == 0)
                {
                    Console.WriteLine("Please enter the Demand:");
                    String stringD = Console.ReadLine();
                    if (!(Valid(stringD)))
                        Console.WriteLine("Invalid number, please try again.");
                    else d = Convert.ToDouble(stringD);     
                }
                 
                //ask C
                while (Pos(c) == 0)
                {
                    Console.WriteLine("Please enter the unit cost:");
                    String stringC =  Console.ReadLine();
                    if (!(Valid(stringC)))
                        Console.WriteLine("Invalid enter, please try again.");
                    else c = Convert.ToDouble(stringC);
                }

                while (!ValidRD(rd))
                {
                    Console.WriteLine("Is it regularor or decaf? Please enter 'r' if it is a regular coffee or enter 'd' if it is a decaf coffee:");
                    rd = Console.ReadLine();
                    if (!(ValidRD(rd)))
                        Console.WriteLine("Invalid enter, please try again.");
                    else break;
                }

                if (rd.ToLower().Equals("r"))
                {
                    while (!(ValidDensity(Density)))
                    {
                        Console.WriteLine("Is it light, medium or dark? Enter '0' for light, '1' for medium, '2' for dark");
                        Density = Console.ReadLine();
                        if (!(ValidDensity(Density)))
                            Console.WriteLine("Invalid enter, please try again.");
                        else
                        {
                            Regular newRegular = new Regular(brand, d, c, Convert.ToDouble(Density));
                            if (aCoffee.Length == Coffee.ccount + 1)
                                Array.Resize(ref aCoffee, aCoffee.Length + 2);
                            aCoffee[Coffee.ccount - 1] = newRegular;
                            break;
                        }
                    }
                }

                else
                {
                    while (Pos(minQ) == 0)
                    {
                        Console.WriteLine("Please enter the minimum quantity: ");
                        string stminQ = Console.ReadLine();
                        if (!(Valid(stminQ)))
                            Console.WriteLine("Invalid enter, please try again.");
                        else
                        {
                            minQ = Convert.ToDouble(stminQ);
                            Decaf newDecaf = new Decaf(brand, d, c, minQ);
                            if (aCoffee.Length == Coffee.ccount + 1)
                                Array.Resize(ref aCoffee, aCoffee.Length + 2);
                            aCoffee[Coffee.ccount - 1] = newDecaf;                     
                            break;
                        }
                    }
                }                            
            }

                //print the result
                PrintTableHead();
            
                for (int i = 0; i <= Coffee.ccount - 1; i++)//category should decrease 1 due to the last time of inputing coffee increase category by 1
                {
                    Console.WriteLine(aCoffee[i].toString());
                }

            Console.WriteLine("If you purchase all of the coffee you will need space to hold " + Math.Round(Coffee.wcount, 2) + " lbs. of coffee");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
