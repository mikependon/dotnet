using RepoDb.Attributes;
using System;

namespace AdventureWorksApi.Models
{
    [Map("[SalesLT].[ProductCategory]")]
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int? ParentProductCategoryId { get; set; }
        public string Name { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
