namespace MuOnline.Core
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            string commandName = args[0].ToLower() + Suffix;
            string[] inputArgs = args.Skip(1).ToArray();

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            var constructor = commandType
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var instance = (ICommand)Activator.CreateInstance(commandType, services);

            var result = instance.Execute(inputArgs);

            return result;
        }
    }
}
