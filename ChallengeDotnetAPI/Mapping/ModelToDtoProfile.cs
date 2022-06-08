using ChallengeDotnetAPI.Models;
using AutoMapper;
using ChallengeDotnetAPI.Mapping.Dto.Character;

namespace ChallengeDotnetAPI.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<Character, SaveCharacterDto>();

        }
    }
}
