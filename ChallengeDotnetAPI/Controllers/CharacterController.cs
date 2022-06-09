using Microsoft.AspNetCore.Mvc;
using ChallengeDotnetAPI.Models;
using ChallengeDotnetAPI.Data;
using Microsoft.EntityFrameworkCore;
using ChallengeDotnetAPI.Interface;
using AutoMapper;
using ChallengeDotnetAPI.Mapping.Dto.Character;
using ChallengeDotnetAPI.Extensions;

namespace ChallengeDotnetAPI.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacters _ICharacter;
        private readonly IMapper _mapper;

        public CharacterController(ICharacters ICharacter, IMapper mapper)
        {
            _ICharacter = ICharacter;
            _mapper = mapper;
        }

        // GET all action
        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetAll()
        {
            var characters = await _ICharacter.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Character>, IEnumerable<CharacterDto>>(characters);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        // POST action
        [HttpPost]
        public async Task<ActionResult<Character>> Create([FromBody] SaveCharacterDto characterDto)
        {
            try
            {
                // checks if the data sent in the request body is valid
                // based in our data annotations in the model
                if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

                var character = _mapper.Map<SaveCharacterDto, Character>(characterDto);
                
                await _ICharacter.CreateAsync(character);
                var characterSaved = _mapper.Map<Character, SaveCharacterDto> (character);

                return Ok(characterSaved);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT action
        [HttpPut("{id}")]
        public async Task<ActionResult<Character>> Update(int id, [FromBody] SaveCharacterDto characterDto)
        {
            try
            {
                // checks if the data sent in the request body is valid
                // based in our data annotations in the model
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var character = _mapper.Map<SaveCharacterDto, Character>(characterDto);

                await _ICharacter.UpdateAsync(character);

                var characterSaved = _mapper.Map<Character, SaveCharacterDto>(character);

                return Ok(characterSaved);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE action
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ICharacter.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
