namespace Library.Core.Models.Items;

public class DVD : LibraryItem
{
  public string IssueNumber { get; set; }
  public DVD(string isbn, string title, string issueNumber, int publishedYear, bool isAvailable = true)
      : base(isbn, title, publishedYear)
  {
    IssueNumber = issueNumber;
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"{Title}, Issue #{IssueNumber} - ({PublishedYear}) - ISBN: {ISBN} [{status}]";
  }
}