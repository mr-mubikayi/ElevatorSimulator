using ElevatorSimulator.Constants;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Helpers
{
    /// <summary>
    /// Provides utility methods to ensure that user input is a valid number.
    /// </summary>
    public static class ValidNumberChecker
    {
        /// <summary>
        /// Prompts the user for input and ensures the input is a valid integer.
        /// </summary>
        /// <param name="message">The message to display to the user when prompting for input.</param>
        /// <param name="maxNumber">Optional maximum allowed integer value. If provided, any input greater than this value will be considered invalid.</param>
        /// <returns>A valid integer input from the user.</returns>
        /// <remarks>
        /// If the user provides invalid input, they will be prompted repeatedly until a valid integer is given.
        /// If a <paramref name="maxNumber"/> is provided, the input must also be less than or equal to this value.
        /// </remarks>
        public static int GetValidNumber(string message, int? maxNumber, IConsoleService consoleService)
        {
            try
            {
                consoleService.Write(message);
                var input = consoleService.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    consoleService.WriteLine(DisplayTexts.ENTER_VALUE_TEXT);
                    return GetValidNumber(message, maxNumber, consoleService);
                }

                var canParseValue = int.TryParse(input, out var parsedResult);

                if (!canParseValue)
                {
                    consoleService.WriteLine(DisplayTexts.INVALID_OPTION_TEXT);
                    return GetValidNumber(message, maxNumber, consoleService);
                }

                if (maxNumber == null)
                    return parsedResult;

                if (parsedResult > -1 && parsedResult <= maxNumber)
                    return parsedResult;

                consoleService.WriteLine(DisplayTexts.INVALID_OPTION_TEXT);
                return GetValidNumber(message, maxNumber, consoleService);
            }
            catch (Exception ex)
            {
                consoleService.WriteLine(string.Format(DisplayTexts.ERROR_OCCURED, ex.Message));
                return GetValidNumber(message, maxNumber, consoleService); // Prompt the user again if an unexpected error occured
            }
        }
    }
}
