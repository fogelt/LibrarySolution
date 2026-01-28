using Library.Core.Services;
using Library.Core.Models;
using Library.Core.Models.Items;

namespace Library.Tests.ServicesTests;

public class LibraryServiceTests
{
  private readonly LibraryService _service;
  public LibraryServiceTests()
  {
    _service = new LibraryService();
  }

  [Theory]
  [InlineData(10, 50, 30, "Bob")]
  [InlineData(100, 20, 30, "Alice")]
  [InlineData(10, 20, 999, "Ed")]
  public void MostActiveMember_ShouldReturnCorrectMember(int scoreA, int scoreB, int scoreC, string expectedWinner)
  {
    _service.AddMember(new Member("1", "Alice", "a@test.com", DateTime.Now, [], scoreA));
    _service.AddMember(new Member("2", "Bob", "b@test.com", DateTime.Now, [], scoreB));
    _service.AddMember(new Member("3", "Ed", "e@test.com", DateTime.Now, [], scoreC));

    var result = _service.MostActiveMember();
    Assert.Equal(expectedWinner, result);
  }
  [Fact]
  public void TotalItems_ShouldReturnCorrectCount()
  {
    _service.AddItem(new Book("1", "Book A", "Author", 2020));
    _service.AddItem(new DVD("2", "Book B", 3600, 2021));
    _service.AddItem(new Magazine("2", "Book B", 34, 2021));

    var count = _service.TotalItems();
    Assert.Equal(3, count);
  }

  [Fact]
  public void ItemsOnLoan_ShouldReturnCorrectCount()
  {
    var item1 = new Book("1", "Available Book", "Author", 2020) { IsAvailable = true };
    var item2 = new DVD("2", "Borrowed Book", 1234, 2021) { IsAvailable = false };
    var item3 = new Magazine("3", "Another Borrowed Book", 65, 2022) { IsAvailable = false };

    _service.AddItem(item1);
    _service.AddItem(item2);
    _service.AddItem(item3);

    var count = _service.ItemsOnLoan();

    Assert.Equal(2, count);
  }

  [Fact]
  public void SortItemsAlphabetically_ShouldReturnCorrectOrder()
  {
    _service.AddItem(new Book("1", "Zebra", "Author", 2020));
    _service.AddItem(new DVD("2", "Apan", 4123, 2021));
    _service.AddItem(new Magazine("3", "Banan", 32, 2022));

    var sortedList = _service.SortItemsAlphabetically();
    Assert.Equal("Apan", sortedList[0].Title);
    Assert.Equal("Banan", sortedList[1].Title);
    Assert.Equal("Zebra", sortedList[2].Title);
  }

  [Fact]
  public void SortItemsReleaseDate_ShouldReturnChronologicalOrder()
  {
    _service.AddItem(new Book("1", "Zebra", "Author", 2020));
    _service.AddItem(new DVD("2", "Apan", 4123, 2021));
    _service.AddItem(new Magazine("3", "Banan", 32, 1990));

    var sortedList = _service.SortItemsReleaseDate();

    Assert.Equal(1990, sortedList[0].PublishedYear);
    Assert.Equal(2020, sortedList[1].PublishedYear);
    Assert.Equal(2021, sortedList[2].PublishedYear);
  }
}