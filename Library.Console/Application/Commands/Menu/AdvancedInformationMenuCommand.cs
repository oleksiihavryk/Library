using Library.Console.Core;
using Library.Console.Exceptions;

namespace Library.Console.Application.Commands.Menu;
internal class AdvancedInformationMenuCommand : ApplicationStateCommand
{
    private readonly ILibrary _library;

    public AdvancedInformationMenuCommand(ILibrary library)
    {
        _library = library;
    }

    public override State Execute()
    {
        System.Console.WriteLine(
            "Продвинута інформація");
        System.Console.WriteLine(
            "1. Отримати кількість книг автора в одному екземплярі.");
        System.Console.WriteLine(
            "2. Отримати кількість свободних місць в кожному залі для читання.");
        System.Console.WriteLine(
            "3. Отримати топ 10 книг в бібліотеці.");
        System.Console.WriteLine(
            "4. Чи можливо наразі отримати вибрану книгу в бібліотеці?");
        System.Console.WriteLine(
            "5. Читачі та їх книги по всій бібліотеці?");
        System.Console.WriteLine(
            "6. Скільки книг наразі зберігаєтся у залі для читання по вибраному автору.");
        System.Console.WriteLine("7. Повернутися.");

        var response = GetIntegerUserInput(to: 7);

        System.Console.Clear();
        return response switch
        {
            1 => State.GetCountOfBooksByAuthorInOneExample,
            2 => State.GetCountOfFreeSpaceInEveryRoom,
            3 => State.BooksWithMaximalRatings,
            4 => State.IsItPossibleToTakeABookFromLibrary,
            5 => State.WhatBooksGivenToEveryReaders,
            6 => State.GetBooksCountInReadingRoomByAuthor,
            7 => State.MainMenu,
            _ => throw new UnhandledStateException()
        };
    }
}