using Library.Core.Utils;

namespace Library.Core.Models.Items;

public class DVD : LibraryItem
{
  public int DurationInSeconds { get; set; }
  public DVD(string isbn, string title, string author, int durationInSeconds, int publishedYear, bool isAvailable = true)
      : base(isbn, title, author, publishedYear)
  {
    DurationInSeconds = durationInSeconds;
  }
  public override string GetInfo()
  {
    var formattedTime = TimeFormatter.FormatDuration(DurationInSeconds);
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"\n------------------------------\n{Title} (DVD), by {Author} Playtime: {formattedTime}\n({PublishedYear}) - ISBN: {ISBN} [{status}]\n------------------------------";
  }
}