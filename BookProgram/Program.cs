using BookProgram.Models;
using BookProgram.Services;
using LoggingSim;

namespace BookProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int choice;
            bool isProgramActive = true;

            FileLogger logger = new FileLogger(new FileWriter("C:\\Books\\BooksLogFile.txt"));

            Console.WriteLine("Type your API key");

            try
            {
                GoogleBooksAPIService serv = new GoogleBooksAPIService(Console.ReadLine(), logger);
                ApiBookResponse books = new();

                while (isProgramActive)
                {
                    PrintMenu();
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Type the name of the book");
                            books = await serv.GetBookByName(Console.ReadLine());
                            isProgramActive = true;
                            break;
                        case 2:
                            Console.WriteLine("Type id of the book");
                            books = await serv.GetBookById(Console.ReadLine());
                            isProgramActive = true;
                            break;
                        case 0:
                            isProgramActive = false;
                            break;
                    }

                    if (isProgramActive)
                    {
                        if (books.Items == null)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            Book book = books.Items[0];

                            Console.WriteLine(book.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Press 1 to find a book by a name");
            Console.WriteLine("Press 2 to find a book by id");
            Console.WriteLine("Press 0 to exit");
        }
    }
}