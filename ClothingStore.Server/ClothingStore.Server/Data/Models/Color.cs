namespace ClothingStore.Server.Data.Models
{
    using System.Collections.Generic;

    public class Color
    {
        public Color() => this.ProductColors = new HashSet<ProductColor>();

        public int Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
