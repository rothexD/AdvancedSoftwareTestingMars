using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Constants;
using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Services;

public class DataManipulationService : IDataManipulationService
{
    public int StringOfTimeToInt(string hours, string minutes)
    {
        return Convert.ToInt32(hours) * TimeConstants.MinutesPerHour + Convert.ToInt32(minutes);
    }
    public string IntToMartianHoursAndMinutes(int minutes)
    {
        return (minutes/TimeConstants.MinutesPerHour).ToString("00") + ":" + (minutes % TimeConstants.MinutesPerHour).ToString("00");
    }
    
    public void GetAdjustedCelestialBodySet(CelestialBody? celestialBody1,CelestialBody celestialBody2)
    {
        if (celestialBody1 is not null  && celestialBody1.Set < celestialBody1.Rise)
        {
            celestialBody1.Set += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
            celestialBody2.Set += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
            celestialBody2.Rise += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
        }
        if (celestialBody2 is not null  && celestialBody2.Set < celestialBody2.Rise)
        {
            celestialBody2.Set += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
            celestialBody1.Set += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
            celestialBody1.Rise += TimeConstants.HoursPerDay * TimeConstants.MinutesPerHour;
        }
    }
}