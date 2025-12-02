using ConsoleApp24;

public class UserInterface
{
    public void ShowMenu()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Добавить книгу");
        Console.WriteLine("2. Удалить книгу");
        Console.WriteLine("3. Найти книгу");
        Console.WriteLine("4. Просмотреть все книги");
        Console.WriteLine("5. Выход");
    }

    public void HandleAddBook(Library library)
    {
        Console.Write("Введите название книги: ");
        string title = Console.ReadLine();
        Console.Write("Введите автора книги: ");
        string author = Console.ReadLine();

        Console.Write("Введите год издания (или нажмите Enter, если неизвестно): ");
        string yearInput = Console.ReadLine();
        int? year = string.IsNullOrWhiteSpace(yearInput) ? (int?)null : int.Parse(yearInput);

        library.AddBook(title, author, year);
        Console.WriteLine("Книга добавлена!");
    }

    public void HandleRemoveBook(Library library)
    {
        Console.Write("Введите ID книги для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (library.RemoveBook(id))
            {
                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ID.");
        }
    }

    public void HandleFindBook(Library library)
    {
        Console.WriteLine("1. Поиск по названию");
        Console.WriteLine("2. Поиск по автору");
        Console.Write("Введите номер: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.Write("Введите запрос для поиска: ");
            string query = Console.ReadLine();
            List<Book> foundBooks = choice switch
            {
                1 => library.FindBooksByTitle(query),
                2 => library.FindBooksByAuthor(query),
                _ => new List<Book>()
            };
            PrintBooks(foundBooks);
        }
    }

    public void HandleShowAllBooks(Library library)
    {
        List<Book> books = library.FindAllBooks();
        PrintBooks(books);
    }

    private void PrintBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Книги не найдены.");
            return;
        }

        Console.WriteLine("ID\tНазвание\tАвтор\tГод");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}\t{book.Year}");
        }
    }
}