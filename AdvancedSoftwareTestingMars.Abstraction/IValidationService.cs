using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Abstraction;

public interface IValidationService
{
    public void Validate(CelestialBody? celestialBody);
}