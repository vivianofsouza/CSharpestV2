using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CSharpestServer.Services;
using CSharpestServer.Services.Interfaces;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        //GET api/todos
        [ProducesResponseType(200)]
        [HttpGet]
        public Task<IEnumerable<Card>> GetCards()
        {
            return _cardService.GetAllAsync();
        }
    }
}
