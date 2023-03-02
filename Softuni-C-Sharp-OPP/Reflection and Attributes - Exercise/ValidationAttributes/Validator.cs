using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type typeObj = obj.GetType();
            PropertyInfo[] properties = typeObj
                .GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(a => typeof(MyValidationAttribute).IsAssignableFrom(a.AttributeType)))
                    .ToArray();

            foreach (PropertyInfo validationProp in properties)
            {
                object[] customAttributes = validationProp
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray();

                object propValue = validationProp.GetValue(obj);

                foreach (object customAttribute in customAttributes)
                {
                    MethodInfo isValidMethod = customAttribute.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name == "IsValid");

                    if (isValidMethod == null)
                        throw new InvalidOperationException("Your custom attribute is not valid");

                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propValue });

                    if (!result)
                        return false;
                }
            }

            return true;
        }
    }
}
