using Library.Console.Application;
using Library.Console.Exceptions;
using System.Text;
using CoreLibrary = Library.Console.Core.Library;

string name = "[Вставте ім'я бібліотеки]"; //library name 
var library = new CoreLibrary(name);
var seeder = new Seeder(library);

//Console configuration
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;

//Seed data
//none

//start application
try
{
    Navigator.Start(library);
}
catch (Exception ex)
{
    var prevColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;

    Action handleError = ex switch
    {
        UnhandledStateException => 
            () => Console.WriteLine("Вибраний елемент системи наразі не " +
                                    "передбачений для використовування системою..."),
        NotImplementedException => 
            () => Console.WriteLine("Ця функція програми наразі " +
                                    "недоступна для використовування..."),
        _ => 
            () => Console.WriteLine("Невідома помилка в системі. " +
                                    "Термінове припинення виконання програми... "),
    };
    handleError();

    Console.ForegroundColor = prevColor;
}
Console.ReadKey();