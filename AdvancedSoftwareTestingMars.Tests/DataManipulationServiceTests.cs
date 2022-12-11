using System.Runtime.InteropServices.ObjectiveC;
using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Constants;
using AdvancedSoftwareTestingMars.Models;
using AdvancedSoftwareTestingMars.Services;
using NUnit.Framework;

namespace AdvancedSoftwareTestingMars.Tests;

public class DataManipulationServiceTests
{
    private readonly DataManipulationService _service;

    public DataManipulationServiceTests()
    {
        _service = new DataManipulationService();
    }

    [Test]
    public void GetAdjustedCelestialBodySet_WhenNoMidnightOverlap_ShouldNotTransform()
    {
        const int body1Rise = 100;
        const int body1Set = 200;
        const int body2Rise = 300;
        const int body2Set = 400;
        
        var body1 = new CelestialBody("1", body1Rise, body1Set);
        var body2 = new CelestialBody("1", body2Rise, body2Set);
        
        _service.GetAdjustedCelestialBodySet(body1,body2);
        
        Assert.AreEqual(body1Rise,body1.Rise);
        Assert.AreEqual(body1Set,body1.Set);
        Assert.AreEqual(body2Rise,body2.Rise);
        Assert.AreEqual(body2Set,body2.Set);
    }
    
    [Test]
    public void GetAdjustedCelestialBodySet_WhenOneMidnightOverlap_ShouldNotTransform()
    {
        const int body1Rise = TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
        const int body1Set = 200;
        const int body2Rise = 300;
        const int body2Set = 400;
        
        var body1 = new CelestialBody("1", body1Rise, body1Set);
        var body2 = new CelestialBody("1", body2Rise, body2Set);
        
        _service.GetAdjustedCelestialBodySet(body1,body2);
        
        Assert.AreEqual(body1Rise,body1.Rise);
        Assert.AreEqual(body1Set + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body1.Set);
        Assert.AreEqual(body2Rise + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body2.Rise);
        Assert.AreEqual(body2Set + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body2.Set);
    }
    
    [Test]
    public void GetAdjustedCelestialBodySet_WhenBothMidnightOverlap_ShouldNotTransform()
    {
        const int body1Rise = TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
        const int body1Set = 200;
        const int body2Rise = TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
        const int body2Set = 400;
        
        var body1 = new CelestialBody("1", body1Rise, body1Set);
        var body2 = new CelestialBody("1", body2Rise, body2Set);
        
        _service.GetAdjustedCelestialBodySet(body1,body2);
        
        Assert.AreEqual(body1Rise + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body1.Rise);
        Assert.AreEqual(body1Set + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body1.Set);
        Assert.AreEqual(body2Rise + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body2.Rise);
        Assert.AreEqual(body2Set + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour + TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour,body2.Set);
    }
}