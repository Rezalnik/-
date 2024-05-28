namespace SpaceBattle.Lib;
using Hwdtech;

public class ExceptionHandlerStrategy : ICommand
{   
    ICommand command;
    Exception exception;
    public ExceptionHandlerStrategy(ICommand command, Exception exception)
    {
        this.command = command;
        this.exception = exception;
    }
    public void Execute()
    {
        string logFileName = IoC.Resolve<string>("Exception.GetLogName", exception);
        string errorMessage = $"Error in command '{command.GetType().Name}': {exception.Message}";

        using (StreamWriter writer = new StreamWriter(logFileName, true))
        {
            writer.WriteLine(errorMessage);
        }
    }
}
