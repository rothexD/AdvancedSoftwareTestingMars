namespace AdvancedSoftwareTestingMars.Models;

public class CelestialBody
{
    public readonly string CreatedFromString;
    public int Rise;
    public int Set;

    public CelestialBody(string createdFromString, int rise, int set)
    {
        CreatedFromString = createdFromString;
        Rise = rise;
        Set = set;
    }
}