using ProperyHandlerProject.Handlers;
using ProperyHandlerProject.Models;
using System;
using System.Linq;

namespace ProperyHandlerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Extract();
            Console.ReadLine();
        }

        static void Extract()
        {
            var handlerType = typeof(CustomerAddressHandler);
            var interfaces = handlerType
                .GetInterfaces();
            //var handlerInterface = handlerType
            //    .GetInterfaces()
            //    .Where(e => e.FullName.StartsWith("ProperyHandlerProject.Interfaces.IPropertyHandler"))
            //    .FirstOrDefault();
            //var genericArguments = handlerInterface.GetType().GetGenericArguments();
            var instance = (CustomerAddressHandler)Activator.CreateInstance(handlerType);
            var handlerSetMethod = handlerType.GetMethod("Set");
            var address = new Address
            {
                Country = "DK",
                County = "GTF",
                State = "GTF",
                Street = "Springbanen 33",
                ZipCode = "2820"
            };
            var result = handlerSetMethod.Invoke(instance, new object[] { address });
            Console.WriteLine(result);
        }
    }
}
