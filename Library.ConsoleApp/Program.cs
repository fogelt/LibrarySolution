using Library.Core.Services;
using LibrarySolution.ConsoleApp.Controllers;

var library = new LibraryService();
var menu = new MenuController(library);
menu.Run();