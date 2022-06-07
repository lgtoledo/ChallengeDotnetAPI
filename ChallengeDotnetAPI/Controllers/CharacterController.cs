using Microsoft.AspNetCore.Mvc;
using ChallengeDotnetAPI.Models;
using ChallengeDotnetAPI.Data;
using Microsoft.EntityFrameworkCore;
using ChallengeDotnetAPI.Models.DTO;
using ChallengeDotnetAPI.Interface;

namespace ChallengeDotnetAPI.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacters _ICharacter;
        
        public CharacterController(ICharacters ICharacter)
        {
            _ICharacter = ICharacter;
        }

        // GET all action
        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetAll()
        {
            var result = await _ICharacter.GetAllAsync();
            return Ok(result.Select(x => ToDTO(x)));
        }


        // GET by Id action (Details)
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetById(long id)
        {
            var result = await _ICharacter.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // GET by  Name, filter by Age, weight, movies(id)
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Search(string? name = null, int? age = null, decimal? weight = null, int? movieId = null)
        {
            try
            {
                var result = await _ICharacter.SearchAsync(name, age, weight, movieId);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST action

        // PUT action

        // DELETE action



        // Helpers
        private static CharacterDTO ToDTO(Character character)
        {
            return new CharacterDTO
            {
                ID = character.ID,
                Name = character.Name,
                Image = character.Image
            };
        }
    }
}
