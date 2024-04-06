using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test;

public class MoveCommandTests
{
    [Fact]
    public void TestPositive()
    {
        //PRE
        Mock<IMove> movable = new Mock<IMove>();
        movable.SetupProperty(m => m.Position, new Vector(12, 5));
        movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

        //ACTION
        MoveCommand command = new MoveCommand(movable.Object);
        command.Execute();

        //POST
        Assert.Equal(new Vector(5, 8), movable.Object.Position);
    }



    [Fact]
    public void TestNegGetPosition()
    {
        //PRE
        Mock<IMove> movable = new Mock<IMove>();
        movable.SetupProperty(m => m.Position, new Vector(12, 5));
        movable.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3));
        movable.SetupGet<Vector>(m => m.Position).Throws<Exception>();

        //ACTION
        MoveCommand command = new MoveCommand(movable.Object);

        //POST
        Assert.Throws<Exception>(() =>  command.Execute());
    }



    [Fact]
    public void TestNegGetVelosity()
    {
        //PRE
        Mock<IMove> movable = new Mock<IMove>();
        movable.SetupProperty(m => m.Position, new Vector(12, 5));
        movable.SetupGet<Vector>(m => m.Velocity).Throws<Exception>();

        //ACTION
        MoveCommand command = new MoveCommand(movable.Object);

        //POST
        Assert.Throws<Exception>(() =>  command.Execute());
    }


    [Fact]
    public void TestNegSetPosition()
    {
        //PRE
        Mock<IMove> movable = new Mock<IMove>();
        movable.SetupProperty(m => m.Position, new Vector(12, 5));
        movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));
        movable.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();

        //ACTION
        MoveCommand command = new MoveCommand(movable.Object);

        //POST
        Assert.Throws<Exception>(() =>  command.Execute());
    }
}
