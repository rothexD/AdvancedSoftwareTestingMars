using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Constants;
using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Services;

public class ValidationService : IValidationService
{
    public void Validate(CelestialBody? celestialBody)
    {
        if (celestialBody is null)
        {
            throw new ArgumentException($"one celestial body was not valid");
        }
        if (celestialBody.Rise is > TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour or < 0)
        {
            throw new ArgumentException($"{nameof(celestialBody.Rise)} is invalid time {celestialBody.Rise}");
        }
        if (celestialBody.Set is > TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour or < 0)
        {
            throw new ArgumentException($"{nameof(celestialBody.Set)} is invalid time {celestialBody.Set}");
        }
    }
}