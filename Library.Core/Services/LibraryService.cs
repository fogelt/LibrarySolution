using Library.Core.Models;
using Library.Core.Models.Items;
using Library.Core.Interfaces;
using Library.Core.Data;

namespace Library.Core.Services;

public class LibraryService : ILibraryService
{
    private readonly List<LibraryItem> _items;
    private readonly List<Member> _members;
    private readonly ILibraryRepository _repo;

    public LibraryService(ILibraryRepository repo)
    {
        _repo = repo;
        var data = _repo.LoadAllData();
        _items = data.Items;
        _members = data.Members;
    }

    // --- Member methods ---
    public List<Member> GetAllMembers() => [.. _members.OrderBy(m => m.Name)];

    public void AddMember(Member member)
    {
        _members.Add(member);
        PersistData();
    }

    // --- Item methods ---
    public List<LibraryItem> SearchItems(string searchTerm) =>
        [.. _items.Where(i => i.Matches(searchTerm))];

    public List<LibraryItem> SortItemsAlphabetically() =>
        [.. _items.OrderBy(b => b.Title)];

    public List<LibraryItem> SortItemsReleaseDate() =>
        [.. _items.OrderBy(b => b.PublishedYear)];

    public int GetItemsCount() => _items.Count();
    public List<LibraryItem> GetAllItems() => [.. _items.OrderBy(i => i.Title)];
    public void AddItem(LibraryItem item)
    {
        _items.Add(item);
        PersistData();
    }

    // --- Core logic ---
    public bool BorrowItem(string isbn, string memberId)
    {
        var item = _items.FirstOrDefault(i => i.ISBN == isbn && i.IsAvailable);
        var member = _members.FirstOrDefault(m => m.MemberId == memberId);

        if (item == null || member == null) return false;

        item.IsAvailable = false;
        member.Inventory.Add(item);

        PersistData();
        return true;
    }

    public bool ReturnItem(string isbn, string memberId)
    {
        var item = _items.FirstOrDefault(i => i.ISBN == isbn && !i.IsAvailable);
        var member = _members.FirstOrDefault(m => m.MemberId == memberId);

        if (item == null || member == null || !member.Inventory.Contains(item))
            return false;

        item.IsAvailable = true;
        member.Inventory.Remove(item);

        PersistData();
        return true;
    }

    // --- Statistics ---
    public int ItemsOnLoanCount() => _items.Count(i => !i.IsAvailable);

    public string MostActiveMember() =>
        _members.MaxBy(m => m.ActiveScore)?.Name ?? "No members found";

    public (int Total, int Loaned, string MVP) GetStatistics()
    {
        return (GetItemsCount(), ItemsOnLoanCount(), MostActiveMember());
    }

    public void PersistData() => _repo.SaveAllData(_items, _members);
}