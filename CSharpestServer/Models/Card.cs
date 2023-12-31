using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Models;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class Card : IComparable<Card>
{
    public string Number { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public int CVV { get; set; }
    public int ZipCode { get; set; }


    public Card(string cardNo, int month, int year, string name, int cVV, int zip)
    {
        Number = cardNo;
        Month = month;
        Year = year;
        Name = name;
        CVV = cVV;
        ZipCode = zip;
    }

    public Card() { }

    // comparison method to allow item to be included in SortedSet
    public int CompareTo(Card other)
    {
        // checks if other item is null or not
        if (other != null)
        {
            return this.Number.CompareTo(other.Number); // compares by card number
        }
        // if null or otherwise, return 
        return 1;
    }
}
