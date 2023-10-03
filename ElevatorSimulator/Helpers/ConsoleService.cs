﻿using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Helpers
{
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
