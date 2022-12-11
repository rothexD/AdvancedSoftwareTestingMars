using System;
using AdvancedSoftwareTestingMars.Constants;
using AdvancedSoftwareTestingMars.Models;
using AdvancedSoftwareTestingMars.Services;
using NUnit.Framework;

namespace AdvancedSoftwareTestingMars.Tests;

public class ValidationServiceTests
{
    private readonly ValidationService _service;

    public ValidationServiceTests()
    {
        _service = new ValidationService();
    }

    [Test]
    public void Validate_WhenValidDate_ShouldNotThrowExceptions()
    {
        var celestialBody = new CelestialBody("1", TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour, 0);
        
        _service.Validate(celestialBody);
    }
    
    [Test]
    public void Validate_WhenTooLarge_ShouldThrowExceptions()
    {
        var celestialBody = new CelestialBody("1", TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour + 1, TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour + 1);
        
        Assert.Throws<ArgumentException>(() => _service.Validate(celestialBody));
    }
    
    [Test]
    public void Validate_WhenTooSmall_ShouldThrowExceptions()
    {
        var celestialBody = new CelestialBody("1", -1, -1);
        
        Assert.Throws<ArgumentException>(() => _service.Validate(celestialBody));
    }
}