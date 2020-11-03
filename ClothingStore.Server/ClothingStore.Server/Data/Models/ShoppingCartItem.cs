namespace ClothingStore.Server.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public uint Quantity { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
