using System.ComponentModel.DataAnnotations;

namespace ChallengeDotnetAPI.Mapping.Dto.Character
{
    public class SaveCharacterDto
    {
        public byte[]? Image { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }

        [Range(1, 300, ErrorMessage = "Weight must be between 1 and 300")]
        public decimal Weight { get; set; }

        [MaxLength(200)]
        public string History { get; set; }
    }
}
