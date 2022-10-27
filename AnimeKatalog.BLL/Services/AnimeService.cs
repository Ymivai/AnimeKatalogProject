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
    public class AnimeService
    {
        private AnimeRepository _animeRepository;
        IMapper _mapper;

        public AnimeService(AnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;

            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Anime, AnimeDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(anime => anime.AnimeID))
            .ForMember(x => x.Name, x => x.MapFrom(anime => anime.AnimeName))
            .ForMember(x => x.Description, x => x.MapFrom(anime => anime.AnimeDescription))
            .ForMember(x => x.Year, x => x.MapFrom(anime => anime.AnimeYear))
            .ForMember(x => x.Star, x => x.MapFrom(anime => anime.AnimeStar))
            .ForMember(x => x.ImgURL, x => x.MapFrom(anime => anime.AnimeImgURL))
            .ForMember(x => x.AvtorID, x => x.MapFrom(anime => anime.Avtor)).ReverseMap());
            _mapper = new Mapper(configuration);
        }

        #region Methods

        public IEnumerable<AnimeDTO> GetAll() => _mapper.Map<IEnumerable<AnimeDTO>>(_animeRepository.GetAll());

        public Task<IEnumerable<AnimeDTO>> GetAllAsync() => Task.Run(() => GetAll());

        public AnimeDTO Get(int id)
        {
            var anime = _animeRepository.Get(id);
            return _mapper.Map<AnimeDTO>(anime);
        }

        public void Remove(AnimeDTO entity)
        {
            var anime = _animeRepository.Get(entity.ID);
            _animeRepository.Remove(anime);
            _animeRepository.Save();
        }

        public void Uppdate(AnimeDTO entity)
        {
            var anime = _animeRepository.Get(entity.ID);
            anime = _mapper.Map<Anime>(entity);
            _animeRepository.AddOrUppdate(anime);
            _animeRepository.Save();
        }

        public AnimeDTO Add(AnimeDTO entity)
        {
            var anime = _mapper.Map<Anime>(entity);
            _animeRepository.AddOrUppdate(anime);
            _animeRepository.Save();
            entity.ID = anime.AnimeID;
            return entity;
        }

        #endregion
    }
}
