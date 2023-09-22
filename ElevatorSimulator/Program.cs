using ElevatorSimulator.Classes;
using ElevatorSimulator.Enums;

namespace ElevatorSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var elevatorFactory = new ElevatorFactory();

            // Add 5 passenger elevators
            elevatorFactory.AddElevators(ElevatorType.Passenger, 5);

            // Add 3 high-speed elevators
            elevatorFactory.AddElevators(ElevatorType.HighSpeed, 3);

            // Get an available elevator
            var availablePassengerElevator = elevatorFactory.GetElevator(ElevatorType.Passenger);
            var availableHighSpeedElevator = elevatorFactory.GetElevator(ElevatorType.HighSpeed);

            availablePassengerElevator.GoToFloor(FloorLevel.Three);
            availablePassengerElevator.Direction();
            availablePassengerElevator.OpenDoor();
            availablePassengerElevator.CloseDoor();

            Console.ReadLine();
        }
    }
}