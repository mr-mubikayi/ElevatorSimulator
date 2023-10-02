namespace ElevatorSimulator.Helpers
{
    public static class ValidNumberChecker
    {
        public static int GetValidNumber(string message, int? maxNumber)
        {
            Console.Write(message);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("\nPlease Insert a Value.");
                return GetValidNumber(message, maxNumber);
            }

            var canParseValue = int.TryParse(input, out var parsedResult);

            if(!canParseValue)
            {
                Console.WriteLine("\nInvalid number. Try again.");
                return GetValidNumber(message, maxNumber);
            }

            if (maxNumber == null)
                return parsedResult;

            if (parsedResult > -1 && parsedResult <= maxNumber)
                return parsedResult;

            Console.WriteLine("\nInvalid number. Try again.");
            return GetValidNumber(message, maxNumber);
        }
    }
}
