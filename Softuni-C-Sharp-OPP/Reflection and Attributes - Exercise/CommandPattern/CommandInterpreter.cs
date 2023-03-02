using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var splitedArgs = args.Split().ToArray();
            string commandName = splitedArgs[0];
            string[] arrArgs = splitedArgs.Skip(1).ToArray();
            
            Assembly assembly = Assembly.GetEntryAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
                throw new InvalidOperationException("Invalid command type!");

            MethodInfo excecuteMethodInfo = commandType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            if (excecuteMethodInfo == null)
                throw new InvalidOperationException("Command does not implement required pattern! Try implementing IComand interface instead!");

            object cmdInstance = Activator.CreateInstance(commandType);
            return (string)excecuteMethodInfo.Invoke(cmdInstance, new object[] { arrArgs });
        }
    }
}
