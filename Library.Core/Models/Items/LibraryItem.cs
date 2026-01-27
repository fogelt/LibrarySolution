namespace Library.Core.Models.Items;

public abstract class LibraryItem(string id, string title, int year)
{
  public string ISBN { get; init; } = id;
  public string Title { get; set; } = title;
  public int PublishedYear { get; set; } = year;
  public bool IsAvailable { get; set; } = true;

  public abstract string GetInfo();
}