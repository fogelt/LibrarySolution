using Library.Core.Models.Items;
using Library.Core.Models;

namespace Library.Core.Interfaces;

public interface ILibraryService
{
  void AddItem(LibraryItem item);
  void AddMember(Member member);
  List<LibraryItem> SearchItems(string searchTerm);
  List<LibraryItem> GetAllItems();
  string MostActiveMember();
}