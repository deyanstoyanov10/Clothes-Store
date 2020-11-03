namespace ClothingStore.Server.Data.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
