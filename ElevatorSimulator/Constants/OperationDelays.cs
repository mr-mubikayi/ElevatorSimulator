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

        // Additional elevator types operation delays can be added here.
    }
}
