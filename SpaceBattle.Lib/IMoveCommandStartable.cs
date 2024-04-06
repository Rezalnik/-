namespace SpaceBattle.Lib;

public interface IMoveCommandStartable
{
    IUObject Obj { get; }
    Vector InitialVelocity { get; }
}
