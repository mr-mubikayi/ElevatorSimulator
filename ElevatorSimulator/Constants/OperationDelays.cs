namespace ElevatorSimulator.Constants
{
    public static class OperationDelays
    {
        public static async Task PassengerElevator(int? delayTime)
        {
            await Task.Delay((delayTime ?? 1) * 2000);
        }

        /*
            Add different elevator operational delays here
        
            Example:

            public static async Task FreightElevator(int? delayTime) => await Task.Delay((delayTime ?? 1) * 4000);
            public static async Task HighSpeedElevator(int? delayTime) => await Task.Delay((delayTime ?? 1) * 1000);
         */
    }
}
