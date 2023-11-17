namespace CSharpestServer.Classes
{
    public class Transaction
    {
        public Guid TransID { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
        public DateTime DateTime { get; set; }

        public Transaction(Guid _ID, IEnumerable<CartItem> _items, DateTime _DT)
        {
            TransID = _ID;
            Items = _items;
            DateTime = _DT;
        }
    }
}
