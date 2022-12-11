using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Abstraction;

public interface IStringInputToDataService
{
    public (CelestialBody?, CelestialBody?) ParseCelestialBodies(string[] args);
}