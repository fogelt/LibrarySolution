using Library.Core.Models.Items;

namespace Library.Tests.ModelsTests.ItemsTests;

public class MagazineTests
{
  [Fact]
  public void Constructor_ShouldSetPropertiesCorrectly()
  {
    var magazine = new Magazine("ISSN-456", "Tech Monthly", "Tech Publisher", 45, 2024);

    Assert.Equal("ISSN-456", magazine.ISBN);
    Assert.Equal("Tech Monthly", magazine.Title);
    Assert.Equal(45, magazine.IssueNumber);
  }

  [Fact]
  public void IsAvailable_ShouldBeTrueForNewMagazine()
  {
    var magazine = new Magazine("ISSN-456", "Tech Monthly", "Tech Publisher", 45, 2024);
    Assert.True(magazine.IsAvailable);
  }

  [Fact]
  public void GetInfo_ShouldReturnFormattedString()
  {
    var magazine = new Magazine("ISSN-456", "National Geographic", "Tech Publisher", 39, 2023);

    string info = magazine.GetInfo();

    Assert.Contains("National Geographic", info);
    Assert.Contains("#39", info);
    Assert.Contains("2023", info);
    Assert.Contains("Available", info);
  }
}