namespace Library.Core.Models.Items;

public class Book : LibraryItem
{
  public string Author { get; set; }
  public Book(string isbn, string title, string author, int publishedYear, bool isAvailable = true)
      : base(isbn, title, author, publishedYear)
  {
    Author = author;
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"\n------------------------------\n{Title} (Book), by {Author}\n({PublishedYear}) - ISBN: {ISBN} [{status}]\n------------------------------";
  }
}