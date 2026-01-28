namespace Library.Core.Models.Items;

public class Magazine : LibraryItem
{
  public int IssueNumber { get; set; }
  public Magazine(string isbn, string title, int issueNumber, int publishedYear, bool isAvailable = true)
      : base(isbn, title, publishedYear)
  {
    IssueNumber = issueNumber;
    IsAvailable = isAvailable;
  }
  public override string GetInfo()
  {
    string status = IsAvailable ? "Available" : "Borrowed";
    return $"\n------------------------------\n{Title} (Magazine), Issue #{IssueNumber}\n({PublishedYear}) - ISBN: {ISBN} [{status}]\n------------------------------";
  }
}