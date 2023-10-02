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
            Console.WriteLine(DisplayTexts.TITLE_TEXT);

            var isProgramLoopActive = true;
            var elevatorFactory = new ElevatorFactory();
            elevatorFactory.AddElevators(ElevatorType.Passenger, 3);

            while (isProgramLoopActive)
            {
                var userResponse = ValidNumberChecker.GetValidNumber(DisplayTexts.MAIN_MENU_TEXT, 3);

                switch (userResponse)
                {
                    case 1:
                        await CallElevator(elevatorFactory);
                        break;

                    case 2:
                        DisplayElevatorStatus(elevatorFactory);
                        break;

                    case 3:
                        isProgramLoopActive = false;
                        return;

                    default:
                        Console.WriteLine(DisplayTexts.INVALID_OPTION_TEXT);
                        break;
                }
            }
        }

        private static async Task CallElevator(ElevatorFactory elevatorFactory)
        {
            var currentFloorLevel = GetFloorInput(DisplayTexts.ENTER_CURRENT_FLOOR_TEXT);
            var elevator = elevatorFactory.GetElevator(ElevatorType.Passenger, currentFloorLevel);

            if (elevator == null)
            {
                Console.WriteLine(DisplayTexts.NO_AVAILABLE_ELEVATOR_TEXT);
                return;
            }

            await elevator.CallElevator(currentFloorLevel);
            await GoToDesiredFloor(elevator);
            DisplayElevatorStatus(elevatorFactory);

            Console.Write(DisplayTexts.KEY_PRESS_TEXT);
            Console.ReadKey();
        }

        private static async Task GoToDesiredFloor(IElevator elevator)
        {
            var desiredFloorLevel = GetFloorInput(DisplayTexts.ENTER_DESIRED_FLOOR_TEXT);
            await elevator.GoToFloor(desiredFloorLevel);
        }

        private static FloorLevel GetFloorInput(string message)
        {
            return (FloorLevel)ValidNumberChecker.GetValidNumber(message, 3) - 1;
        }

        private static void DisplayElevatorStatus(ElevatorFactory elevatorFactory)
        {
            Console.WriteLine(DisplayTexts.PASSENGER_ELEVATOR_TEXT);
            DisplayElevatorStatusForType(elevatorFactory, ElevatorType.Passenger);
        }

        private static void DisplayElevatorStatusForType(ElevatorFactory elevatorFactory, ElevatorType type)
        {
            var elevators = elevatorFactory.GetAllElevatorsByType(type).ToList();

            foreach (var elevator in elevators)
            {
                Console.WriteLine($"- {DisplayTexts.ELEVATOR_TEXT} {elevator.Id.ToString().Split('-')[0]}, " +
                                  $"{DisplayTexts.FLOOR_TEXT} {elevator.CurrentFloor}, " +
                                  $"{DisplayTexts.DIRECTION_TEXT} {elevator.Direction}, " +
                                  $"{DisplayTexts.PASSENGERS_TEXT} {elevator.PassengerCount}/{elevator.MaxPassengerCount}");
            }
        }
    }
}