using Library.Core.Models.Items;

namespace Library.Core.Models;

public class Member(string memberId, string name, string email, DateTime memberSince, List<Book> inventory)
{
  string MemberId { get; set; } = memberId;
  string Name { get; set; } = name;
  string Email { get; set; } = email;
  DateTime MemberSince { get; set; } = memberSince;
  List<Book> Inventory { get; set; } = inventory;

  public string GetInfo()
  {
    string InventoryStatus = Inventory.Count == 0 ? "No books on loan" : $"Books on loan: {Inventory}";
    return $"[{MemberId}] \nName: {Name} \nEmail: {Email} \nJoined on: {MemberSince} \n{InventoryStatus}";
  }
}