﻿namespace Store.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public short Quantity { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}