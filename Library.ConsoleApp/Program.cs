using Library.Core.Services;
using Library.ConsoleApp.Controllers;
using Library.Core.Data;

var repo = new JsonRepository();
var library = new LibraryService(repo);
var menu = new MenuController(library);

menu.Run();