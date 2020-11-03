namespace ClothingStore.Server.Data.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string PicturePath { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
