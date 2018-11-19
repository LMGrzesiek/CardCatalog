using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
namespace CardCatalog
{
    public class CardCatalog
    {
        private static string string_filename;

        private static List<Book> books;

        public CardCatalog(string fileName)
        {
            //puts a value into string_filename
            string_filename = fileName + ".csv";

            //if whatever.csv doesn't exist, create a new file
            if (!File.Exists(string_filename)) 
            {
                //ask Joe to elaborate on why we need a using statement to prevent "file already being used" error on save
                using(var file = File.Create(string_filename))
                {

                }
                
                books = new List<Book>();
            }
            else
            {
                //using LINQ, we take the long string of info from string_filename and assign it to a variable,v,
                //and runs it through our fromCSV method...creating a list using the .ToList()
                books = File.ReadAllLines(string_filename).Select(v => Book.FromCsv(v)).ToList(); 
            }

            
        }

        public static void ListBooks()
        {
            if (books.Count > 0)
            {
                foreach (Book item in books)
                {
                    Console.WriteLine("Title: {0}, Author: {1}, Genre: {2}", item.Title, item.Author, item.Genre);
                }
            }
            else
            {
                Console.WriteLine("No books have been entered...yet.");
            }
        }

        public static void AddBook()
        {
            Console.WriteLine("Provide a title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Provide the author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Provide the genre: ");
            string genre = Console.ReadLine();

            Book book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre
            };

            books.Add(book);
            Console.WriteLine("You have successfully added a book!");
        }

        public static void Save()
        {
            using (StreamWriter file = new StreamWriter(string_filename))
            {
                foreach (Book book in books)
                {
                    file.WriteLine("{0},{1},{2}", book.Title, book.Author, book.Genre);
                }
            }


        }


    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public static Book FromCsv(string csvLine)
        {
            //invoked after csv file is read
            string[] csvValues = csvLine.Split(","); 

            Book book = new Book
            {
                Title = csvValues[0],
                Author = csvValues[1],
                Genre = csvValues[2]
            };

            return book;
            //populating "books" with book objects from our csv file that already exists
        }
    }
}
