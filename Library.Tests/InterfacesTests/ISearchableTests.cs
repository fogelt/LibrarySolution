using Library.Core.Models.Items;

namespace Library.Tests.InterfacesTests;

public class SearchTests
{
  [Theory]
  [InlineData("Tolkien", true)]         // Author
  [InlineData("tolk", true)]            // Partial Author
  [InlineData("123", true)]             // ISBN
  [InlineData("Sagan", true)]           // Title
  [InlineData("Sagan om RinGeN", true)] // Case-insensitive
  [InlineData("Rowling", false)]        // Not found
  public void Book_Matches_ShouldSearchAllFields(string searchTerm, bool expected)
  {
    var book = new Book("123", "Sagan om ringen", "J.R.R. Tolkien", 1954);
    var result = book.Matches(searchTerm);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("Inception", true)]
  [InlineData("incep", true)]
  [InlineData("999", false)]
  public void DVD_Matches_ShouldSearchTitleAndIsbn(string searchTerm, bool expected)
  {
    var dvd = new DVD("999", "Inception", 9000, 2010);
    var result = dvd.Matches(searchTerm);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("Vogue", true)]
  [InlineData("Vo", true)]
  [InlineData("888", false)]
  public void Magazine_Matches_ShouldSearchTitleAndIssue(string searchTerm, bool expected)
  {
    var magazine = new Magazine("888", "Vogue", 34, 2023);
    var result = magazine.Matches(searchTerm);
    Assert.Equal(expected, result);
  }
}
