using Library.Core.Models.Items;
using Library.Core.Models;
using System.Text.Json;

namespace Library.Core.Data;

public class JsonRepository
{
  private readonly string _fileName = "mockdb.json";
  private readonly string _filePath;

  public JsonRepository()
  {
    _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);
  }

  public LibraryDataWrapper LoadAllData()
  {
    if (!File.Exists(_filePath)) return new LibraryDataWrapper();

    string jsonString = File.ReadAllText(_filePath);
    return JsonSerializer.Deserialize<LibraryDataWrapper>(jsonString) ?? new LibraryDataWrapper();
  }

  public void SaveAllData(List<LibraryItem> items, List<Member> members)
  {
    var data = new LibraryDataWrapper { Items = items, Members = members };
    var options = new JsonSerializerOptions { WriteIndented = true };

    string jsonString = JsonSerializer.Serialize(data, options);
    File.WriteAllText(_filePath, jsonString);
  }
}