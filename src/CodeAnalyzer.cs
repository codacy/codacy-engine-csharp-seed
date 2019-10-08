using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Codacy.Engine.Seed.Configuration;
using Codacy.Engine.Seed.Patterns;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed
{
    /// <summary>
    ///     Code analyzer base class. This class implements the
    ///     "standardized" behavior of a codacy tool. It parses the
    ///     configuration file and gets the patterns, parameters and
    ///     a list of source files for the tool to analyze.
    /// </summary>
    public abstract class CodeAnalyzer
    {
        /// <summary>
        ///     Default name of codacy config file
        /// </summary>
        protected const string DefaultConfigFile = ".codacyrc";

        /// <summary>
        ///     Default path for patterns documentation file
        /// </summary>
        protected const string DefaultPatternsFile = "docs/patterns.json";

        /// <summary>
        ///     Default path for the source folder
        /// </summary>
        protected const string DefaultSourceFolder = "src/";

        /// <summary>
        ///     Codacy configuration model instance
        /// </summary>
        protected readonly CodacyConfiguration Config;

        /// <summary>
        ///     Reference for this tool passed on codacy configuration
        ///     model instance.
        /// </summary>
        protected readonly Tool CurrentTool;

        /// <summary>
        ///     Codacy patterns model instance
        /// </summary>
        protected readonly CodacyPatterns Patterns;

        /// <summary>
        ///     List of pattern IDs to be used by the tool
        /// </summary>
        protected ImmutableList<string> PatternIds;

        /// <summary>
        ///     CodeAnalyzer Constructor
        ///     This constructs the CodeAnalyzer class with a given
        ///     file extension pattern (e.g.: .cs)
        /// </summary>
        /// <param name="fileExtension">file extension pattern</param>
        protected CodeAnalyzer(string fileExtension = ".*")
        {
            var patternsJSON = File.ReadAllText(DefaultPatternsFile);
            Patterns = JsonConvert.DeserializeObject<CodacyPatterns>(patternsJSON);

            if (File.Exists(DefaultConfigFile))
            {
                var configJSON = File.ReadAllText(DefaultConfigFile);
                Config = JsonConvert.DeserializeObject<CodacyConfiguration>(configJSON);

                CurrentTool = Array.Find(Config.Tools, tool => tool.Name == Patterns.Name);

                if (Config.Files is null)
                {
                    Config.Files = GetSourceFiles(DefaultSourceFolder, fileExtension);
                }

                if (!(CurrentTool.Patterns is null))
                {
                    var patternIds = new List<string>();
                    foreach (var pattern in CurrentTool.Patterns)
                    {
                        patternIds.Add(pattern.PatternId);
                    }

                    PatternIds = patternIds.ToImmutableList();
                }
            }
            else
            {
                Config = new CodacyConfiguration
                {
                    Files = GetSourceFiles(DefaultSourceFolder, fileExtension),
                    Tools = new[]
                    {
                        new Tool
                        {
                            Name = Patterns.Name
                        }
                    }
                };
            }
        }

        /// <summary>
        ///     Analyze task
        ///     This will create a task with a timeout for the tool to analyze
        ///     the files. The cancellation token is used to safely stop the running task
        ///     in case of a deadlock or freeze.
        /// </summary>
        /// <param name="cancellationToken">cancellation token to cancel the running task</param>
        /// <returns></returns>
        protected abstract Task Analyze(CancellationToken cancellationToken);

        /// <summary>
        ///     Run Analyze task
        ///     This will trigger the analyze task to run with the specified timeout.
        /// </summary>
        /// <returns>analyze task instance</returns>
        public async Task Run()
        {
            var timeoutEnv = Environment.GetEnvironmentVariable("TIMEOUT");

            if (timeoutEnv is null)
            {
                await Analyze(CancellationToken.None).ConfigureAwait(false);
            }
            else
            {
                try
                {
                    var timeout = TimeSpanHelper.Parse(timeoutEnv);
                    using (var cancellationTokenSource = new CancellationTokenSource())
                    {
                        var cancellationToken = cancellationTokenSource.Token;
                        var task = Analyze(cancellationToken);
                        if (await Task.WhenAny(task, Task.Delay(timeout)).ConfigureAwait(false) != task)
                        {
                            cancellationTokenSource.Cancel();
                            Environment.Exit(2);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"can't parse 'TIMEOUT' environment variable ({timeoutEnv})");
                    Logger.Send(e.StackTrace);
                    Environment.Exit(1);
                }
            }
        }

        /// <summary>
        ///     Get the source files
        ///     This function is to get the source files in a specified folder with a
        ///     given extension.
        /// </summary>
        /// <param name="folder">folder to search the files</param>
        /// <param name="fileExtension">file extension pattern</param>
        /// <returns>list of files in the specified folder and given extension pattern</returns>
        private static string[] GetSourceFiles(string folder, string fileExtension)
        {
            return (from string entry in Directory.GetFiles(folder, "*" + fileExtension, SearchOption.AllDirectories)
                select entry.Substring(entry.IndexOf("/", StringComparison.InvariantCulture) + 1)).ToArray();
        }
    }
}
