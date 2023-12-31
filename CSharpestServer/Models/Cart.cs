using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class Cart : IComparable<Cart>
{
    public Guid Id { get; set; } // primary key: cartId
    public Guid userId { get; set; }
    public decimal preSubtotal { get; set; }
    public decimal postSubtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal TotalPrice { get; set; }
    public Cart(User user)
    {
        Id = user.CartId;
        userId = user.Id;
        preSubtotal = 0.00M;
        postSubtotal = 0.00M;
        Tax = 0.00M;
        TotalPrice = 0.00M;
    }

    public Cart() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(Cart other)
    {
        // checks if other item is null or not
        if (other != null)
        {
            return this.Id.CompareTo(other.Id); // compares by id
        }
        // if null or otherwise, return 
        return 1;
    }
}
