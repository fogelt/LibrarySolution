using Library.Core.Models.Items;
using Library.Core.Interfaces;

namespace Library.Core.Models;

public class Member(string memberId, string name, string email, DateTime memberSince, List<LibraryItem> inventory, int activeScore) : ISearchable
{
  public string MemberId { get; set; } = memberId;
  public string Name { get; set; } = name;
  public string Email { get; set; } = email;
  public DateTime MemberSince { get; set; } = memberSince;
  public List<LibraryItem> Inventory { get; set; } = inventory;
  public int ActiveScore { get; set; } = activeScore;

  public string GetInfo()
  {
    string InventoryStatus = Inventory.Count == 0 ? "No items on loan" : "Items on loan: " + string.Join(", ", Inventory.Select(i => i.Title));
    return $"ID: [{MemberId}] \nName: {Name} \nEmail: {Email} \nJoined on: {MemberSince} \n{InventoryStatus}\n-------------------------------------";
  }

  public bool Matches(string searchTerm)
  {
    return Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
  }
}