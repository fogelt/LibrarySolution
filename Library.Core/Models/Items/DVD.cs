using Library.Core.Utils;

namespace Library.Core.Models.Items;

public class DVD : LibraryItem
{
  public int DurationInSeconds { get; set; }

  protected DVD() : base() { }
  public DVD(string isbn, string title, string author, int durationInSeconds, int publishedYear, bool isAvailable = true)
      : base(isbn, title, author, publishedYear)
  {
    DurationInSeconds = durationInSeconds;
  }
}