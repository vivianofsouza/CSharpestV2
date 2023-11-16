namespace CSharpestServer.Classes
{
    public class Card
    {
        public long Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public int CVV { get; set; }
        public Card(long number, int month, int year, string name, int cVV)
        {
            Number = number;
            Month = month;
            Year = year;
            Name = name;
            CVV = cVV;
        }
    }
}
