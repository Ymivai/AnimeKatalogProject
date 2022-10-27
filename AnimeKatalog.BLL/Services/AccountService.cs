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
    public class AccountService
    {
        AccountRepository _accountRepository;
        IMapper _mapper;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Account, AccountDTO>()
            .ForMember(x => x.Id, x => x.MapFrom(account => account.AccountID))
            .ForMember(x => x.Login, x => x.MapFrom(account => account.AccountLogin))
            .ForMember(x => x.Password, x => x.MapFrom(account => account.AccountPassword))
            .ForMember(x => x.Image, x => x.MapFrom(account => account.AccountImage))
            .ForMember(x => x.Admin, x => x.MapFrom(account => account.AccountAdmin)).ReverseMap());
            _mapper = new Mapper(configuration);
        }

        #region Methods

        public IEnumerable<AccountDTO> GetAll() => _accountRepository.GetAll().Select(account => new AccountDTO
        {
            Id = account.AccountID,
            Login = account.AccountLogin,
            Password = account.AccountPassword,
            Image = account.AccountImage,
            Admin = account.AccountAdmin
        });

        public Task<IEnumerable<AccountDTO>> GetAllAsync() => Task.Run(() => GetAll());
        
        public AccountDTO Get(int id)
        {
            var account = _accountRepository.Get(id);
            return _mapper.Map<AccountDTO>(account); 
        }

        public void Remove(AccountDTO entity)
        {
            var account = _accountRepository.Get(entity.Id);
            _accountRepository.Remove(account);
            _accountRepository.Save();
        }

        public void Uppdate(AccountDTO entity)
        {
            var account = _accountRepository.Get(entity.Id);
            account = _mapper.Map<Account>(entity);
            _accountRepository.AddOrUppdate(account);
            _accountRepository.Save();
        }

        public AccountDTO Add(AccountDTO entity)
        {
            var account = _mapper.Map<Account>(entity);
            _accountRepository.AddOrUppdate(account);
            _accountRepository.Save();
            entity.Id = account.AccountID;
            return entity;
        }

        #endregion
    }
}
