using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Classes;
using CSharpestServer.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23

namespace CSharpestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        // GET: <CardsController>
        [HttpGet]
        public String Get()
        {
            return _cardService.Get();
        }
    }
}
