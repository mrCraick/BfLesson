using System;
using System.Linq;
using BrainFuck.Interfaces.IO;
using BrainFuck.IO;
using Moq;
using Xunit;

namespace BrainFuckTestProject;

public class BfCodeDebugOutputTests
{
    [Fact]
    public void PrintNextStepShouldBeMoveCarriage()
    {
        // arrange

        const int windowWidth = 30;

        var windowSettingMock = new Mock<IWindowSetting>();
        windowSettingMock.Setup(x => x.WindowWidth).Returns(windowWidth);
        var bfCodeSample = new string(Enumerable.Repeat('+', 10).ToArray());

        var bfCodeDebugOutput = new BfCodeDebugOutput(bfCodeSample, windowSettingMock.Object);
        bfCodeDebugOutput.MoveToBfCode(); // todo ref

        // act

        var actual = bfCodeDebugOutput.PrintNextStep();
        var actualContent = bfCodeDebugOutput.GetContent();

        // assert

        Assert.True(actual);
        Assert.Equal($"{bfCodeSample}{Environment.NewLine} {BfCodeDebugOutput.DEFAULT_CARRIAGE_SYMBOL}{Environment.NewLine}", actualContent);
    }
}