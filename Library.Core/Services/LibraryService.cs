using Library.Core.Models;
using Library.Core.Models.Items;
using Library.Core.Interfaces;

namespace Library.Core.Services;

public class LibraryService : ILibraryService
{
  private readonly List<LibraryItem> _items = [];
  private readonly List<Member> _members = [];

  public void AddItem(LibraryItem item) => _items.Add(item);
  public void AddMember(Member member) => _members.Add(member);

  public List<LibraryItem> SearchItems(string searchTerm) =>
      [.. _items.Where(i => i.Matches(searchTerm))];

  public List<LibraryItem> SortItemsAlphabetically() =>
      [.. _items.OfType<LibraryItem>().OrderBy(b => b.Title)];

  public List<LibraryItem> SortItemsReleaseDate() =>
      [.. _items.OfType<LibraryItem>().OrderBy(b => b.PublishedYear)];

  public int TotalItems() => _items.Count;

  public int ItemsOnLoan() => _items.Count(i => !i.IsAvailable);

  public string MostActiveMember() =>
      _members.MaxBy(m => m.ActiveScore)?.Name ?? "No members found";
}