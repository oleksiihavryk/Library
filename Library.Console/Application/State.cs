namespace Library.Console.Application;
/// <summary>
///     Application state
/// </summary>
public enum State
{
    /// <summary>
    ///     Greeting state
    /// </summary>
    Greetings,
    /// <summary>
    ///     Main menu state
    /// </summary>
    MainMenu,
        /// <summary>
        ///     Generic information menu state
        /// </summary>
        GenericInfo,
            /// <summary>
            ///     Get contained books from system state
            /// </summary>
            GetContainedBooks,
            /// <summary>
            ///     Get readers from system state
            /// </summary>
            GetReaders,
            /// <summary>
            ///     Get rooms from system state
            /// </summary>
            GetRooms,
        /// <summary>
        ///     Advanced information menu state
        /// </summary>
        AdvancedInfo,
            /// <summary>
            ///     Get books quantity in reading room by author info from system state
            /// </summary>
            GetBooksCountInReadingRoomByAuthor,
            /// <summary>
            ///     Get books with maximal ratings info from system state
            /// </summary>
            BooksWithMaximalRatings,
            /// <summary>
            ///     Get count of free space in every room info from system state
            /// </summary>
            GetCountOfFreeSpaceInEveryRoom,
            /// <summary>
            ///     Get books given to every readers info from system state
            /// </summary>
            WhatBooksGivenToEveryReaders,
            /// <summary>
            ///     Have a opportunity to take a book from library info state
            /// </summary>
            IsItPossibleToTakeABookFromLibrary,
            /// <summary>
            ///     Get count of books by passed author in one example info state
            /// </summary>
            GetCountOfBooksByAuthorInOneExample,
        /// <summary>
        ///     Actions menu state 
        /// </summary>
        Actions,
            /// <summary>
            ///     Register reader state
            /// </summary>
            RegisterReader,
            /// <summary>
            ///     Remove reader state
            /// </summary>
            RemoveReader,
            /// <summary>
            ///     Add book state
            /// </summary>
            AddNewBook,
            /// <summary>
            ///     Add existed book
            /// </summary>
            AddExistedBook,
            /// <summary>
            ///     Remove book state
            /// </summary>
            RemoveBook,
            /// <summary>
            ///     Reduce books quantity
            /// </summary>
            ReduceBooksQuantity,
            /// <summary>
            ///     Add room state
            /// </summary>
            AddRoom,
            /// <summary>
            ///     Remove book state
            /// </summary>
            RemoveRoom,
            /// <summary>
            ///     Return book state
            /// </summary>
            ReturnBook,
            /// <summary>
            ///     Take book state
            /// </summary>
            TakeBook,
    /// <summary>
    ///     Exit from system state
    /// </summary>
    Exit,
}