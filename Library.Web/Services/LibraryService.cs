using Library.Core.Models;
using Library.Core.Models.Items;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Services;

public class LibraryService(IDbContextFactory<LibraryDbContext> dbFactory)
{
    public async Task<List<Member>> GetAllMembersAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.Members.OrderBy(m => m.Name).ToListAsync();
    }

    public async Task AddMemberAsync(Member member)
    {
        using var context = dbFactory.CreateDbContext();
        context.Members.Add(member);
        await context.SaveChangesAsync();
    }

    public async Task<List<LibraryItem>> GetAllItemsAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.Items.OrderBy(i => i.Title).ToListAsync();
    }

    public async Task<List<LibraryItem>> SearchItemsAsync(string searchTerm)
    {
        using var context = dbFactory.CreateDbContext();
        var items = await context.Items.ToListAsync();
        return items.Where(i => i.Matches(searchTerm)).ToList();
    }

    public async Task<bool> BorrowItemAsync(string isbn, string memberId)
    {
        using var context = dbFactory.CreateDbContext();

        var item = await context.Items.FirstOrDefaultAsync(i => i.ISBN == isbn);
        var member = await context.Members.FirstOrDefaultAsync(m => m.MemberId == memberId);

        if (item == null || member == null || !item.IsAvailable) return false;

        item.IsAvailable = false;
        var loan = new Loan(item, member, DateTime.Now, DateTime.Now.AddDays(14));
        context.Loans.Add(loan);

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ReturnItemAsync(string isbn)
    {
        using var context = dbFactory.CreateDbContext();

        var loan = await context.Loans
            .Include(l => l.Item)
            .FirstOrDefaultAsync(l => l.ItemISBN == isbn && l.ReturnDate == null);

        if (loan == null) return false;

        loan.Item.IsAvailable = true;
        loan.ReturnDate = DateTime.Now;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<(int Total, int Loaned, string MVP)> GetStatisticsAsync()
    {
        using var context = dbFactory.CreateDbContext();

        int total = await context.Items.CountAsync();
        int loaned = await context.Items.CountAsync(i => !i.IsAvailable);

        var mvp = await context.Members
            .OrderByDescending(m => context.Loans.Count(l => l.MemberId == m.MemberId))
            .Select(m => m.Name)
            .FirstOrDefaultAsync() ?? "N/A";

        return (total, loaned, mvp);
    }
}