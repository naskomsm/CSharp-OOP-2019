﻿namespace MuOnline.Core
{
    using System;
    using Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>(); // this is how we get the serviceProvideer

                    var result = commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }
                catch (InvalidOperationException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }
    }
}
