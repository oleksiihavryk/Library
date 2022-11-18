using System.Text;

namespace Library.Console.Application.Commands;
public abstract class ApplicationStateCommand : IStateCommand
{
    public abstract State Execute();

    protected static int GetIntegerUserInput(int to)
    {
        int userInput;
        bool firstInput = true;

        do
        {
            try
            {
                if (!firstInput)
                    System.Console.WriteLine("Команду введено неправильно! Спробуйте ще раз!");

                userInput = Convert.ToInt32(GetStringUserInput());

                if (userInput > 0 && userInput <= to)
                    break;
            }
            catch
            {
                // ignored
            }

            firstInput = false;
        }
        while (true);
        
        return userInput;
    }
    protected static string GetStringUserInput()
        => System.Console.ReadLine() ?? string.Empty;
    protected static DateTime GetDateTimeUserInput()
    {
        DateTime userInput;
        bool firstInput = true;

        System.Console.WriteLine("Правильна форма написання дати: " +
                                 "рік.місяць.день години:хвилини (форма: xxxx.xx.xx xx:xx)");
        do
        {
            try
            {
                if (!firstInput)
                    System.Console.WriteLine("Команду введено неправильно! Спробуйте ще раз!");

                userInput = Convert.ToDateTime(GetStringUserInput());
                break;
            }
            catch
            {
                // ignored
            }

            firstInput = false;
        }
        while (true);

        return userInput;
    }
    protected static T GetItemFromMultipleVariant<T>(
        IEnumerable<T> variants)
    {
        var variantsArray = variants as T[] ?? variants.ToArray();
        int counter = 0;
        System.Console.WriteLine("-----------------------------");
        foreach (var i in variantsArray)
        {
            System.Console.WriteLine($"{++counter}." + Environment.NewLine + i);
        }

        var choice = GetIntegerUserInput(to: counter);
        return variantsArray.Skip(--choice).First();
    }
}