namespace ClothingStore.Server.Data.Models
{
    using System.Collections.Generic;

    public class Size
    {
        public Size() => this.ProductSizes = new HashSet<ProductSize>();

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
