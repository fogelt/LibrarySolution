using Library.Core.Enums;
using Library.Core.Services;
using Library.Core.Utils;

namespace Library.ConsoleApp.Controllers;

public class MenuController(LibraryService library)
{
  public void Run()
  {
    while (true)
    {
      DisplayMenu();
      if (!Enum.TryParse(Console.ReadLine(), out MenuOption choice)) choice = MenuOption.Unknown;
      if (choice == MenuOption.Exit) break;
      HandleChoice(choice);
    }
  }

  private void DisplayMenu()
  {
    ConsoleExtensions.WriteHeader("Library System");
    Console.WriteLine($"{(int)MenuOption.DisplayAll}. Show All Items");
    Console.WriteLine($"{(int)MenuOption.Search}. Search");
    Console.WriteLine($"{(int)MenuOption.LoanItem}. Borrow Item");
    Console.WriteLine($"{(int)MenuOption.ReturnItem}. Return Item");
    Console.WriteLine($"{(int)MenuOption.ViewMembers}. View Members");
    Console.WriteLine($"{(int)MenuOption.Statistics}. Statistics");
    Console.WriteLine($"{(int)MenuOption.Exit}. Exit");
    Console.Write("\nSelect: ");
  }

  private void HandleChoice(MenuOption choice)
  {
    switch (choice)
    {
      case MenuOption.DisplayAll:
        ConsoleExtensions.WriteHeader("Inventory");
        library.GetAllItems().ForEach(i => Console.WriteLine(i.GetInfo()));
        break;
      case MenuOption.Search:
        var term = ConsoleExtensions.Ask("Search for");
        library.SearchItems(term).ForEach(i => Console.WriteLine(i.GetInfo()));
        break;
      case MenuOption.LoanItem:
        if (library.BorrowItem(ConsoleExtensions.Ask("ISBN"), ConsoleExtensions.Ask("Member ID")))
          Console.WriteLine("Loan successful!");
        else ConsoleExtensions.WriteError("Loan failed.");
        break;
      case MenuOption.ReturnItem:
        if (library.ReturnItem(ConsoleExtensions.Ask("ISBN"), ConsoleExtensions.Ask("Member ID")))
          Console.WriteLine("Return successful!");
        else ConsoleExtensions.WriteError("Return failed.");
        break;
      case MenuOption.ViewMembers:
        ConsoleExtensions.WriteHeader("Members");
        library.GetAllMembers().ForEach(m => Console.WriteLine(m.GetInfo()));
        break;
      case MenuOption.Statistics:
        var stats = library.GetStatistics();
        ConsoleExtensions.WriteHeader("Statistics");
        Console.WriteLine($"Total: {stats.Total}\nOn Loan: {stats.Loaned}\nMVP: {stats.MVP}");
        break;
    }
    ConsoleExtensions.WaitForKey();
  }
}