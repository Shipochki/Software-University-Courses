using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using Heroes;

namespace TestProject
{
	public class Tests
	{
		private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

		[Test]
		public void ValidateCreateWeaponCommandMethodInController()
		{
			var controller = CreateObjectInstance(GetType("Controller"));

			var createWeaponArguments = new object[] { "Claymore", "Almace", 10 };
			var validActualResult = InvokeMethod(controller, "CreateWeapon", createWeaponArguments);

			var validExpectedResult = "A claymore Almace is added to the collection.";

			Assert.AreEqual(validExpectedResult, validActualResult);
		}

		[Test]
		public void ValidateCreateHeroCommandMethodInController()
		{
			var controller = CreateObjectInstance(GetType("Controller"));

			var createHeroArguments = new object[] { "Barbarian", "Berenger", 120, 15 };
			var validActualResult = InvokeMethod(controller, "CreateHero", createHeroArguments);

			var validExpectedResult = "Successfully added Barbarian Berenger to the collection.";

			Assert.AreEqual(validExpectedResult, validActualResult);
		}

		private static object InvokeMethod(object obj, string methodName, object[] parameters)
		{
			try
			{
				var result = obj.GetType()
					.GetMethod(methodName)
					.Invoke(obj, parameters);

				return result;
			}
			catch (TargetInvocationException e)
			{
				return e.InnerException.Message;
			}
		}

		private static object CreateObjectInstance(Type type, params object[] parameters)
		{
			try
			{
				var desiredConstructor = type.GetConstructors()
					.FirstOrDefault(x => x.GetParameters().Any());

				if (desiredConstructor == null)
				{
					return Activator.CreateInstance(type, parameters);
				}

				var instances = new List<object>();

				foreach (var parameterInfo in desiredConstructor.GetParameters())
				{
					var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

					instances.Add(currentInstance);
				}

				return Activator.CreateInstance(type, instances.ToArray());
			}
			catch (TargetInvocationException e)
			{
				return e.InnerException.Message;
			}
		}

		private static Type GetType(string name)
		{
			var type = ProjectAssembly
				.GetTypes()
				.FirstOrDefault(t => t.Name.Contains(name));

			return type;
		}
	}
}