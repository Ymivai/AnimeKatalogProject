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
    public class SeriesService
    {
        private SeriesRepository _seriesRepository;
        IMapper _mapper;

        public SeriesService(SeriesRepository seriesService)
        {
            _seriesRepository = seriesService;

            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Series, SeriesDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(series => series.SeriesID))
            .ForMember(x => x.Name, x => x.MapFrom(series => series.SeriesName))
            .ForMember(x => x.Number, x => x.MapFrom(series => series.SeriesNumber))
            .ForMember(x => x.URL, x => x.MapFrom(series => series.SeriesURL))
            .ForMember(x => x.AnimeID, x => x.MapFrom(series => series.AnimeID)).ReverseMap());
            _mapper = new Mapper(configuration);
        }

        #region Methods

        public IEnumerable<SeriesDTO> GetAll() => _seriesRepository.GetAll().Select(series => new SeriesDTO
        {
            ID = series.SeriesID,
            Name = series.SeriesName,
            Number = series.SeriesNumber,
            AnimeID = series.AnimeID
        });

        public Task<IEnumerable<SeriesDTO>> GetAllAsync() => Task.Run(() => GetAll());

        public SeriesDTO Get(int id)
        {
            var series = _seriesRepository.Get(id);
            return _mapper.Map<SeriesDTO>(series);
        }

        public void Remove(SeriesDTO entity)
        {
            var series = _seriesRepository.Get(entity.ID);
            _seriesRepository.Remove(series);
            _seriesRepository.Save();
        }

        public void Uppdate(SeriesDTO entity)
        {
            var series = _seriesRepository.Get(entity.ID);
            series = _mapper.Map<Series>(entity);
            _seriesRepository.AddOrUppdate(series);
            _seriesRepository.Save();
        }

        public SeriesDTO Add(SeriesDTO entity)
        {
            var series = _mapper.Map<Series>(entity);
            _seriesRepository.AddOrUppdate(series);
            _seriesRepository.Save();
            entity.ID = series.SeriesID;
            return entity;
        }

        #endregion
    }
}
