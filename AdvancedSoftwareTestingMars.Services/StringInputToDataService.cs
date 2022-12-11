using System.Text.RegularExpressions;
using AdvancedSoftwareTestingMars.Abstraction;
using AdvancedSoftwareTestingMars.Models;

namespace AdvancedSoftwareTestingMars.Services;

public class StringInputToDataService : IStringInputToDataService
{
    private readonly IDataManipulationService _dataManipulationService;

    public StringInputToDataService(IDataManipulationService dataManipulationService)
    {
        _dataManipulationService = dataManipulationService;
    }

    private const string TimeInputRegex = @"^[a-zA-Z]\[([0-9]?[0-9]):([0-9][0-9]), ([0-9]?[0-9]):([0-9][0-9])\]$";
    
    public (CelestialBody?,CelestialBody?) ParseCelestialBodies(string[] args)
    {
        CelestialBody? celestialBody1;
        CelestialBody? celestialBody2;
        
        if (args.Length != 2)
        {
            throw new ArgumentException($"args expected 2 but got {args.Length}");
        }

        if (Regex.IsMatch(args[0], TimeInputRegex))
        {
            var match = Regex.Match(args[0], TimeInputRegex);
            var rise = _dataManipulationService.StringOfTimeToInt(match.Groups[1].ToString(),
                match.Groups[2].ToString());
            var set = _dataManipulationService.StringOfTimeToInt(match.Groups[3].ToString(),
                match.Groups[4].ToString());
            celestialBody1 = new CelestialBody(match.Groups[0].ToString(), rise, set);
        }
        else
        {
            throw new ArgumentException("program argument1 does not match expected format");
        }
        if (Regex.IsMatch(args[1], TimeInputRegex))
        {
            var match = Regex.Match(args[1], TimeInputRegex);
            var rise = _dataManipulationService.StringOfTimeToInt(match.Groups[1].ToString(),
                match.Groups[2].ToString());
            var set = _dataManipulationService.StringOfTimeToInt(match.Groups[3].ToString(),
                match.Groups[4].ToString());
            celestialBody2 = new CelestialBody(match.Groups[0].ToString(), rise, set);
        }
        else
        {
            throw new ArgumentException("program argument2 does not match expected format");
        }
    
        return (celestialBody1,celestialBody2);
    }
}