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
    return $"{Title} (Book), by {Author} ({PublishedYear}) - ISBN: {ISBN} [{status}]";
  }
}