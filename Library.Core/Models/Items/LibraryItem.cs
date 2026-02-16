using System.ComponentModel.DataAnnotations;
using Library.Core.Interfaces;

namespace Library.Core.Models.Items;

public abstract class LibraryItem : ISearchable
{
  [Key]
  public string ISBN { get; set; } = null!;
  public string Title { get; set; } = null!;
  public string Author { get; set; } = null!;
  public int PublishedYear { get; set; }
  public bool IsAvailable { get; set; } = true;
  protected LibraryItem() { }
  protected LibraryItem(string isbn, string title, string author, int year)
  {
    ISBN = isbn;
    Title = title;
    Author = author;
    PublishedYear = year;
  }

  public virtual bool Matches(string searchTerm) =>
    string.IsNullOrWhiteSpace(searchTerm) ||
    ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
    Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
    Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
}