namespace SpaceBattle.Lib;
using Hwdtech;
using System.Collections.Concurrent;

public class ConsoleStartServer : ICommand
{
    private int numThread;
    public ConsoleStartServer(int numThread)
    {
        this.numThread = numThread;
    }
    public void Execute()
    {
        for (int i = 0; i < numThread; i++)
        {   
            IoC.Resolve<ICommand>("CreateAndStartThread").Execute();
        }
    }
}
