namespace ChallengeDotnetAPI.Models
{
    public class Genre
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
