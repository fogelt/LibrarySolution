using Library.Core.Interfaces;
using System.Text.Json.Serialization;

namespace Library.Core.Models.Items;

//--TEMPORARY MOCK DB--
[JsonDerivedType(typeof(Book), typeDiscriminator: "book")]
[JsonDerivedType(typeof(DVD), typeDiscriminator: "dvd")]
[JsonDerivedType(typeof(Magazine), typeDiscriminator: "magazine")]
public abstract class LibraryItem(string id, string title, string author, int year) : ISearchable
{
  public string ISBN { get; init; } = id;
  public string Title { get; set; } = title;
  public int PublishedYear { get; set; } = year;
  public bool IsAvailable { get; set; } = true;
  public string Author { get; set; } = author;

  public abstract string GetInfo();

  public virtual bool Matches(string searchTerm)
  {
    var propertiesToBeSearched = new string[] { ISBN, Title, Author };
    return propertiesToBeSearched.Any(prop => prop.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
  }
}