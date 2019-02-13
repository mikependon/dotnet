﻿using RepoDb.Attributes;
using System;

namespace AdventureWorksApi.Models
{
    [Map("[SalesLT].[ProductModel]")]
    public class ProductModel
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
