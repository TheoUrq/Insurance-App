using System;
using System.Collections.Generic;
using System.Globalization;

namespace InsuranceApp
{
    class Program
    {
        // Global Variables
        static List<string> deviceNames = new List<string>();
        static List<decimal> insuranceCosts = new List<decimal>();
        static List<string> categoryNames = new List<string>();

        static void CollectDeviceDetails()
        {
            Console.WriteLine("Enter how many different devices you want to insure:");
            int numberOfDevices;
            while (!int.TryParse(Console.ReadLine(), out numberOfDevices) || numberOfDevices <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Please enter a positive integer.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 1; i <= numberOfDevices; i++)
            {
                ProcessDevice(i);
            }
        }

        static void ProcessDevice(int deviceNumber)
        {
            // Determine order (first, second, third, etc.)
            string order;
            switch (deviceNumber)
            {
                case 1: order = "first"; break;
                case 2: order = "second"; break;
                case 3: order = "third"; break;
                default: order = deviceNumber + "th"; break;
            }

            // Device name
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string deviceName;
            while (true)
            {
                Console.WriteLine($"Enter your {order} device name:");
                deviceName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(deviceName))
                {
                    deviceName = textInfo.ToTitleCase(deviceName.ToLower());
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Please enter a device name.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Quantity
            int quantity;
            while (true)
            {
                Console.WriteLine("How many of these devices do you want to insure?");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: You must enter a positive integer.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Cost per device
            decimal cost;
            while (true)
            {
                Console.WriteLine("How much is each device worth?");
                if (decimal.TryParse(Console.ReadLine(), out cost) && cost > 0)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: You must enter a positive decimal value.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            decimal totalCost = CalculateInsuranceCost(quantity, cost);
            Console.WriteLine($"{deviceName} total insurance cost: ${totalCost:F2}");
            ValueLoss(cost);

            // Category with loop
            int category;
            while (true)
            {
                Console.WriteLine("Enter the category (1 = Laptop, 2 = Desktop, 3 = Other):");
                if (int.TryParse(Console.ReadLine(), out category) && category >= 1 && category <= 3)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Please enter an integer between 1 and 3.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            string categoryName = GetCategoryName(category);
            Console.WriteLine("CATEGORY: " + categoryName);

            // Store summary data
            deviceNames.Add(deviceName);
            insuranceCosts.Add(totalCost);
            categoryNames.Add(categoryName);
        }

        static decimal CalculateInsuranceCost(int numberOfDevices, decimal costPerDevice)
        {
            if (numberOfDevices <= 5)
                return numberOfDevices * costPerDevice;
            decimal costFirstFive = 5 * costPerDevice;
            decimal costRemaining = (numberOfDevices - 5) * costPerDevice * 0.9m;
            return costFirstFive + costRemaining;
        }

        static void ValueLoss(decimal startingValue)
        {
            Console.WriteLine("Month Value Loss");
            decimal currentValue = startingValue;
            for (int month = 1; month <= 6; month++)
            {
                currentValue *= 0.95m;
                Console.WriteLine($"{month} {Math.Round(currentValue, 2)}");
            }
        }

        // Change category number to name 
        static string GetCategoryName(int category)
        {
            return category switch
            {
                1 => "Laptop",
                2 => "Desktop",
                3 => "Other",
                _ => "ERROR"
            };
        }

        static void DisplaySummary()
        {
            Console.WriteLine("\n--- INSURANCE SUMMARY ---");
            for (int i = 0; i < deviceNames.Count; i++)
            {
                Console.WriteLine($"Device: {deviceNames[i]}");
                Console.WriteLine($"Category: {categoryNames[i]}");
                Console.WriteLine($"Total Insurance Cost: ${insuranceCosts[i]:F2}");
                Console.WriteLine("--------------------------");
            }
        }

        // When run
        static void Main(string[] args)
        {
            Console.WriteLine("  _____                                                                 \r\n |_   _|                                              /\\                \r\n   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___     /  \\   _ __  _ __  \r\n   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\   / /\\ \\ | '_ \\| '_ \\ \r\n  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/  / ____ \\| |_) | |_) |\r\n |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___| /_/    \\_\\ .__/| .__/ \r\n                                                           | |   | |    \r\n                                                           |_|   |_|   \n-------------------------------------------------------------------------\n ");
            CollectDeviceDetails();
            DisplaySummary();
        }
    }
}
