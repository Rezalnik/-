namespace SpaceBattle.Lib;

public interface IRotate
{
    Degrees AngularVelocity { get; }
    Degrees Angle { get; set; }
}
