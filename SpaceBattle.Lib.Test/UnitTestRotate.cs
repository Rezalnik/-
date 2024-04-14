using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test;

public class UnitTestRotate
{

    [Fact]
    public void TestPositive()
    {
        //PRE
        Mock<IRotate> rotatable = new Mock<IRotate>();
        rotatable.SetupProperty(r => r.Angle, new Degrees(45));
        rotatable.SetupGet(r => r.AngularVelocity).Returns(new Degrees(90));

        //ACTION
        RotateCommand command = new RotateCommand(rotatable.Object);
        command.Execute();

        //POST
        Assert.Equal(new Degrees(135), rotatable.Object.Angle);
    }



    [Fact]
    public void TestNegGetAngle()
    {
        //PRE
        Mock<IRotate> rotatable = new Mock<IRotate>();
        rotatable.SetupProperty(r => r.Angle, new Degrees(45));
        rotatable.SetupGet<Degrees>(r => r.AngularVelocity).Returns(new Degrees(90));
        rotatable.SetupGet<Degrees>(r => r.Angle).Throws<Exception>();

        //ACTION
        RotateCommand command = new RotateCommand(rotatable.Object);

        //POST
        Assert.Throws<Exception>(() => command.Execute());
    }



    [Fact]
    public void TestNegGetAngularVelocity()
    {
        //PRE
        Mock<IRotate> rotatable = new Mock<IRotate>();
        rotatable.SetupProperty(r => r.Angle, new Degrees(45));
        rotatable.SetupGet<Degrees>(r => r.AngularVelocity).Throws<Exception>();

        //ACTION
        RotateCommand command = new RotateCommand(rotatable.Object);

        //POST
        Assert.Throws<Exception>(() => command.Execute());
    }


    [Fact]
    public void TestNegSetAngle()
    {
        //PRE
        Mock<IRotate> rotatable = new Mock<IRotate>();
        rotatable.SetupProperty(r => r.Angle, new Degrees(45));
        rotatable.SetupGet(r => r.AngularVelocity).Returns(new Degrees(90));
        rotatable.SetupSet(r => r.Angle = It.IsAny<Degrees>()).Throws<Exception>();

        //ACTION
        RotateCommand command = new RotateCommand(rotatable.Object);

        //POST
        Assert.Throws<Exception>(() =>  command.Execute());
    }

}
