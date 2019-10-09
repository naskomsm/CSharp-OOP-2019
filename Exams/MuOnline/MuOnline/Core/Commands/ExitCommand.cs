namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using System;
    using System.Threading;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Exit after {i}s");
                Thread.Sleep(500);
            }

            Console.WriteLine($"Goodbye!");

            Environment.Exit(0);
            return string.Empty;
        }
    }
}
