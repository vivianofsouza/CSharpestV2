using CSharpestServer.Classes;

namespace CSharpestServer.Parameters
{
    public class PurchaseRequestParams
    {
        public Shopper User { get; set; }
        public Cart Cart { get; set; }
    }
}
