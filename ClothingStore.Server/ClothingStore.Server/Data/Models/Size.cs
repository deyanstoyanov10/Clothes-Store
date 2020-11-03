namespace ClothingStore.Server.Data.Models
{
    public class Size
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
