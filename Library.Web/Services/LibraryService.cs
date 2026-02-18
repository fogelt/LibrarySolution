using Library.Core.Models;
using Library.Core.Models.Items;
using Library.Core.Interfaces;

namespace Library.Web.Services;

public class LibraryService(
    IRepository<LibraryItem> itemRepo,
    IRepository<Member> memberRepo,
    IRepository<Loan> loanRepo)
{
    public async Task<List<Member>> GetAllMembersAsync() => [.. (await memberRepo.GetAllAsync()).OrderBy(m => m.Name)];
    public async Task AddMemberAsync(Member member) => await memberRepo.AddAsync(member);
    public async Task DeleteMemberAsync(Member member) => await memberRepo.DeleteAsync(member.MemberId);

    public async Task<List<LibraryItem>> GetAllItemsAsync()
    {
        var items = await itemRepo.GetAllAsync();
        return items.OrderBy(i => i.Title).ToList();
    }

    public async Task<bool> BorrowItemAsync(string isbn, string memberId)
    {
        var item = await itemRepo.GetByIdAsync(isbn);
        var member = await memberRepo.GetByIdAsync(memberId);

        if (item == null || member == null || !item.IsAvailable) return false;

        item.IsAvailable = false;
        var loan = new Loan(item, member, DateTime.Now, DateTime.Now.AddDays(14));

        await itemRepo.UpdateAsync(item);
        await loanRepo.AddAsync(loan);
        return true;
    }

    public async Task<(int Total, int Loaned, string MVP)> GetStatisticsAsync()
    {
        var allItems = await itemRepo.GetAllAsync();
        var allLoans = await loanRepo.GetAllAsync();
        var allMembers = await memberRepo.GetAllAsync();

        int total = allItems.Count();
        int loaned = allItems.Count(i => !i.IsAvailable);

        var mvp = allMembers
            .OrderByDescending(m => allLoans.Count(l => l.MemberId == m.MemberId))
            .Select(m => m.Name)
            .FirstOrDefault() ?? "N/A";

        return (total, loaned, mvp);
    }
}