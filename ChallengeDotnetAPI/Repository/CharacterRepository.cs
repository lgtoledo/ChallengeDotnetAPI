using ChallengeDotnetAPI.Data;
using ChallengeDotnetAPI.Interface;
using ChallengeDotnetAPI.Models;
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

        public async Task CreateAsync(Character character)
        {
            try
            {
                var c = await _context.Characters.AddAsync(character);
                var entriesNumber = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating: " + ex.Message);
            }
        }
        
        public async Task DeleteAsync(long id)
        {
            try
            {
                Character? character = await _context.Characters.FindAsync(id);
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting: " + ex.Message);
            }
        }
        
        public async Task<bool> ExistsAsync(long id)
        {
            return await _context.Characters.AnyAsync(e => e.ID == id);
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
        
        public async Task UpdateAsync(Character character)
        {
            try
            {
                _context.Entry(character).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating: " + ex.Message);
            }
        }



        
        // Helpers
    
    }
}
