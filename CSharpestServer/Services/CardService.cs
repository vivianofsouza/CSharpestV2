using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
//using CSharpestServer.Persistence;

namespace CSharpestServer.Services
{
    public class CardService : ICardService
    {
        private readonly StoreContext _storeContext;

        public CardService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private string GenerateRandomCardNumber()
        {
            // Generate a random 16-digit card number
            Random random = new Random();
            string cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardNumber += random.Next(0, 10).ToString();
            }

            return cardNumber;
        }
        private Card GetInitialisedCardNo(Card card)
        {
            if (string.IsNullOrEmpty(card.Number))
            {
                card.Number = GenerateRandomCardNumber();
            }
            return card;
        }

        public Task AddAsync(Card card)
        {
            card = GetInitialisedCardNo(card);
            _storeContext.cards.Add(card);
            _storeContext.SaveChanges();

            return Task.CompletedTask;
        }
        
        public Task RemoveAsync(string card_number)
        {
            var card = _storeContext?.cards.Find(card_number);

            _storeContext.cards.Remove(card);
            _storeContext.SaveChanges();
            return Task.FromResult(card);
        }

        public Task<IEnumerable<Card>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.cards.AsEnumerable());
        }

        public Card? GetByNum(string card_number)
        {
            var card = _storeContext.cards.Find(card_number);
            return card;
        }

        public Task<Card?> GetByNumAsync(string card_number)
        {
            Card? card = _storeContext.cards.Find(card_number);
            return Task.FromResult(card);
        }

        public Task AddRangeAsync(IEnumerable<Card> cards)
        {
            foreach (var i in cards)
            {
                Card card = GetInitialisedCardNo(i);
                _storeContext.Add(card);
            }
            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
