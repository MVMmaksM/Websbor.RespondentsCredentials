using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Prototype
{
    public class Prototype<T> where T : class, new()
    {
        public static T GetPrototype(T objectClass)
        {
            var type = typeof(T);
            var typeProperties = type.GetProperties();

            var prototypeObjectClass = new T();

            foreach (var property in typeProperties)
            {
                property.SetValue(prototypeObjectClass, property.GetValue(objectClass));
            }

            return prototypeObjectClass;
        }

        public static void SetValueProperties(T destinationObject, T sourceObject)
        {
            var type = typeof(T);
            var typeProperties = type.GetProperties();

            foreach (var property in typeProperties)
            {
                property.SetValue(destinationObject, property.GetValue(sourceObject));
            }
        }
    }
}
