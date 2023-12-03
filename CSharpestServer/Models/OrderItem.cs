using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class OrderItem : IComparable<OrderItem>
{
    public Guid Id { get; set; } // primary key: OrderItemId
    public Guid OrderId { get; set; }
    public Guid ItemId { get; set; }
    public Guid BundleId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }


    public OrderItem(Order order, Item item, Bundle bundle, int quantity, decimal subtotal)
    {
        Id = Guid.NewGuid();
        OrderId = order.Id;
        ItemId = item.Id;
        BundleId = bundle.Id;
        Quantity = quantity;
        Subtotal = subtotal; // leave this for now but this is where the bundle effect will be calculated.
    }

    public OrderItem() { }

    // comparison method to allow item to be included in SortedSet
    public int CompareTo(OrderItem other)
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
