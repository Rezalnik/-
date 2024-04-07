namespace SpaceBattle.Lib;
using Hwdtech;

public class ConsoleStopServer : ICommand
{
    public void Execute()
    {   
        Dictionary<string, string> myThreads = IoC.Resolve<Dictionary<string, string>>("GetDictionary");
        foreach (string threadId in myThreads.Keys)
        {
            IoC.Resolve<ICommand>("HardStopThreads", threadId).Execute();
        }
    }
}
