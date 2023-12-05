using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class CartItem : IComparable<CartItem>
{
    public Guid Id { get; set; } // primary key: cartItemId
    public Guid CartId { get; set; } // foreign key
    public Guid ItemId { get; set; } // foreign key
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }


    public CartItem(Guid itemId, Guid cartId, int quantity, decimal totalPrice)
    {
        Id = Guid.NewGuid();
        ItemId = itemId;
        CartId = cartId;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    public CartItem() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(CartItem other)
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
