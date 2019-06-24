using AutoMapper;
using Store.Application.Abstractions.Mapping;
using Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Cart.Queries.GetCartByUser
{
    public class CartViewModel 
    {
        public IEnumerable<CartItemModel> Items { get; set; }

        public decimal? Total
        {
            get
            {
                return this.Items.Sum(s => s.Total);
            }
        }
    }
}