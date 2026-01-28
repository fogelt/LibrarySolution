using Library.Core.Models.Items;

namespace Library.Tests.ModelsTests.ItemsTests;

public class DVDTests
{
  [Fact]
  public void Constructor_ShouldSetPropertiesCorrectly()
  {
    var dvd = new DVD("DVD-123", "Inception", "Nolan", 8880, 2010);

    Assert.Equal("DVD-123", dvd.ISBN);
    Assert.Equal("Inception", dvd.Title);
    Assert.Equal(8880, dvd.DurationInSeconds);
  }

  [Fact]
  public void IsAvailable_ShouldBeTrueForNewDVD()
  {
    var dvd = new DVD("DVD-123", "Inception", "Nolan", 8880, 2010);
    Assert.True(dvd.IsAvailable);
  }

  [Fact]
  public void GetInfo_ShouldReturnFormattedString()
  {
    var dvd = new DVD("DVD-123", "Inception", "Nolan", 5400, 2010);
    string info = dvd.GetInfo();

    Assert.Contains("Inception", info);
    Assert.Contains("01h 30m 00s", info);
    Assert.Contains("2010", info);
    Assert.Contains("Available", info);
  }
}