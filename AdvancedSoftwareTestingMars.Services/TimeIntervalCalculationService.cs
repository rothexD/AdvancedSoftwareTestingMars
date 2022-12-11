using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Services;

public class TimeIntervalCalculationService : ITimeIntervalCalculationService
{
    public int GetOverlap(CelestialBody celestialBody1, CelestialBody celestialBody2)
    {
        return FindOverlapType(celestialBody1,celestialBody2) 
            switch
            {
                Overlap.Lonely => 0,
                Overlap.OK => CalculateOverlapLength(celestialBody1, celestialBody2),
                Overlap.InOnePoint => 1,
                _ => throw new NotImplementedException()
            };
    }

    private static int CalculateOverlapLength(CelestialBody celestialBody1, CelestialBody celestialBody2)
    {
        return Math.Abs(Math.Max(celestialBody1.Rise, celestialBody2.Rise) -
                        Math.Min(celestialBody1.Set, celestialBody2.Set));
    }

    private static Overlap FindOverlapType(CelestialBody celestialBody1,CelestialBody celestialBody2)
    {
        if (celestialBody1.Rise == celestialBody2.Set || celestialBody1.Set == celestialBody2.Rise)
            return Overlap.InOnePoint;
        if (Math.Max(celestialBody1.Rise, celestialBody2.Rise) < Math.Min(celestialBody1.Set, celestialBody2.Set))
            return Overlap.OK;

        return Overlap.Lonely;
    }
}