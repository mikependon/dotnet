using ProperyHandlerProject.Attributes;
using ProperyHandlerProject.Handlers;

namespace ProperyHandlerProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [PropertyHandler(typeof(CustomerAddressHandler))]
        public Address Address { get; set; }
    }
}
