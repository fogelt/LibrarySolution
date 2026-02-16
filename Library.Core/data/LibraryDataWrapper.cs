using Library.Core.Models;
using Library.Core.Models.Items;
public class LibraryDataWrapper
{
  public List<LibraryItem> Items { get; set; } = [];
  public List<Member> Members { get; set; } = [];
}