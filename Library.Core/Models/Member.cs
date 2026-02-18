using System.ComponentModel.DataAnnotations;
namespace Library.Core.Models;

public class Member
{
  [Key]
  public string MemberId { get; set; } = null!;

  [Required(ErrorMessage = "We need a name for the library card.")]
  [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "Email is required for overdue notifications.")]
  [EmailAddress(ErrorMessage = "That doesn't look like a valid email address.")]
  public string Email { get; set; } = null!;
  public DateTime MemberSince { get; set; }
  public int ActiveScore { get; set; }
  public List<Loan> Loans { get; set; } = new();

  protected Member() { }

  public Member(string memberId, string name, string email, DateTime memberSince, int activeScore)
  {
    MemberId = memberId;
    Name = name;
    Email = email;
    MemberSince = memberSince;
    ActiveScore = activeScore;
  }
}