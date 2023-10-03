using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Helpers
{
    /// <summary>
    /// Implements the IConsoleService interface to provide a service for 
    /// interacting with the console. This allows for abstracting away 
    /// direct console operations and makes testing and mocking easier.
    /// </summary>
    public class ConsoleService : IConsoleService
    {
        public ConsoleKeyInfo? ReadKey()
        {
            return Console.ReadKey();
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
