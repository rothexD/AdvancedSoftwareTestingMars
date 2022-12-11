using System;
using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Services;
using FakeItEasy;
using NUnit.Framework;

namespace AdvancedSoftwareTestingMars.Tests;

public class StringInputToDataServiceTests
{
    private readonly IDataManipulationService _dataManipulationService;
    private readonly StringInputToDataService _stringInputToDataService;

    public StringInputToDataServiceTests()
    {
        _dataManipulationService = A.Fake<IDataManipulationService>();
        _stringInputToDataService = new StringInputToDataService(_dataManipulationService);
    }
    
    [Test]
    public void ParseCelestialBodies_WhenValidData_ShouldParseSuccessfully()
    {
        A.CallTo(() => _dataManipulationService.StringOfTimeToInt("12", "32")).Returns(500);
        A.CallTo(() => _dataManipulationService.StringOfTimeToInt("17", "06")).Returns(400);
        A.CallTo(() => _dataManipulationService.StringOfTimeToInt("9", "78")).Returns(300);
        
        var (body1,body2) = _stringInputToDataService.ParseCelestialBodies(new[] {"D[12:32, 17:06]", "P[17:06, 9:78]"});
        
        Assert.AreEqual("D[12:32, 17:06]",body1.CreatedFromString);
        Assert.AreEqual("P[17:06, 9:78]",body2.CreatedFromString);
        
        Assert.AreEqual(500,body1.Rise);
        Assert.AreEqual(400,body2.Rise);
        
        Assert.AreEqual(400,body1.Set);
        Assert.AreEqual(300,body2.Set);
    }
    
}