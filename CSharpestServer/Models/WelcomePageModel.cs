using CSharpestServer.Classes;

namespace CSharpestServer.Models
{
    public class WelcomePageModel
    {
        public SortedSet<Item> Items { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public WelcomePageModel(SortedSet<Item> items, int quantity, Guid cartId)
        {

            Items = items;
            CartId = cartId;
            Quantity = quantity;
            CartId = cartId;

        }

    }
}
