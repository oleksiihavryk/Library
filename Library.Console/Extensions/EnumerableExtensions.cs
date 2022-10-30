namespace Library.Console.Extensions;
internal static class EnumerableExtensions
{
    internal static T? TakeRandom<T>(this IEnumerable<T> enumerable)
        where T : class
    {
        var enumArray = enumerable as T[] ?? enumerable.ToArray();
        int takePos = new Random().Next(minValue: 1, maxValue: enumArray.Count());
        return enumArray.Skip(--takePos).FirstOrDefault();
    }
}