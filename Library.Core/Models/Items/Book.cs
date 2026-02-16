namespace Library.Core.Models.Items;

public class Book : LibraryItem
{
  public int NumberOfPages { get; set; }
  protected Book() : base() { }
  public Book(string isbn, string title, string author, int numberOfPages, int publishedYear, bool isAvailable = true)
      : base(isbn, title, author, publishedYear)
  {
    NumberOfPages = numberOfPages;
  }
}