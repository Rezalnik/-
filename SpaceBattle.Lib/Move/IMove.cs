namespace SpaceBattle.Lib;
public interface IMove
{
    Vector Velocity { get; }
    Vector Position { get; set; }
}
