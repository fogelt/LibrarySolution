using Library.Core.Models.Items;
using Library.Core.Interfaces;

namespace Library.Core.Models;

public class Member(string memberId, string name, string email, DateTime memberSince, List<Book> inventory, int activeScore) : ISearchable
{
  public string MemberId { get; set; } = memberId;
  public string Name { get; set; } = name;
  public string Email { get; set; } = email;
  public DateTime MemberSince { get; set; } = memberSince;
  public List<Book> Inventory { get; set; } = inventory;
  public int ActiveScore { get; set; } = activeScore;

  public string GetInfo()
  {
    string InventoryStatus = Inventory.Count == 0 ? "No books on loan" : $"Books on loan: {Inventory}";
    return $"[{MemberId}] \nName: {Name} \nEmail: {Email} \nJoined on: {MemberSince} \n{InventoryStatus}";
  }

  public bool Matches(string searchTerm)
  {
    return Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
  }
}