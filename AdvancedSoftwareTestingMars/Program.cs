// See https://aka.ms/new-console-template for more information

using System.Text;
using AdvancedSoftwareTestingMars.Services;

Console.WriteLine("Hello, Mars!");

var dataManipulationService = new DataManipulationService();
var environmentVariableToDataService = new StringInputToDataService(dataManipulationService);
var validationService = new ValidationService();
var timeIntervalCalculationService = new TimeIntervalCalculationService();

var timeIntervalService = new TimeIntervalCalculationProcess(validationService,timeIntervalCalculationService,environmentVariableToDataService,dataManipulationService);

var commandLineArgs = Environment.GetCommandLineArgs();

try
{
   var timeFrame = timeIntervalService.GetTimeInterval(new[]{commandLineArgs[1],commandLineArgs[2]});
   Console.WriteLine($"i found an interval of length {timeFrame} which would be {dataManipulationService.IntToMartianHoursAndMinutes(timeFrame)} in martian time");
   return timeFrame;
}
catch (ArgumentException ex)
{
   Console.WriteLine(ex.Message);
   return -1;
}