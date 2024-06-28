using Serilog;

namespace Util
{
    /// <summary>
    /// Class for logging messages to a file.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// If messages should be written to file or only printed to stdout.
        /// </summary>
        public bool logToFile = false;

        /// <summary>
        /// Logger constructor.
        /// </summary>
        /// <param name="filename">The log filename.</param>
        /// <param name="toFile">If messages should be written to file or only printed to stdout.</param>
        public Logger(string filename, bool toFile = true)
        {
            if (toFile)
            {
                Log.Logger = new LoggerConfiguration().WriteTo.File(filename).CreateLogger();
                logToFile = true;
            }
        }

        /// <summary>
        /// Log information.
        /// </summary>
        /// <param name="info">The information message to be logged.</param>
        /// <param name="writeToConsole">If the message should be printed to stdout or not.</param>
        public void info(string info, bool writeToConsole = true)
        {
            if (logToFile) Log.Information(info);
            if (writeToConsole)
            {
                Console.WriteLine(info);
            }
        }

        /// <summary>
        /// Log information and print to stdout with specified color.
        /// </summary>
        /// <param name="info">The information message to be logged.</param>
        /// <param name="color">The foreground color to be used for stdout (if supported).</param>
        public void info(string info, ConsoleColor color)
        {
            if (logToFile) Log.Information(info);
            Console.ForegroundColor = color;
            Console.WriteLine(info);
            Console.ResetColor();
        }

        /// <summary>
        /// Log warning.
        /// </summary>
        /// <param name="warning">The warning message to be logged.</param>
        /// <param name="writeToConsole">If the message should be printed to stdout or not.</param>
        public void warning(string warning, bool writeToConsole = true)
        {
            if (logToFile) Log.Warning(warning);
            if (writeToConsole)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(warning);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="error">The error message to be logged.</param>
        /// <param name="writeToConsole">If the message should be printed to stdout or not.</param>
        public void error(string error, bool writeToConsole = true)
        {
            if (logToFile) Log.Error(error);
            if (writeToConsole)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Log success.
        /// </summary>
        /// <param name="success">The success message to be logged.</param>
        /// <param name="writeToConsole">If the message should be printed to stdout or not.</param>
        public void success(string success, bool writeToConsole = true)
        {
            if (logToFile) Log.Information(success);
            if (writeToConsole)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(success);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Close and flush the logger.
        /// </summary>
        public void dispose()
        {
            if (logToFile) Log.CloseAndFlush();
        }
    }
}
