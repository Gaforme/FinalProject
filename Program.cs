class Program
{
    static void Main(string[] args)
    {
        string filePath = "library.txt";
        var library = new Library(filePath);

        while (true)
        {
            UserInterface.ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UserInterface.HandleAddBook(library);
                    break;
                case "2":
                    UserInterface.HandleRemoveBook(library);
                    break;
                case "3":
                    UserInterface.HandleFindBook(library);
                    break;
                case "4":
                    UserInterface.HandleShowAllBooks(library);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
            Console.WriteLine();
        }
    }
}