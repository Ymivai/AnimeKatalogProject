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
    public class FullAnimeService
    {
        private AnimeRepository _animeRepository;
        IMapper _mapper;
        IMapper _mapperSeries;
        IMapper _mapperGanres;
        IMapper _mapperCharacters;

        public FullAnimeService(AnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;

            Mapper();
        }

        #region Methods

        public IEnumerable<FullAnimeDTO> GetAll() => _mapper.Map<IEnumerable<FullAnimeDTO>>(_animeRepository.GetAll());

        public Task<IEnumerable<FullAnimeDTO>> GetAllAsync() => Task.Run(() => GetAll());

        public FullAnimeDTO Get(int id)
        {
            var anime = _animeRepository.Get(id);
            return _mapper.Map<FullAnimeDTO>(anime);
        }

        public void Remove(FullAnimeDTO entity)
        {
            var anime = _animeRepository.Get(entity.ID);
            _animeRepository.Remove(anime);
            _animeRepository.Save();
        }

        public void Uppdate(FullAnimeDTO entity)
        {
            var anime = _animeRepository.Get(entity.ID);
            anime = _mapper.Map<Anime>(entity);
            _animeRepository.AddOrUppdate(anime);
            _animeRepository.Save();
        }

        public FullAnimeDTO Add(FullAnimeDTO entity)
        {
            var anime = _mapper.Map<Anime>(entity);
            _animeRepository.AddOrUppdate(anime);
            _animeRepository.Save();
            entity.ID = anime.AnimeID;
            return entity;
        }

        #endregion

        #region Mapper
        private void Mapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Series, SeriesDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(series => series.SeriesID))
            .ForMember(x => x.Name, x => x.MapFrom(series => series.SeriesName))
            .ForMember(x => x.Number, x => x.MapFrom(series => series.SeriesNumber))
            .ForMember(x => x.URL, x => x.MapFrom(series => series.SeriesURL))
            .ForMember(x => x.AnimeID, x => x.MapFrom(series => series.AnimeID)).ReverseMap());
            _mapperSeries = new Mapper(configuration);

            configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Ganre, GanreDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(series => series.GanreID))
            .ForMember(x => x.Name, x => x.MapFrom(series => series.GanreName)).ReverseMap());
            _mapperGanres = new Mapper(configuration);

            configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Character, CharacterDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(character => character.CharacterID))
            .ForMember(x => x.Name, x => x.MapFrom(character => character.CharacterName))
            .ForMember(x => x.FirstName, x => x.MapFrom(character => character.CharacterFirstName))
            .ForMember(x => x.AnimeID, x => x.MapFrom(character => character.AnimeID)).ReverseMap());
            _mapperCharacters = new Mapper(configuration);

            configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Anime, FullAnimeDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(anime => anime.AnimeID))
            .ForMember(x => x.Name, x => x.MapFrom(anime => anime.AnimeName))
            .ForMember(x => x.Description, x => x.MapFrom(anime => anime.AnimeDescription))
            .ForMember(x => x.Year, x => x.MapFrom(anime => anime.AnimeYear))
            .ForMember(x => x.Star, x => x.MapFrom(anime => anime.AnimeStar))
            .ForMember(x => x.ImgURL, x => x.MapFrom(anime => anime.AnimeImgURL))
            .ForMember(x => x.AvtorID, x => x.MapFrom(anime => anime.Avtor))
            .ForMember(x => x.SeriesDTO, x => x.MapFrom(anime => _mapperSeries.Map<ICollection<SeriesDTO>>(anime.Series)))
            .ForMember(x => x.GanresDTO, x => x.MapFrom(anime => _mapperGanres.Map<ICollection<GanreDTO>>(anime.Ganre)))
            .ForMember(x => x.CharacterDTO, x => x.MapFrom(anime => _mapperCharacters.Map<ICollection<CharacterDTO>>(anime.Character)))
            .ReverseMap());
            _mapper = new Mapper(configuration);
        }
        #endregion
    }
}
