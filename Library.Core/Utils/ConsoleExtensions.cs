namespace Library.Core.Utils;

public static class ConsoleExtensions
{
  public static string Ask(string prompt)
  {
    Console.Write($"{prompt}: ");
    return Console.ReadLine() ?? string.Empty;
  }

  public static void WaitForKey(string message = "\n Press any key...")
  {
    Console.WriteLine(message);
    Console.ReadKey();
  }

  public static void WriteError(string message)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {message}");
    Console.ResetColor();
  }
}