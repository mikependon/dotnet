using Newtonsoft.Json;
using ProperyHandlerProject.Interfaces;
using ProperyHandlerProject.Models;
using System;

namespace ProperyHandlerProject.Handlers
{
    public class CustomerAddressHandler : IPropertyHandler<string, Address>
    {
        public Address Get(string input)
        {
            throw new NotImplementedException();
        }

        public string Set(Address input)
        {
            return (input != null) ? JsonConvert.SerializeObject(input) : null;
        }
    }
}
