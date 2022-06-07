using ChallengeDotnetAPI.Data;
using ChallengeDotnetAPI.Interface;
using ChallengeDotnetAPI.Models;
using ChallengeDotnetAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDotnetAPI.Repository
{
    public class CharacterRepository : ICharacters
    {
        private readonly DisneyContext _context;

        public CharacterRepository(DisneyContext context)
        {
            _context = context;
        }

        public async Task<Character> CreateAsync(Character character)
        {
            throw new NotImplementedException();
        }
        
        public async Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(long id)
        {
            Character? character = await _context.Characters
                .Include(c => c.Movies)
                .ThenInclude(m => m.Genre)
                .Where(c => c.ID == id)
                .FirstOrDefaultAsync();
            
            if (character == null)
            {
                throw new ArgumentNullException();
            }
            return character;
        }

        public async Task<List<Character?>> SearchAsync(string? name, int? age, decimal? weight, long? movieId)
        {
            var baseQuery = from c in _context.Characters
                            select c;

            var nameQuery = string.IsNullOrEmpty(name) ? baseQuery : baseQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));

            var ageQuery = age == null ? nameQuery : nameQuery.Where(c => c.Age == age);

            var weightQuery = weight == null ? ageQuery : ageQuery.Where(c => c.Weight == weight);

            var movieQuery = movieId == null ? weightQuery : weightQuery.Where(c => c.Movies.Any(m => m.ID == movieId));
                        
            List<Character?> characters = await movieQuery.ToListAsync();
            if (characters.Count == 0)
            {
                throw new ArgumentNullException();
            }
            return characters;
        }
        
        public async Task<Character> UpdateAsync(Character character)
        {
            throw new NotImplementedException();
        }



        
        // Helpers
    
    }
}
