namespace Library.Console.Application.Commands;
internal class ExitCommand : ApplicationStateCommand
{
    public override State Execute()
    {
        System.Console.Clear();
        return State.Exit;
    }
}