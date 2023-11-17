using CSharpestServer.Classes;

namespace CSharpestServer.Models
{
    public class OrderPageModel
    {
        public IEnumerable<CartItem> Items { get; set; }
        //public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public bool Confirmed { get; set; }


        public OrderPageModel(IEnumerable<CartItem> _items, Cart _cart, bool _confirmed)
        {
            Items = _items;
            Cart = _cart;
            Confirmed = _confirmed;
        }
    }
}
