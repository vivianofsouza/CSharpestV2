using CSharpestServer.Models;

namespace CSharpestServer.Parameters
{
    public class PurchaseRequestParams
    {
        public User User { get; set; }
        public Cart Cart { get; set; }
    }
}
