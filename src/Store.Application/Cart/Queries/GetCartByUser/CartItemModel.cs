using AutoMapper;
using Store.Application.Abstractions.Mapping;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Store.Application.Cart.Queries.GetCartByUser
{
    public class CartItemModel : IHaveCustomMapping 
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImgURL { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Total
        {
            get
            {
                return this.UnitPrice * this.Quantity;
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CartItem, CartItemModel>()
               .ForMember(cDTO => cDTO.ProductImgURL, opt => opt.MapFrom(c => c.Product.ProductImgURL))
               .ForMember(cDTO => cDTO.ProductName, opt => opt.MapFrom(c => c.Product.ProductName))
               .ForMember(cDTO => cDTO.UnitPrice, opt => opt.MapFrom(c => c.Product.UnitPrice));
        }
    }
}
