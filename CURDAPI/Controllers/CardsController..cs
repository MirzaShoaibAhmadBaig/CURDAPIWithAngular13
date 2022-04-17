using CURDAPI.DataContext;
using CURDAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly CardDBContext _cardDBContext;

        public CardsController(CardDBContext cardDBContext)
        {
            this._cardDBContext = cardDBContext;
        }
        // Get All Card Method
        [HttpGet]
        [Route("GetAllCards")]
        public async Task<IActionResult> GetAllCards()
        {
           var cards = await _cardDBContext.Cards.ToListAsync();
            return Ok(cards);
        }

        // Get Single Card 
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCardsById")]
        public async Task<IActionResult> GetCardsById([FromRoute] Guid id)
        {
            var card =await _cardDBContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card!=null)
            {
                return Ok(card);

            }
            return Ok("Card Not FoundS");

        }


        // Add Card in to DataBase 
        [HttpPost]
        [Route("AddNewCard")]
        public async Task<IActionResult> AddCard([FromBody] Card cards )
        {
            cards.Id = Guid.NewGuid();
          await  _cardDBContext.Cards.AddAsync(cards);
            await _cardDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCardsById),new {id =cards.Id }, cards) ;

        }


        // Update Card Info 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCardById([FromRoute] Guid id , [FromBody] Card card)
        {
            var existingCard = await _cardDBContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
                if(existingCard != null)
                {
                existingCard.CardHolderName = card.CardHolderName;
                existingCard.CardNumber = card.CardNumber;
               existingCard.CVC = card.CVC;
                existingCard.ExpiryMonth = card.ExpiryMonth;
                existingCard.ExpiryYear = card.ExpiryYear;
                existingCard.Gender = card.Gender;
                existingCard.PhoneNum = card.PhoneNum;
                await _cardDBContext.SaveChangesAsync();
                return Ok("Card Information Update Succesfully");

                }
                else
                {

                return Ok("card Information Not Found! Please Try Again");
                }
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveCard([FromRoute] Guid id)
        {
            var existingCard = await _cardDBContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                 _cardDBContext.Cards.Remove(existingCard);
               
                await _cardDBContext.SaveChangesAsync();
                return Ok("Card Information Remove Succesfully");

            }
            else
            {

                return Ok("card Information Not Found! Please Try Again");
            }
        }

    }
}
