using AutoMapper;
using Store.Application.Abstractions.Mapping;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries.GetAllProducts
{
    public class ProductDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImgURL { get; set; }

        public decimal? UnitPrice { get; set; }

    }
}
