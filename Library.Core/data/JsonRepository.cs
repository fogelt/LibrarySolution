using Library.Core.Models.Items;
using System.Text.Json;

namespace Library.Core.Data;

public class JsonRepository
{
  private readonly string _fileName = "mockdb.json";

  public List<LibraryItem> LoadItems()
  {
    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);

    if (!File.Exists(filePath))
    {
      return new List<LibraryItem>();
    }

    string jsonString = File.ReadAllText(filePath);
    return JsonSerializer.Deserialize<List<LibraryItem>>(jsonString) ?? new List<LibraryItem>();
  }

  public void SaveItems(List<LibraryItem> items)
  {
    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);
    var jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, jsonString);
  }
}