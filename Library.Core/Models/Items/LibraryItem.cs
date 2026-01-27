using Library.Core.Interfaces;

namespace Library.Core.Models.Items;

public abstract class LibraryItem(string id, string title, int year) : ISearchable
{
  public string ISBN { get; init; } = id;
  public string Title { get; set; } = title;
  public int PublishedYear { get; set; } = year;
  public bool IsAvailable { get; set; } = true;

  public abstract string GetInfo();

  public virtual bool Matches(string searchTerm)
  {
    return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
  }
}