using Library.Core.Services;
using Library.Core.Models;

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
}