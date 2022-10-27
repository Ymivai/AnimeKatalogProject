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
    public class AvtorService
    {
        private AvtorRepository _avtorRepository;
        IMapper _mapper;

        public AvtorService(AvtorRepository avtorRepository)
        {
            _avtorRepository = avtorRepository;

            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Avtor, AvtorDTO>()
            .ForMember(x => x.ID, x => x.MapFrom(avtor => avtor.AvtorID))
            .ForMember(x => x.Name, x => x.MapFrom(avtor => avtor.AvtorName))
            .ForMember(x => x.FirstName, x => x.MapFrom(avtor => avtor.AvtorFirstName)).ReverseMap());
            _mapper = new Mapper(configuration);
        }

        #region Methods

        public IEnumerable<AvtorDTO> GetAll() => _mapper.Map<IEnumerable<AvtorDTO>>(_avtorRepository.GetAll());

        public Task<IEnumerable<AvtorDTO>> GetAllAsync() => Task.Run(() => GetAll());

        public AvtorDTO Get(int id)
        {
            var avtor = _avtorRepository.Get(id);
            return _mapper.Map<AvtorDTO>(avtor);
        }

        public void Remove(AvtorDTO entity)
        {
            var avtor = _avtorRepository.Get(entity.ID);
            _avtorRepository.Remove(avtor);
            _avtorRepository.Save();
        }

        public void Uppdate(AvtorDTO entity)
        {
            var avtor = _avtorRepository.Get(entity.ID);
            avtor = _mapper.Map<Avtor>(entity);
            _avtorRepository.AddOrUppdate(avtor);
            _avtorRepository.Save();
        }

        public AvtorDTO Add(AvtorDTO entity)
        {
            var avtor = _mapper.Map<Avtor>(entity);
            _avtorRepository.AddOrUppdate(avtor);
            _avtorRepository.Save();
            entity.ID = avtor.AvtorID;
            return entity;
        }

        #endregion
    }
}
