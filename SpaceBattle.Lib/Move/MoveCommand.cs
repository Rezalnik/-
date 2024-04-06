//using SpaceBattle.Lib;
namespace SpaceBattle.Lib;

public class MoveCommand : ICommand
{
    private IMove obj;
    public MoveCommand(IMove obj){
        this.obj = obj;
    }
    public void Execute()
    {
        obj.Position = obj.Position + obj.Velocity;
    }
}
