namespace Store.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}