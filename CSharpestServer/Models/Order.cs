using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class Order : IComparable<Order>
{
    public Guid Id { get; set; } // primary key: orerId
    public Guid UserId { get; set; }
    public string CardId { get; set; } // card number, fk (should this be string or long??)
    public string DateTime {  get; set; }
    public string Address { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalCost { get; set; }


    public Order(Guid userId, Card card, string datetime, string address, decimal shipping)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        CardId = card.Number;
        DateTime = datetime;
        Address = address;
        ShippingCost = shipping;
        TotalCost = 0;
    }

    public Order() { }

    // comparison method to allow item to be included in SortedSet
    public int CompareTo(Order other)
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
