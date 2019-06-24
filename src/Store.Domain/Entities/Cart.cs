using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Entities
{
    public class Cart
    {
        public Cart()
        {
            Items = new HashSet<CartItem>();
        }

        public int CartId { get; set; }

        public string UserId { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}
