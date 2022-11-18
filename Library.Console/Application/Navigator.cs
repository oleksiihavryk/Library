using Library.Console.Application.Commands;
using Library.Console.Application.Commands.ActionsMenu;
using Library.Console.Application.Commands.AdvancedInformationMenu;
using Library.Console.Application.Commands.GenericInformationMenu;
using Library.Console.Application.Commands.Menu;
using CoreLibrary = Library.Console.Core.Library;

namespace Library.Console.Application;
internal static class Navigator
{
    private static State _state;
    private static CoreLibrary _library = null!;

    internal static void Start(CoreLibrary library)
    {
        //setup
        _library = library;
        _state = State.Greetings;

        //start state machine
        do
        {
            var newState = HandleState(_state);
            _state = newState.Execute();
        } while (_state != State.Exit);

        //end of state machine working
        System.Console.WriteLine("Допобачення!");
    }
    
    private static IStateCommand HandleState(State state)
        => state switch 
        {
            State.Greetings => new GreetingsCommand(_library),
            State.MainMenu => new MainMenuCommand(),
            State.Actions => new ActionsMenuCommand(),
            State.AdvancedInfo => new AdvancedInformationMenuCommand(_library),
            State.GenericInfo => new GenericInformationMenuCommand(),
            State.GetReaders => new GetReadersCommand(_library),
            State.GetRooms => new GetReadingRoomsCommand(_library),
            State.GetContainedBooks => new GetContainedBooksCommand(_library),
            State.GetCountOfBooksByAuthorInOneExample => 
                new GetReadersWhatTakenBooksWhichContainedInOnlyOneExampleCommand(_library),
            State.GetCountOfFreeSpaceInEveryRoom => 
                new GetCountOfFreeSpaceInEveryRoomCommand(_library),
            State.IsItPossibleToTakeABookFromLibrary => 
                new CheckIsItPossibleToTakeABookFromLibraryCommand(_library),
            State.WhatBooksGivenToEveryReaders => 
                new GetBooksAndReadersCommand(_library),
            State.GetBooksCountInReadingRoomByAuthor => 
                new GetBooksCountInReadingRoomByAuthorCommand(_library),
            State.BooksWithMaximalRatings => new GetBooksWithMaximalRatingsCommand(_library),
            State.AddExistedBook => new AddExistedBookCommand(_library),
            State.AddNewBook => new AddNewBookCommand(_library),
            State.RemoveBook => new RemoveBookCommand(_library),
            State.ReduceBooksQuantity => new ReduceBooksQuantityCommand(_library),
            State.AddRoom => new AddRoomCommand(_library),
            State.RemoveRoom => new RemoveRoomCommand(_library),
            State.RegisterReader => new RegisterNewReaderCommand(_library),
            State.RemoveReader => new RemoveReaderCommand(_library),
            State.TakeBook => new TakeBookCommand(_library),
            State.ReturnBook => new ReturnBookCommand(_library),
            _ => new ExitCommand()
        };
}