using Library.Core.Models.Items;
using Library.Core.Models;
using Library.Core.Interfaces;

namespace Library.Tests.Mocks;

public class MockRepository : ILibraryRepository
{
  public LibraryDataWrapper LoadAllData() => new();
  public void SaveAllData(List<LibraryItem> i, List<Member> m) { }
}