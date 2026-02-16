namespace Library.Data;

using Microsoft.EntityFrameworkCore;
using Library.Core.Models;
using Library.Core.Models.Items;

public class LibraryDbContext : DbContext
{
  public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

  public DbSet<LibraryItem> Items { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<DVD> DVDs { get; set; }
  public DbSet<Magazine> Magazines { get; set; }
  public DbSet<Member> Members { get; set; }
  public DbSet<Loan> Loans { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LibraryItem>()
        .HasDiscriminator<string>("ItemType")
        .HasValue<Book>("Book")
        .HasValue<DVD>("DVD")
        .HasValue<Magazine>("Magazine");

    // Relationships
    modelBuilder.Entity<Loan>()
        .HasOne(l => l.Member)
        .WithMany(m => m.Loans)
        .HasForeignKey(l => l.MemberId);

    modelBuilder.Entity<Loan>()
        .HasOne(l => l.Item)
        .WithMany()
        .HasForeignKey(l => l.ItemISBN);
  }
}