using AnimeKatalog.BLL.DTO;
using AnimeKatalog.DAL.Context;
using AnimeKatalog.DAL.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.Services
{
    public class CharacterService
    {
        private CharacterRepository _characterRepository;
        IMapper _mapper;

        public CharacterService(CharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;

            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Character, CharacterDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(character => character.CharacterID))
            .ForMember(x => x.Name, x => x.MapFrom(character => character.CharacterName))
            .ForMember(x => x.FirstName, x => x.MapFrom(character => character.CharacterFirstName))
            .ForMember(x => x.AnimeID, x => x.MapFrom(character => character.AnimeID)).ReverseMap());
            _mapper = new Mapper(configuration);
        }

        #region Methods
        public IEnumerable<CharacterDTO> GetAll() => _mapper.Map<IEnumerable<CharacterDTO>>(_characterRepository.GetAll());

        public Task<IEnumerable<CharacterDTO>> GetAllAsync() => Task.Run(() => GetAll());

        public CharacterDTO Get(int id)
        {
            var character = _characterRepository.Get(id);
            return _mapper.Map<CharacterDTO>(character);
        }

        public void Remove(CharacterDTO entity)
        {
            var character = _characterRepository.Get(entity.ID);
            _characterRepository.Remove(character);
            _characterRepository.Save();
        }

        public void Uppdate(CharacterDTO entity)
        {
            var character = _characterRepository.Get(entity.ID);
            character = _mapper.Map<Character>(entity);
            _characterRepository.AddOrUppdate(character);
            _characterRepository.Save();
        }

        public CharacterDTO Add(CharacterDTO entity)
        {
            var character = _mapper.Map<Character>(entity);
            _characterRepository.AddOrUppdate(character);
            _characterRepository.Save();
            entity.ID = character.CharacterID;
            return entity;
        }
        #endregion
    }
}
