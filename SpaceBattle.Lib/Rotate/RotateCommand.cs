namespace SpaceBattle.Lib;

public class RotateCommand : ICommand
{
    private IRotate obj;
    public RotateCommand(IRotate obj){
        this.obj = obj;
    }
    public void Execute()
    {
        obj.Angle = obj.Angle + obj.AngularVelocity;
    }
}
