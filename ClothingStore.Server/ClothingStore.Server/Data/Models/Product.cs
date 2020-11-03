namespace ClothingStore.Server.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Sizes = new HashSet<Size>();
            this.Colors = new HashSet<Color>();
            this.Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public uint Quantity { get; set; }

        public bool Status { get; set; }

        public string SupplierUrl { get; set; }

        public ShoppingCartItem ShoppingCartItem { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
