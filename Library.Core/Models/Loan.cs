using System.ComponentModel.DataAnnotations;
using Library.Core.Models.Items;

namespace Library.Core.Models;

public class Loan
{
  [Key]
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string ItemISBN { get; set; } = null!;
  public LibraryItem Item { get; set; } = null!;
  public string MemberId { get; set; } = null!;
  public Member Member { get; set; } = null!;
  public DateTime LoanDate { get; set; }
  public DateTime DueDate { get; set; }
  public DateTime? ReturnDate { get; set; }
  public bool IsReturned => ReturnDate.HasValue;
  public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

  public Loan() { }

  public Loan(LibraryItem itemISBN, Member member, DateTime loanDate, DateTime dueDate)
  {
    Item = itemISBN;
    Member = member;
    LoanDate = loanDate;
    DueDate = dueDate;
  }
}