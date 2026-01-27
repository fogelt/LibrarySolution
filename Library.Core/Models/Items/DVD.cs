using Library.Core.Utils;

namespace Library.Core.Models.Items;

public class DVD : LibraryItem
{
  public int DurationInSeconds { get; set; }
  public DVD(string isbn, string title, int durationInSeconds, int publishedYear, bool isAvailable = true)
      : base(isbn, title, publishedYear)
  {
    DurationInSeconds = durationInSeconds;
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    var formattedTime = TimeFormatter.FormatDuration(DurationInSeconds);
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"{Title} (DVD), Playtime: {formattedTime} - ({PublishedYear}) - ISBN: {ISBN} [{status}]";
  }
}