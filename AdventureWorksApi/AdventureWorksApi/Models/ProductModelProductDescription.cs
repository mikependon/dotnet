using RepoDb.Attributes;
using System;

namespace AdventureWorksApi.Models
{
    [Map("[SalesLT].[ProductModelProductDescription]")]
    public class ProductModelProductDescription
    {
        public int ProductModelId { get; set; }
        public int ProductDescriptionId { get; set; }
        public string Culture { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
