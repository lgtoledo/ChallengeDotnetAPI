namespace ChallengeDotnetAPI.Models
{
    public class Movie
    {
        public long ID { get; set; }
        public long GenreID { get; set; }
        public byte[]? Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public Genre Genre { get; set; }
        
        public virtual ICollection<Character> Characters { get; set; }
    }
}
