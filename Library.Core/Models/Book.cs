namespace Library.Core.Models;

public class Book(string isbn, string title, string author, int publishedYear, bool isAvailable = true)
{
  public string ISBN { get; init; } = isbn;
  public string Title { get; set; } = title;
  public string Author { get; set; } = author;
  public int PublishedYear { get; set; } = publishedYear;
  public bool IsAvailable { get; set; } = isAvailable;

  public string GetInfo()
  {
    string status = IsAvailable ? "Tillgänglig" : "Utlånad";
    return $"{Title} av {Author} ({PublishedYear}) - ISBN: {ISBN} [{status}]";
  }
}