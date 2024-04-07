namespace SpaceBattle.Lib;
using Hwdtech;
using System.Collections.Concurrent;

public class ConsoleServer
{
    public static void Main(string[] args){
        int numThread = int.Parse(args[0]);

        Console.WriteLine("Запуск сервера...");
        IoC.Resolve<ICommand>("ConsoleStartServer", numThread).Execute();
        Console.WriteLine("Все потоки успешно запущены");
        Console.WriteLine("Для остановки сервера нажмите любую клавишу");
        Console.Read();
        Console.WriteLine("Остановка сервера...");
        IoC.Resolve<ICommand>("ConsoleStopServer").Execute();
        Console.WriteLine("Завершение программы");
        Console.Read();
    }
}
