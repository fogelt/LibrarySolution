using Library.Core.Models.Items;

namespace Library.Core.Models;

public class Loan(LibraryItem item, Member member, DateOnly loanDate, DateOnly dueDate)
{
  public LibraryItem Item { get; init; } = item;
  public Member Member { get; init; } = member;
  public DateOnly LoanDate { get; init; } = loanDate;
  public DateOnly DueDate { get; init; } = dueDate;
  public DateOnly? ReturnDate { get; set; } = null;
  public bool IsOverdue => !IsReturned && DateOnly.FromDateTime(DateTime.Now) > DueDate;
  public bool IsReturned => ReturnDate.HasValue;
}