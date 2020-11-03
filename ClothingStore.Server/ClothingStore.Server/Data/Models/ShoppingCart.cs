using System.Collections.Generic;

namespace ClothingStore.Server.Data.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public decimal Amount { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
