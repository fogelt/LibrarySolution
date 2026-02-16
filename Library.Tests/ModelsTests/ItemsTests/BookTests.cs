using Library.Core.Models.Items;

namespace Library.Tests.ModelsTests.ItemsTests;

public class BookTests
{
  [Fact]
  public void Constructor_ShouldSetPropertiesCorrectly()
  {
    var book = new Book("978-91-0-012345-6", "Testbok", "Testförfattare", 2024);

    Assert.Equal("978-91-0-012345-6", book.ISBN);
    Assert.Equal("Testbok", book.Title);
  }

  [Fact]
  public void IsAvailable_ShouldBeTrueForNewBook()
  {
    var book = new Book("978-91-0-012345-6", "Testbok", "Testförfattare", 2024);
    Assert.True(book.IsAvailable);
  }

  [Fact]
  public void GetInfo_ShouldReturnFormattedString()
  {
    var book = new Book("978-91-0-012345-6", "Testbok", "Testförfattare", 2024);
    string info = book.GetInfo();

    Assert.Contains("Testbok", info);
    Assert.Contains("Testförfattare", info);
    Assert.Contains("2024", info);
    Assert.Contains("978-91-0-012345-6", info);
    Assert.Contains("Available", info);

    //Assert.Equal("Testbok (Book), by Testförfattare (2024) - ISBN: 978-91-0-012345-6 [Available]", info);
  }
}