using System.Collections.Generic;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface IConsignerService
    {
        Consigner Add(Consigner consigner);

        void Update(Consigner consigner);

        Consigner Delete(int id);

        IEnumerable<Consigner> GetAll();

        IEnumerable<Consigner> GetAll(string keyword);

        Consigner GetById(int id);

        //IEnumerable<Consigner> GetBySimID(int id);

        void SaveChanges();
    }

    internal class ConsignerService : IConsignerService
    {
        private IConsignerRepository _consignerRepository;
        private IUnitOfWork _unitOfWork;

        public ConsignerService(IConsignerRepository consignerRepository, IUnitOfWork unitOfWork)
        {
            this._consignerRepository = consignerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Consigner Add(Consigner consigner)
        {
            return _consignerRepository.Add(consigner);
        }

        public Consigner Delete(int id)
        {
            return _consignerRepository.Delete(id);
        }

        public IEnumerable<Consigner> GetAll()
        {
            return _consignerRepository.GetAll();
        }

        public Consigner GetById(int id)
        {
            return _consignerRepository.GetSingleById(id);
        }

        public IEnumerable<Consigner> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _consignerRepository.GetMulti(x => x.Name.Contains(keyword) || x.Address.Contains(keyword) || x.Email.Contains(keyword) || x.Hotline.Contains(keyword));
            else
                return _consignerRepository.GetAll();

        }

        // Đoạn này cần xem lại
        //public IEnumerable<Consigner> GetBySimID(int id)
        //{
        //    return _consignerRepository.GetMulti(x => x.ID == id, new string[] { "SimNetwork" });
        //}

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Consigner consigner)
        {
            _consignerRepository.Update(consigner);
        }
    }
}