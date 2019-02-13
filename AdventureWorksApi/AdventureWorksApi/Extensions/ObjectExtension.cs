using System;
using System.Linq;

namespace AdventureWorksApi.Extensions
{
    internal static class ObjectExtension
    {
        public static T To<T>(this object obj, bool strict = false) where T : class
        {
            if (obj == null)
            {
                return null;
            }
            var sourceProperties = obj.GetType().GetProperties();
            var destinationProperties = typeof(T).GetProperties();
            var instance = Activator.CreateInstance<T>();
            sourceProperties.ToList().ForEach(sourceProperty =>
            {
                var value = sourceProperty.GetValue(obj);
                var targetProperties = destinationProperties.Where(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                var destinationProperty = strict ? targetProperties.First() : targetProperties.FirstOrDefault();
                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(instance, value);
                }
            });
            return instance;
        }
    }
}
