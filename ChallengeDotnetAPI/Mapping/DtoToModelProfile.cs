using AutoMapper;
using ChallengeDotnetAPI.Mapping.Dto.Character;
using ChallengeDotnetAPI.Models;

namespace ChallengeDotnetAPI.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<SaveCharacterDto, Character>();
        }
    }
}
