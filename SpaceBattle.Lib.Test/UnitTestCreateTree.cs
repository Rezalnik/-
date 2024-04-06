using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using Xunit;

namespace SpaceBattle.Lib.Test;

public class TestCreateTree
{
    Mock<IStrategy> CreateTreefromtxtStrategy = new Mock<IStrategy>();
    public TestCreateTree()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "GetCollisionTree", (object[] args) => CreateTreefromtxtStrategy.Object.ExecuteStrategy(args)).Execute();
    }

    [Fact]
    public void TestPositive(){

        string way = @"../../../../SpaceBattle.Lib.Test/CollisionVectors.txt";
        CreateTreefromtxtStrategy.Setup(t => t.ExecuteStrategy(It.IsAny<object[]>())).Returns(new Dictionary<string, object>()).Verifiable();

        var Tree = new CreateTreeFromtxt_2();
        Tree.ExecuteStrategy(way);
        
        CreateTreefromtxtStrategy.Verify();
    }

    [Fact]
    public void TestNegFileNotFound(){
        var way = @"../../../../not_existed.txt";
        CreateTreefromtxtStrategy.Setup(t => t.ExecuteStrategy(It.IsAny<object[]>())).Returns(new Dictionary<string, object>()).Verifiable();
        var Tree = new CreateTreeFromtxt_2();
        Assert.Throws<Exception>(() => Tree.ExecuteStrategy(way));
        CreateTreefromtxtStrategy.Verify();
    }

    [Fact]
    public void TestNegArgument(){
        string way = @"";
        CreateTreefromtxtStrategy.Setup(t => t.ExecuteStrategy(It.IsAny<object[]>())).Returns(new Dictionary<string, object>()).Verifiable();
        var Tree = new CreateTreeFromtxt_2();
        Assert.Throws<Exception>(() => Tree.ExecuteStrategy(way));
        CreateTreefromtxtStrategy.Verify();
    }

    [Fact]
    public void TestNegDirectoryNotFound(){
        string way = @"../../../../folder_not_exist/CollisionVectors.txt";
        CreateTreefromtxtStrategy.Setup(t => t.ExecuteStrategy(It.IsAny<object[]>())).Returns(new Dictionary<string, object>()).Verifiable();
        var Tree = new CreateTreeFromtxt_2();
        Assert.Throws<Exception>(() => Tree.ExecuteStrategy(way));
        CreateTreefromtxtStrategy.Verify();
    }
}
