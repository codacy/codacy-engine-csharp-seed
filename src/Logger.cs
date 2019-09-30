using System;
using System.Diagnostics.CodeAnalysis;

namespace Codacy.Engine.Seed
{
    /// <summary>
    ///     Simple Logger for debug purpose
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     Debug flag set by 'DEBUG' environment variable
        /// </summary>
        private static readonly bool debugFlag = Convert.ToBoolean(Environment.GetEnvironmentVariable("DEBUG"));

        /// <summary>
        ///     Send a debug message to the log.
        /// </summary>
        /// <param name="message">specified message to log</param>
        /// <typeparam name="T">the of the message</typeparam>
        public static void Send<T>(T message)
        {
            if (debugFlag)
            {
                Console.WriteLine(message);
            }
        }
    }
}
