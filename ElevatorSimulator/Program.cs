using ElevatorSimulator.Classes;
using ElevatorSimulator.Enums;

namespace ElevatorSimulator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var elevatorFactory = new ElevatorFactory();

            // For demonstration purposes, add some elevators
            elevatorFactory.AddElevators(ElevatorType.Passenger, 3);
            //elevatorFactory.AddElevators(ElevatorType.HighSpeed, 2);

            while (true)
            {
                Console.WriteLine("1. Call Elevator");
                Console.WriteLine("2. Display Elevator Status");
                Console.WriteLine("3. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CallElevator(elevatorFactory);
                        break;

                    case "2":
                        DisplayElevatorStatus(elevatorFactory);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Try Again.");
                        break;
                }
            }
        }

        private static void DisplayElevatorStatus(ElevatorFactory elevatorFactory)
        {
            Console.WriteLine("--- Passenger Elevators ---");
            DisplayElevatorStatusForType(elevatorFactory, ElevatorType.Passenger);

            //Console.WriteLine("--- High-Speed Elevators ---");
            //DisplayElevatorStatusForType(elevatorFactory, ElevatorType.HighSpeed);
        }

        private static void DisplayElevatorStatusForType(ElevatorFactory elevatorFactory, ElevatorType type)
        {
            var elevators = elevatorFactory.GetAllElevatorsOfType(type);

            foreach (var elevator in elevators)
            {
                Console.WriteLine($"- Elevator at Floor: {elevator.CurrentFloor}, Direction: {elevator.Direction}, Passengers: {elevator.PassengerCount}/{elevator.MaxPassengerCount}");
            }
        }

        private static async Task CallElevator(ElevatorFactory elevatorFactory)
        {
            Console.Write("Enter Floor (One, Two, Three): ");
            var floor = (FloorLevel)Enum.Parse(typeof(FloorLevel), Console.ReadLine());

            Console.Write("Enter Number of Passengers: ");
            var passengers = int.Parse(Console.ReadLine());

            var elevator = elevatorFactory.GetElevator(ElevatorType.Passenger); // or HighSpeed based on more advanced logic

            if (elevator != null)
            {
                elevator.GoToFloor(floor);
                elevator.AddPassengers(passengers);
            }
            else
            {
                Console.WriteLine("No available elevators at the moment. Please wait.");
            }

            Console.ReadLine();
        }
    }
}