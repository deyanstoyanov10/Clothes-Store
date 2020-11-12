namespace ClothingStore.Server.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.ProductSizes = new HashSet<ProductSize>();
            this.ProductColors = new HashSet<ProductColor>();
            this.Pictures = new HashSet<Picture>();
            this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public uint Quantity { get; set; }

        public bool Status { get; set; }

        public string SupplierUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
