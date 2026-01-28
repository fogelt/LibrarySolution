using Library.Core.Enums;
using Library.Core.Services;

namespace LibrarySolution.ConsoleApp.Controllers;

public class MenuController(LibraryService library)
{
  public void Run()
  {
    while (true)
    {
      DisplayMainMenu();
      if (!Enum.TryParse(Console.ReadLine(), out MenuOption choice))
      {
        choice = MenuOption.Unknown;
      }

      if (choice == MenuOption.Exit) break;

      HandleChoice(choice);
    }
  }

  private void DisplayMainMenu()
  {
    Console.Clear();
    Console.WriteLine("=== Library ===");
    Console.WriteLine($"{(int)MenuOption.DisplayAll}. Show all items");
    Console.WriteLine($"{(int)MenuOption.Search}. Search");
    Console.WriteLine($"{(int)MenuOption.LoanItem}. Borrow item");
    Console.WriteLine($"{(int)MenuOption.ReturnItem}. Return item");
    Console.WriteLine($"{(int)MenuOption.Exit}. Exit");
    Console.Write("\nChoose: ");
  }

  private void HandleChoice(MenuOption choice)
  {
    switch (choice)
    {
      case MenuOption.DisplayAll:
        ShowAllItems();
        break;
      case MenuOption.Search:
        SearchItems();
        break;
      case MenuOption.LoanItem:
        HandleLoan();
        break;
      case MenuOption.ReturnItem:
        HandleReturn();
        break;
      case MenuOption.Unknown:
      default:
        Console.WriteLine("Invalid choice, press any key...");
        Console.ReadKey();
        break;
    }
  }

  private void ShowAllItems()
  {
    Console.Clear();
    Console.WriteLine("-- Library Inventory --");

    var items = library.SortItemsAlphabetically();
    foreach (var item in items)
    {
      Console.WriteLine(item.GetInfo());
    }

    Console.WriteLine("\nPress any key to return.");
    Console.ReadKey();
  }

  private void SearchItems()
  {
    Console.Write("Enter search term: ");
    var term = Console.ReadLine() ?? "";

    var results = library.SearchItems(term);

    Console.WriteLine("\nResultat:");
    foreach (var res in results)
    {
      Console.WriteLine(res.GetInfo());
    }

    Console.ReadKey();
  }

  private void HandleLoan()
  {
    Console.WriteLine("--- Borrow item ---");
    // TBD
    Console.ReadKey();
  }

  private void HandleReturn()
  {
    Console.WriteLine("--- Return item ---");
    // TBD
    Console.ReadKey();
  }
}