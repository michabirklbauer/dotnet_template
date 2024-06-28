using CommandLine;
using CommandLine.Text;
using Logger = Util.Logger;

namespace App
{
    public class App
    {
        /// <summary>
        /// Name of the application.
        /// </summary>
        public const string name = "Template App";
        /// <summary>
        /// Exact name of the executable file.
        /// </summary>
        public const string executable = "App";
        /// <summary>
        /// Version of the application.
        /// </summary>
        public const string version = "0.0.1";

        /// <summary>
        /// Commandline options.
        /// </summary>
        public class Options
        {
            /// <summary>
            /// The name to greet.
            /// </summary>
            [Option('n', "name", Required = true, HelpText = "The name to greet.")]
            public string nameToGreet { get; set; }

            /// <summary>
            /// The greeting to use.
            /// </summary>
            [Option('g', "greeting", Required = false, HelpText = "The greeting to use.")]
            public string? greeting { get; set; }

            /// <summary>
            /// Disables writing information to log file.
            /// </summary>
            [Option("disable-logging", Required = false, Default = false, HelpText = "Disables writing information to log file.")]
            public bool loggingOff { get; set; }

            /// <summary>
            /// Usage examples.
            /// </summary>
            [Usage(ApplicationAlias = executable)]
            public static IEnumerable<Example> Examples
            {
                get
                {
                    return new List<Example>() {
                        new Example("Greet Luna with 'Hello'", new Options { nameToGreet = "Luna" }),
                        new Example("Greet Luna with 'Hi'", new Options { nameToGreet = "Luna",
                                                                          greeting = "Hi" })
                    };
                }
            }
        }

        /// <summary>
        /// The main application method run when all necessary arguments are given.
        /// </summary>
        /// <param name="options">Options parsed from the commandline.</param>
        public static void RunApp(Options options)
        {
            // logger
            var logger = new Logger($"{name.Replace(" ", "")}_v{version}_log.txt", !options.loggingOff);

            try 
            {
                // time of execution
                var time = DateTime.Now.ToString("yyyy-MM-d_HH-mm");

                // get commandline options
                var nameToGreet = options.nameToGreet;
                var greeting = options.greeting != null ?
                                   options.greeting :
                                   "Hello";

                // start application
                logger.info($"Starting {name} v{version} ...", ConsoleColor.Blue);
                logger.info($"Time of start: {time}", writeToConsole: false);

                // YOUR CODE
                Console.WriteLine($"{greeting} {nameToGreet}!");
                logger.info($"{greeting} {nameToGreet}!", writeToConsole: false);
                logger.success($"Successfully greeted {nameToGreet}!");

                // exit
                logger.info($"{name} exited!", ConsoleColor.Blue);
                return;
            }
            catch (Exception e)
            {
                // fatal unhandled error
                logger.error($"A fatal error occured while running {name}! The specific exception that was thrown is:");
                Console.WriteLine(e.ToString());
                logger.error(e.ToString(), false);

                // error -> exit
                logger.info($"{name} exited!", ConsoleColor.Blue);
                return;
            }
            finally
            {
                logger.dispose();
            }
        }

        /// <summary>
        /// Help displayed in case the necessary arguments for running the application are not given.
        /// </summary>
        /// <typeparam name="T">Type of the parser result.</typeparam>
        /// <param name="result">Result of the parser.</param>
        /// <param name="errors">Errors yielded by the parser.</param>
        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
        {
            if (errors.IsVersion())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{name} verson: {version}");
                Console.ResetColor();
                return;
            }

            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            helpText.AddPreOptionsLine("\nOPTIONS:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(helpText);
            Console.ResetColor();
            return;
        }

        /// <summary>
        /// Main function that is executed when application is run.
        /// </summary>
        /// <param name="args">Arguments passed via commandline.</param>
        public static void Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);
            parserResult
                .WithParsed(RunApp)
                .WithNotParsed(errors => DisplayHelp(parserResult, errors));
            return;
        }
    }
}