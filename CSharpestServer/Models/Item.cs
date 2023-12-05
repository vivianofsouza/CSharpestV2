using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/20/23

public class Item : IComparable<Item>
{

    // fields
    public Guid Id { get; set; } // primary key
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Bundle? bundle { get; set; }
    public string ImageURL { get; set; }


    // for a new item being added to database
    public Item(string name, string description, decimal price, int stock, Bundle? _bundle, string imageURL)
    {

        Name = name;
        Description = description;
        Id = Guid.NewGuid();
        Price = price;
        Stock = stock;
        bundle = _bundle;
        ImageURL = imageURL;
    }

    public Item() { }

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(Item otherItem)
    {
        // checks if other item is null or not
        if (otherItem != null)
        {
            return this.Id.CompareTo(otherItem.Id); // compares by price
        }
        // if null or otherwise, return 
        return 1;
    }
}
