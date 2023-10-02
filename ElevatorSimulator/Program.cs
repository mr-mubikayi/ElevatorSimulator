using ElevatorSimulator.Classes;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Helpers;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\n       ELEVATOR SIMULATOR");

            var isProgramLoopActive = true;
            var mainMenuText =
@"

.__________ Main Menu __________.
|                               |
|   1. Call Elevator            |
|   2. Display Elevator Status  |
|   3. Exit                     | 
|_______________________________|

Choose an Option (1, 2, 3): ";

            var elevatorFactory = new ElevatorFactory();
            elevatorFactory.AddElevators(ElevatorType.Passenger, 3);

            while (isProgramLoopActive)
            {
                var userResponse = ValidNumberChecker.GetValidNumber(mainMenuText, 3);

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
                        Console.WriteLine("\nInvalid Option. Try Again.");
                        break;
                }
            }
        }
        private static async Task CallElevator(ElevatorFactory elevatorFactory)
        {
            var currentFloorInputText = "\nEnter Your Current Floor Number (1, 2, 3): ";
            var currentFloorLevel = (FloorLevel)ValidNumberChecker.GetValidNumber(currentFloorInputText, 3) - 1;

            var elevator = elevatorFactory.GetElevator(ElevatorType.Passenger, currentFloorLevel);

            if(elevator == null)
            {
                Console.WriteLine("\nNo available elevators at the moment. Please wait.");
                return;
            }

            await elevator.CallElevator(currentFloorLevel);
            await GoToDesiredFloor(elevator);

            DisplayElevatorStatus(elevatorFactory);

            Console.Write("\nPress Any Key to continue");
            Console.ReadKey();
        }

        private static async Task GoToDesiredFloor(IElevator elevator)
        {
            var goToFloorText = $"\nEnter Your Desired Floor Level (1, 2, 3): ";
            var desiredFloorLevel = (FloorLevel)ValidNumberChecker.GetValidNumber(goToFloorText, 3) - 1;

            await elevator.GoToFloor(desiredFloorLevel);
        }

        private static void DisplayElevatorStatus(ElevatorFactory elevatorFactory)
        {
            Console.WriteLine("\n.__________ Passengers Elevators Status __________.\n");

            DisplayElevatorStatusForType(elevatorFactory, ElevatorType.Passenger);
        }

        private static void DisplayElevatorStatusForType(ElevatorFactory elevatorFactory, ElevatorType type)
        {
            var elevators = elevatorFactory.GetAllElevatorsByType(type).ToList();

            for (int i = 0; i < elevators.Count; i++)
            {
                Console.WriteLine(
                    $"- Elevator {elevators[i].Id.ToString().Split('-')[0]}, " +
                    $"Floor: {elevators[i].CurrentFloor}, " +
                    $"Direction: {elevators[i].Direction}, " +
                    $"Passengers: {elevators[i].PassengerCount}/{elevators[i].MaxPassengerCount}");
            }
        }
    }
}