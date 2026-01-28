using Library.Core.Models;
using Library.Core.Models.Items;

namespace Library.Core.Interfaces;

public interface ILibraryRepository
{
  LibraryDataWrapper LoadAllData();
  void SaveAllData(List<LibraryItem> items, List<Member> members);
}