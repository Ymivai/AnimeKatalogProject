using AnimeKatalog.BLL.DTO;
using AnimeKatalog.DAL.Context;
using AnimeKatalog.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.Services
{
    public class GanreService
    {
        private GanreRepository _ganreRepository;

        public GanreService(GanreRepository ganreRepository)
        {
            _ganreRepository = ganreRepository;
        }

        #region Methods

        public IEnumerable<GanreDTO> GetAll() => _ganreRepository.GetAll().Select(ganre=> new GanreDTO
        {
            ID = ganre.GanreID,
            Name = ganre.GanreName
        });

        public Task<IEnumerable<GanreDTO>> GetAllAsync() => Task.Run(()=> GetAll());

        public GanreDTO Get(int id)
        {
            var ganre = _ganreRepository.Get(id);
            return new GanreDTO
            {
                ID = ganre.GanreID,
                Name = ganre.GanreName
            };
        }

        public void Remove(GanreDTO entity)
        {
            var ganre = _ganreRepository.Get(entity.ID);
            _ganreRepository.Remove(ganre);
            _ganreRepository.Save();
        }

        public void Uppdate(GanreDTO entity)
        {
            var ganre = _ganreRepository.Get(entity.ID);
            ganre = new Ganre { GanreID = entity.ID, GanreName = entity.Name };
            _ganreRepository.AddOrUppdate(ganre);
            _ganreRepository.Save();
        }

        public GanreDTO Add(GanreDTO entity)
        {
            var ganre = new Ganre { GanreID = entity.ID, GanreName = entity.Name };
            _ganreRepository.AddOrUppdate(ganre);
            _ganreRepository.Save();
            entity.ID = ganre.GanreID;
            return entity;
        }

        #endregion
    }
}
