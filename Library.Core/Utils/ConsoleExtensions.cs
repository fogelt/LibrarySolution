namespace Library.Core.Utils;

public static class ConsoleExtensions
{
  public static string Ask(string prompt)
  {
    Console.Write($"{prompt}: ");
    return Console.ReadLine() ?? string.Empty;
  }

  public static void WaitForKey(string message = "\nPress any key to continue...")
  {
    Console.WriteLine(message);
    Console.ReadKey();
  }

  public static void WriteError(string message)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nError: {message}");
    Console.ResetColor();
  }

  public static void WriteHeader(string title)
  {
    Console.Clear();
    Console.WriteLine($"=== {title.ToUpper()} ===");
    Console.WriteLine(new string('-', title.Length + 8));
  }
}