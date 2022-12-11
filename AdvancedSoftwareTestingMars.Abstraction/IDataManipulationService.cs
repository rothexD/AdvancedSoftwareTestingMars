using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Abstraction;

public interface IDataManipulationService
{
    public int StringOfTimeToInt(string hours, string minutes);
    public string IntToMartianHoursAndMinutes(int minutes);

    public void GetAdjustedCelestialBodySet(CelestialBody? celestialBody1,CelestialBody? celestialBody2);
}