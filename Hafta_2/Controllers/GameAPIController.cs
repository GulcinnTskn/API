using Hafta_2.Data;

using Hafta_2.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Hafta_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class GameAPIController : ControllerBase
    {

        private readonly ApplicationDbContext _context;  //uygulama içerisinde değiştirilmemesi için readonly 

        public GameAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]  //tümünün listelendiği kısım
        [Route("All", Name = "GetAllGames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<GameDTO>> GetGames()
        {
            
            return Ok(_context.Games.ToList());

        }


        [HttpGet("{id:int}", Name = "GetGames")]   // id'ye göre listelenen kısım

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameDTO> GetGames(int id)
        {

            //400 Client Error
            if (id <= 0)
            {
                
                return BadRequest("Lütfen 0'dan büyük bir sayı giriniz!");
            }

            var games = _context.Games.FirstOrDefault(x => x.ID == id);


            //404 Not Found
            if (games == null)
            {
                return NotFound($"{id} Numaralı ID'ye Sahip Oyun Bulunamadı.");
            }

            return Ok(games); //200


        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GameDTO> CreateGame([FromBody] GameDTO newGameDTO)


        {

            if (_context.Games.FirstOrDefault(x => x.Name.ToLower() == newGameDTO.Name.ToLower()) != null) //aynı isme sahip oyun varsa mesaj gönder
            {
                ModelState.AddModelError("CustomError", "Bu Oyun Zaten Mevcut!");
                return BadRequest(ModelState);
            }


            if (newGameDTO == null)
            {
                return BadRequest(); //400
            }

            if (newGameDTO.ID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Game model = new()
            {
                ID = newGameDTO.ID,
                Name = newGameDTO.Name,
                Description = newGameDTO.Description,
                Price = newGameDTO.Price,
                Publisher = newGameDTO.Publisher,
                ReleaseDate = newGameDTO.ReleaseDate,
            };

            _context.Games.Add(model);

            _context.SaveChanges();

            return CreatedAtRoute("GetGames", new { id = newGameDTO.ID }, newGameDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteGame(int id)
        {
            if (id <= 0)
            {
                return BadRequest(); //400
            }

            var game = _context.Games.FirstOrDefault(x => x.ID == id);

            if (game == null)
            {
                return NotFound(); //404
            }

            _context.Games.Remove(game);
            _context.SaveChanges();

            return NoContent(); //204 sildiğimizde geriye bir şey dönmez o yüzden NoContent kullandık
        }


        [HttpPut("{id:int}", Name = "UpdateGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatedGame(int id, [FromBody] GameDTO updateGame)
        {
            if (updateGame == null || id != updateGame.ID) //null veya veri tabanındaki ID'ye eşit değilse
            {
                return BadRequest();
            }

            //var game = GameStore.gameList.FirstOrDefault(x => x.ID == id);
            //game.Name = updateGame.Name;
            //game.Publisher = updateGame.Publisher;
            //game.Description = updateGame.Description;
            //game.ReleaseDate = updateGame.ReleaseDate;
            //game.Price = updateGame.Price;

            Game model = new()
            {
                ID = updateGame.ID,
                Name = updateGame.Name,
                Description = updateGame.Description,
                Price = updateGame.Price,
                Publisher = updateGame.Publisher,
                ReleaseDate = updateGame.ReleaseDate,
            };

            _context.Games.Update(model);

            _context.SaveChanges();

            return NoContent();

        }
        //PATCH KULLANIMI
        // {
        //  "op": "replace",    --> burada yapmak istediğimiz operasyonu yazarız (add,remove,replace,move,copy,test)
        //  "path": "/name",   --> güncellenecek adresin yolu
        //  "value": "Barry"  --> güncellenecek değer
        //},

        [HttpPatch("{id:int}", Name = "UpdatePartialGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialGame(int id, JsonPatchDocument<GameDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest(); //400
            } 

            var game = _context.Games.FirstOrDefault(x => x.ID == id);

            GameDTO gameDTO = new()
            {
                ID = game.ID,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
            };


            if (game == null)
            {
                return BadRequest();
            }


            patchDTO.ApplyTo(gameDTO, ModelState); //json dosyasını game'e uygulamasını istiyoruz eğer hata olursa modelstate ile tutulsun

            Game model = new()
            {
                ID = gameDTO.ID,
                Name = gameDTO.Name,
                Description = gameDTO.Description,
                Price = gameDTO.Price,
                Publisher = gameDTO.Publisher,
                ReleaseDate = gameDTO.ReleaseDate,
            };

            _context.Games.Update(model);
            _context.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

    };

}
