namespace ClothingStore.Server.Data.Models
{
    using Data.Enums;
    using System.Collections.Generic;

    public class Category
    {
        public Category() => this.Products = new HashSet<Product>();

        public int Id { get; set; }

        public Type Type { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
