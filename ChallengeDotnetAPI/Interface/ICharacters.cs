using ChallengeDotnetAPI.Models;

namespace ChallengeDotnetAPI.Interface
{
    public interface ICharacters
    {
        public Task<List<Character>> GetAllAsync();
        public Task<Character> GetByIdAsync(long id);
        public Task<List<Character>> SearchAsync(string? name, int? age, decimal? weight, long? movieId);
        public Task CreateAsync(Character character);
        public Task UpdateAsync(Character character);
        public Task DeleteAsync(long id);
        public Task<bool> ExistsAsync(long id);
    }
}
