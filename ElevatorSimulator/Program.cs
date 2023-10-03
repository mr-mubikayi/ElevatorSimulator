using ElevatorSimulator.Classes;
using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Helpers;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IConsoleService consoleService = new ConsoleService();

            try
            {
                consoleService.WriteLine(DisplayTexts.TITLE_TEXT);

                var isProgramLoopActive = true;
                var elevatorFactory = new ElevatorFactory(consoleService);
                elevatorFactory.AddElevators(ElevatorType.Passenger, 3);

                while (isProgramLoopActive)
                {
                    var userResponse = ValidNumberChecker.GetValidNumber(DisplayTexts.MAIN_MENU_TEXT, 3, consoleService);

                    switch (userResponse)
                    {
                        case 1:
                            await CallElevator(elevatorFactory, consoleService);
                            break;

                        case 2:
                            DisplayElevatorStatus(elevatorFactory, consoleService);
                            break;

                        case 3:
                            isProgramLoopActive = false;
                            return;

                        default:
                            consoleService.WriteLine(DisplayTexts.INVALID_OPTION_TEXT);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                consoleService.WriteLine(string.Format(DisplayTexts.ERROR_OCCURED, ex.Message));
            }
        }

        private static async Task CallElevator(ElevatorFactory elevatorFactory, IConsoleService consoleService)
        {
            var currentFloorLevel = GetFloorInput(DisplayTexts.ENTER_CURRENT_FLOOR_TEXT, consoleService);
            var elevator = elevatorFactory.GetElevator(ElevatorType.Passenger, currentFloorLevel);

            if (elevator == null)
            {
                consoleService.WriteLine(DisplayTexts.NO_AVAILABLE_ELEVATOR_TEXT);
                return;
            }

            await elevator.CallElevator(currentFloorLevel);
            await GoToDesiredFloor(elevator, consoleService);
            DisplayElevatorStatus(elevatorFactory, consoleService);

            consoleService.Write(DisplayTexts.KEY_PRESS_TEXT);
            consoleService.ReadKey();
        }

        private static async Task GoToDesiredFloor(IElevator elevator, IConsoleService consoleService)
        {
            var desiredFloorLevel = GetFloorInput(DisplayTexts.ENTER_DESIRED_FLOOR_TEXT, consoleService);
            await elevator.GoToFloor(desiredFloorLevel);
        }

        private static FloorLevel GetFloorInput(string message, IConsoleService consoleService)
        {
            try
            {
                return (FloorLevel)ValidNumberChecker.GetValidNumber(message, 3, consoleService) - 1;
            }
            catch
            {
                consoleService.WriteLine(DisplayTexts.ERROR_GETTING_FLOOR_INPUT);
                throw; 
            }
        }

        private static void DisplayElevatorStatus(ElevatorFactory elevatorFactory, IConsoleService consoleService)
        {
            consoleService.WriteLine(DisplayTexts.PASSENGER_ELEVATOR_TEXT);
            DisplayElevatorStatusForType(elevatorFactory, ElevatorType.Passenger, consoleService);
        }

        private static void DisplayElevatorStatusForType(ElevatorFactory elevatorFactory, ElevatorType type, IConsoleService consoleService)
        {
            var elevators = elevatorFactory.GetAllElevatorsByType(type).ToList();

            foreach (var elevator in elevators)
            {
                consoleService.WriteLine($"- {DisplayTexts.ELEVATOR_TEXT} {elevator.Id.ToString().Split('-')[0]}, " +
                                  $"{DisplayTexts.FLOOR_TEXT} {elevator.CurrentFloor}, " +
                                  $"{DisplayTexts.DIRECTION_TEXT} {elevator.Direction}, " +
                                  $"{DisplayTexts.PASSENGERS_TEXT} {elevator.PassengerCount}/{elevator.MaxPassengerCount}");
            }
        }
    }
}
