using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.Menu;
internal class ActionsMenuCommand : ApplicationStateCommand
{
    public override State Execute()
    {
        System.Console.WriteLine("Меню дій");
        System.Console.WriteLine("1. Зареєструвати нового читача");
        System.Console.WriteLine("2. Видалити читача");
        System.Console.WriteLine("3. Добавити існуючу книгу");
        System.Console.WriteLine("4. Добавити нову книгу");
        System.Console.WriteLine("5. Видалити книгу");
        System.Console.WriteLine("6. Прибрати певну кількість книг");
        System.Console.WriteLine("7. Добавити нову читальну залу");
        System.Console.WriteLine("8. Прибрати читальну залу");
        System.Console.WriteLine("9. Взяти книгу з бібліотеки");
        System.Console.WriteLine("10. Повернути книгу в бібліотеку");
        System.Console.WriteLine("11. Повернутися");

        var response = GetIntegerUserInput(to: 11);

        System.Console.Clear();
        return response switch
        {
            1 => State.RegisterReader,
            2 => State.RemoveReader,
            3 => State.AddExistedBook,
            4 => State.AddNewBook,
            5 => State.RemoveBook,
            6 => State.ReduceBooksQuantity,
            7 => State.AddRoom,
            8 => State.RemoveRoom,
            9 => State.TakeBook,
            10 => State.ReturnBook,
            11 => State.MainMenu,
            _ => throw new UnhandledStateException()
        };
    }
}