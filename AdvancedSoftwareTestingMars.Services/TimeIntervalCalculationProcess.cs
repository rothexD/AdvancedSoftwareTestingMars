using AdvancedSoftwareTestingMars.Abstraction;

namespace AdvancedSoftwareTestingMars.Services;

public class TimeIntervalCalculationProcess : ITimeIntervalCalculationProcess
{
    private readonly Abstraction.IStringInputToDataService _stringInputToDataService;
    private readonly ITimeIntervalCalculationService _timeIntervalCalculationService;
    private readonly IValidationService _validationService;
    private readonly IDataManipulationService _dataManipulationService;
    public TimeIntervalCalculationProcess(IValidationService validationService,
        ITimeIntervalCalculationService timeIntervalCalculationService,
        Abstraction.IStringInputToDataService stringInputToDataService,
        IDataManipulationService dataManipulationService)
    {
        _validationService = validationService;
        _timeIntervalCalculationService = timeIntervalCalculationService;
        _stringInputToDataService = stringInputToDataService;
        _dataManipulationService = dataManipulationService;
    }

    public int GetTimeInterval(string[] args)
    {
        var (celestialBody1, celestialBody2) = _stringInputToDataService.ParseCelestialBodies(args);

        _validationService.Validate(celestialBody1);
        _validationService.Validate(celestialBody2);

        _dataManipulationService.GetAdjustedCelestialBodySet(celestialBody1,celestialBody2);
        
        return _timeIntervalCalculationService.GetOverlap(celestialBody1, celestialBody2);
    }
}