using System.ComponentModel.DataAnnotations;
namespace Library.Core.Models;

public class Member
{
  [Key]
  public string MemberId { get; set; } = null!;
  public string Name { get; set; } = null!;
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