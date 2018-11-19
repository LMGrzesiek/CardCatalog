using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasSpace = true;
            while (hasSpace)
            {
                Console.WriteLine("What one-word name would you like to call your card catalog?");
                string fileName = Console.ReadLine();
                hasSpace = fileName.Contains(" ");

                if (hasSpace)
                {
                    Console.WriteLine("I'm sorry, your name fails to meet the one-word requirement, please try again...");
                }
                else
                {
                    Console.WriteLine("Thank you! Please choose an option from the menu below:");
                    new CardCatalog(fileName);
                }
            }
            string userChoice = MainMenu();

            while (userChoice != "3")
            {
                if (userChoice == "1")
                {
                    CardCatalog.ListBooks();
                    userChoice = MainMenu();
                }
                else if (userChoice == "2")
                {
                    CardCatalog.AddBook();
                    userChoice = MainMenu();
                }
            }
            CardCatalog.Save();

        }
        

        private static string MainMenu()
        {
           //error when 1, 2 or 3 is not given 
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) List All Books");
            Console.WriteLine("2) Add A Book");
            Console.WriteLine("3) Save and Exit");
            return Console.ReadLine();
        }
    }
}
