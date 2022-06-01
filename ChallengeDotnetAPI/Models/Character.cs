namespace ChallengeDotnetAPI.Models
{
    public class Character
    {
        public long ID { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string History { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
