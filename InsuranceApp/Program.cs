using System.Diagnostics;
using System;
using System.Globalization;

namespace InsuranceApp
{
    internal class Program
    {
        // Global Variables
        static List<string> MONTHS = new List<string>() { "1", "2", "3", "4", "5", "6" };


        static string WhenRun()
        {
            
            Console.WriteLine($"Here is the price of you EX2 devices before insurance before discount: {Pricing}");
            
            return "";
        }


        static string DeviceEx2()
        {

            string EX2;
            Console.WriteLine("Please enter how many EX2 devices you have. If you have none press <Enter>");
            EX2 = Console.ReadLine();

            Console.WriteLine($"How many EX2 devices you are wanting insured: {EX2}");
            return EX2;

        }

        static string DeviceAsus()
        {
            string Asus;
            Console.WriteLine("Please enter how many Asus devices you have. If you have none press <Enter>");
            Asus = Console.ReadLine();

            return Asus;
        }

        static string DeviceXp()
        {
            string Xp;
            Console.WriteLine("Please enter how many Xp devices you have. If you have none press <Enter>");
            Xp = Console.ReadLine();

            return Xp;
        }

        static string DeviceS23()
        {
            string S23;
            Console.WriteLine("Please enter how many S23 devices you have. If you have none press <Enter>");
            S23 = Console.ReadLine();

            return S23;
        }

        static float Pricing(string EX2, string Asus, string Xp, string S23)
        {
            
            
            int intEX2 = Int32.Parse(EX2);
            Console.WriteLine(intEX2);
            


            int intAsus = Int32.Parse(Asus);
            Console.WriteLine(intAsus);


            int intXp = Int32.Parse(Xp);
            Console.WriteLine(intXp);


            int intS23 = Int32.Parse(S23);
            Console.WriteLine(intS23);

            Console.WriteLine($"Here is how many EX2 devices you have: {intEX2}");
            return intEX2;
            
          




        }

        static string Checkbonus(string EX2)
        {
            
            if (DeviceEx2(EX2) > 5)
            {
                return BonusInsurance(EX2);
            }
            else
            {
                return NoBonusInsurance();
            }
        }

        private static int DeviceEx2(string eX2)
        {
            throw new NotImplementedException();
        }

        static string NoBonusInsurance()
        {
            return "";
        }

        static string BonusInsurance(string EX2)
        {
            string Bonus;
            Console.WriteLine((float)(DeviceEx2(EX2) - 5 / 10));
            Bonus = Console.ReadLine();
            return Bonus;


        }




        //When run
        static void Main(string[] args)
        {
            Console.WriteLine("  _____                                                                 \r\n |_   _|                                              /\\                \r\n   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___     /  \\   _ __  _ __  \r\n   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\   / /\\ \\ | '_ \\| '_ \\ \r\n  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/  / ____ \\| |_) | |_) |\r\n |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___| /_/    \\_\\ .__/| .__/ \r\n                                                           | |   | |    \r\n                                                           |_|   |_|   \n-------------------------------------------------------------------------\n ");

            DeviceEx2();
            DeviceAsus();
            DeviceXp();
            DeviceS23();
            WhenRun();

            

        }

    }
}

