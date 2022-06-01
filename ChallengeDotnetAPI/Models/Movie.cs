namespace ChallengeDotnetAPI.Models
{
    public class Movie
    {
        public long ID { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public int CreationDate { get; set; }
        public decimal Score { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
