using CSharpestServer.Classes;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CSharpestServer.Services
{
    public class CardService
    {
        private readonly CardService _cardService;
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");

        public CardService()
        {
        }

        public string Get()
        {
            return "hello";
        }
    }
}
