namespace Library.Core.Models.Items;

public class Book : LibraryItem
{
  public string Author { get; set; }
  public Book(string isbn, string title, string author, int publishedYear, bool isAvailable = true)
      : base(isbn, title, publishedYear)
  {
    Author = author;
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"\n------------------------------\n{Title} (Book), by {Author}\n({PublishedYear}) - ISBN: {ISBN} [{status}]\n------------------------------";
  }
  public override bool Matches(string searchTerm)
  {
    var propertiesToBeSearched = new string[] { ISBN, Title, Author };
    return propertiesToBeSearched.Any(prop => prop.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
  }
}