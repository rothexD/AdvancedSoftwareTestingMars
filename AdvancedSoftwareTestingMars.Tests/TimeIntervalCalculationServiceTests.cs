using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Constants;
using AdvancedSoftwareTestingMars.Models;
using AdvancedSoftwareTestingMars.Services;
using NUnit.Framework;

namespace AdvancedSoftwareTestingMars.Tests;

public class TimeIntervalCalculationServiceTests
{
    private readonly TimeIntervalCalculationService _service;

    public TimeIntervalCalculationServiceTests()
    {
        _service = new TimeIntervalCalculationService();
    }

    [Test]
    public void TimeIntervalCalculationService_WhenNoOverlap_ShouldReturn0()
    {
        var body1 = new CelestialBody("a", 0, 1);
        var body2 = new CelestialBody("a", 2, 3);

        var result = _service.GetOverlap(body1, body2);
        
        Assert.AreEqual(0,result);
    }
    
    [Test]
    public void TimeIntervalCalculationService_WhenOverlapInOnePoint_ShouldReturn1()
    {
        var body1 = new CelestialBody("a", 0, 1);
        var body2 = new CelestialBody("a", 1, 3);

        var result = _service.GetOverlap(body1, body2);
        
        Assert.AreEqual(1,result);
    }
    
    [Test]
    public void TimeIntervalCalculationService_WhenOverlap_ShouldReturn100()
    {
        var body1 = new CelestialBody("a", 0, 120);
        var body2 = new CelestialBody("a", 20, 220);

        var result = _service.GetOverlap(body1, body2);

        Assert.AreEqual(100,result);
    }
}