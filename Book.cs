namespace ConsoleApp14
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }

        public Book(string title, string author, int? year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Id},{Title},{Author},{Year}";
        }

        public static Book FromString(string bookString)
        {
            var parts = bookString.Split(',');
            if (parts.Length < 3)
                throw new FormatException("Некорректный формат книги");

            var book = new Book(parts[1], parts[2], parts.Length > 3 ? (int?)int.Parse(parts[3]) : null)
            {
                Id = int.Parse(parts[0])
            };
            return book;
        }
    }
}
