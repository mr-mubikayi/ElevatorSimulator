using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Constants
{
    /// <summary>
    /// Provides methods that simulate operational delays for various types of elevators.
    /// </summary>
    public static class OperationDelays
    {
        /// <summary>
        /// Simulates an operational delay for a passenger elevator.
        /// </summary>
        /// <param name="delayTime">Optional multiplier for the delay. If not provided, a default of 1 is used.</param>
        /// <returns>A task representing the delay operation.</returns>
        /// <remarks>
        /// The base delay time for a passenger elevator is 2000 milliseconds. The provided delayTime multiplies this base value.
        /// For example, if delayTime is 3, the method will delay for 6000 milliseconds.
        /// </remarks>
        public static async Task PassengerElevator(int? delayTime)
        {
            await Task.Delay((delayTime ?? 1) * 2000);
        }

        /// <summary>
        /// Simulates travel time between floors (default: 1500ms per floor).
        /// </summary>
        public static async Task TravelBetweenFloors(int floors)
        {
            if (floors <= 0) return;
            await Task.Delay(floors * 1500); // 1.5s per floor
        }

        /// <summary>
        /// Simulates door operation (default: 3000ms for open/close).
        /// </summary>
        public static async Task DoorOperation(bool isOpening)
        {
            await Task.Delay(3000); // 3s for open or close
        }

        /// <summary>
        /// Simulates time for passengers to enter/exit (default: 1000ms per person).
        /// </summary>
        public static async Task PassengerTransfer(int passengerCount, IConsoleService console, string message)
        {
            if (passengerCount <= 0) return;
            for (int i = 0; i < passengerCount; i++)
            {
                for (int dot = 1; dot <= 3; dot++)
                {
                    console.Write("\r" + message + new string('.', dot) + new string(' ', 3 - dot));
                    await Task.Delay(250);
                }
                // Hold the last frame for the rest of the second
                await Task.Delay(250);
            }
            console.Write("\r" + new string(' ', message.Length + 3) + "\r"); // Clear line
            console.WriteLine("");
        }
    }
}
