using Hwdtech;
namespace SpaceBattle.Lib;

public class StartMoveCommand: ICommand
{
    private IMoveCommandStartable obj;
    public StartMoveCommand(IMoveCommandStartable obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        IoC.Resolve<ICommand>("SpaceBattle.SetupProperty", obj.Obj, "Velocity", obj.InitialVelocity).Execute();
        var c = IoC.Resolve<ICommand>("SpaceBattle.Move", obj.Obj);
        IoC.Resolve<ICommand>("SpaceBattle.SetupCommand", obj.Obj, "Move", c).Execute();
        var queue = IoC.Resolve<Queue<ICommand>>("SpaceBattle.Queue");
        IoC.Resolve<ICommand>("SpaceBattle.QueuePush", queue, c).Execute();

    }
}
