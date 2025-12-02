using ConsoleApp24;

public class Library
{
    private List<Book> _books;
    private string _filePath;
    private int _nextId;

    public Library(string filePath)
    {
        _filePath = filePath;
        Load();
    }

    public void AddBook(string title, string author, int? year)
    {
        var book = new Book(title, author, year) { Id = _nextId++ };
        _books.Add(book);
        SaveAsync();
    }

    public bool RemoveBook(int id)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
            SaveAsync();
            return true;
        }
        return false;
    }

    public List<Book> FindAllBooks()
    {
        return _books.ToList();
    }

    public List<Book> FindBooksByTitle(string query)
    {
        return _books.Where(b => b.Title != null && b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> FindBooksByAuthor(string query)
    {
        return _books.Where(b => b.Author != null && b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    //Не знаю как работает не трогать
    private async void SaveAsync()
    {
        using (var writer = new StreamWriter(_filePath))
        {
            foreach (var book in _books)
            {
                await writer.WriteLineAsync(book.ToString());
            }
        }
    }

    private void Load()
    {
        if (!File.Exists(_filePath))
        {
            _books = new List<Book>();
            _nextId = 1;
            return;
        }

        var lines = File.ReadAllLines(_filePath);
        _books = lines.Select(Book.FromString).ToList();
        _nextId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
    }
}