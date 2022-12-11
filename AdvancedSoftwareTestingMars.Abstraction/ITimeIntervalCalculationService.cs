using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Abstraction;

public interface ITimeIntervalCalculationService
{
    public int GetOverlap(CelestialBody celestialBody1, CelestialBody celestialBody2);
}