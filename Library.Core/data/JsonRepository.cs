using Library.Core.Models.Items;
using System.Text.Json;

namespace Library.Core.Data;

public class JsonRepository
{
  private readonly string _filePath = "Library.Core/data/mockdb.json";

  public List<LibraryItem> LoadItems()
  {
    if (!File.Exists(_filePath)) return new List<LibraryItem>();

    string jsonString = File.ReadAllText(_filePath);
    return JsonSerializer.Deserialize<List<LibraryItem>>(jsonString) ?? new List<LibraryItem>();
  }

  public void SaveItems(List<LibraryItem> items)
  {
    var jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(_filePath, jsonString);
  }
}