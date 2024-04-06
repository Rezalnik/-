using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using Xunit;

namespace SpaceBattle.Lib.Test;

public class TestStartMoveCommand
{
    public TestStartMoveCommand()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        var cmd = new Mock<ICommand>();
        cmd.Setup(c => c.Execute());
        
        var returnCmd = new Mock<IStrategy>();
        returnCmd.Setup(c => c.ExecuteStrategy(It.IsAny<object[]>())).Returns(cmd.Object);

        var returnQueue = new Mock<IStrategy>();
        returnQueue.Setup(x => x.ExecuteStrategy()).Returns(new Queue<ICommand>());

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "SpaceBattle.SetupProperty", (object[] args) => returnCmd.Object.ExecuteStrategy(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "SpaceBattle.SetupCommand", (object[] args) => returnCmd.Object.ExecuteStrategy(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "SpaceBattle.Move", (object[] args) => returnCmd.Object.ExecuteStrategy(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "SpaceBattle.Queue", (object[] args) => returnQueue.Object.ExecuteStrategy()).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "SpaceBattle.QueuePush", (object[] args) => returnCmd.Object.ExecuteStrategy(args)).Execute();
        
    }

    [Fact]
    public void TestPositive()
    {
        var start_move = new Mock<IMoveCommandStartable>();
        start_move.SetupGet(s => s.Obj).Returns(new Mock<IUObject>().Object).Verifiable();
        start_move.SetupGet(s => s.InitialVelocity).Returns(new Vector(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
        
        ICommand startMove = new StartMoveCommand(start_move.Object);
        startMove.Execute();
        start_move.Verify();
    }

    [Fact]
    public void TestNegGetObj()
    {
        var start_move = new Mock<IMoveCommandStartable>();
        start_move.SetupGet(s => s.Obj).Throws<Exception>().Verifiable();
        start_move.SetupGet(s => s.InitialVelocity).Returns(new Vector(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

        ICommand startMove = new StartMoveCommand(start_move.Object);

        Assert.Throws<Exception>(() => startMove.Execute());
    }

    [Fact]
    public void TestNegGetInitialVelocity()
    {
        var start_move = new Mock<IMoveCommandStartable>();
        start_move.SetupGet(s => s.Obj).Returns(new Mock<IUObject>().Object).Verifiable();
        start_move.SetupGet(s => s.InitialVelocity).Throws<Exception>().Verifiable();

        ICommand startMove = new StartMoveCommand(start_move.Object);

        Assert.Throws<Exception>(() => startMove.Execute());
    }

}
