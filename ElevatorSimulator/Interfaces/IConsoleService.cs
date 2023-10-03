namespace ElevatorSimulator.Interfaces
{
    /// <summary>
    /// Provides an abstraction over console-related operations.
    /// This interface can be used to interact with the console for reading and writing purposes.
    /// </summary>
    public interface IConsoleService
    {
        /// <summary>
        /// Reads the next key pressed by the user.
        /// </summary>
        /// <returns>
        /// A nullable <see cref="ConsoleKeyInfo"/> structure that describes the <see cref="System.ConsoleKey"/> constant and Unicode character,
        /// if any, that correspond to the pressed key. Returns null if no key is pressed.
        /// </returns>
        ConsoleKeyInfo? ReadKey();

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>
        /// The next line of characters from the input stream, or null if no more lines are available.
        /// </returns>
        string? ReadLine();

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="message">The string value to write.</param>
        void Write(string message);

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="message">The string value to write.</param>
        void WriteLine(string message);
    }
}