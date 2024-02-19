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

            try
            {
                GoogleBooksAPIService serv = new GoogleBooksAPIService("AIzaSyCdWxFfLcu9xfIqRaAZ5Sr3vxo9cawBOQQ");
                ApiBookResponse books = new();

                while (isProgramActive)
                {
                    PrintMenu();
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Type the name of the book");
                            books = await serv.GetBookByName(Console.ReadLine(), logger);
                            isProgramActive = true;
                            break;
                        case 2:
                            Console.WriteLine("Type id of the book");
                            books = await serv.GetBookById(Console.ReadLine(), logger);
                            isProgramActive = true;
                            break;
                        case 0:
                            isProgramActive = false;
                            break;
                    }

                    if (isProgramActive)
                    {
                        if (books.items == null)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            Book book = books.items[0];

                            Console.WriteLine(book.ToString());
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                logger.LogError(ex.Message);
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