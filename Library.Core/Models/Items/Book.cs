namespace Library.Core.Models.Items;

public class Book : LibraryItem
{
  public Book(string isbn, string title, string author, int publishedYear, bool isAvailable = true)
      : base(isbn, title, author, publishedYear)
  {
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"\n------------------------------\n{Title} (Book), by {Author}\n({PublishedYear}) - ISBN: {ISBN} [{status}]\n------------------------------";
  }
}