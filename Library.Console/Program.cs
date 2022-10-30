using Library.Console.Application;
using Library.Console.Exceptions;
using Library.Domain.Exceptions;
using System.Text;
using CoreLibrary = Library.Console.Core.Library;

string name = "[Вставте ім'я бібліотеки]"; //library name
var library = new CoreLibrary(name);
var seeder = new Seeder(library);

//Console configuration
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

//Seed data
seeder.SeedData();

//start application
try
{
    Navigator.Start(library);
}
catch (CannotAddNewReaderException)
{
    Console.WriteLine("Omg you can't handle basic in your system exception, what a shame...");
}
catch (UnhandledStateException)
{
    Console.WriteLine("Current system state is unhandled by application navigator...");
}
catch (NotImplementedException)
{
    Console.WriteLine("Chosen option is currently not implemented in system...");
}
Console.ReadKey();