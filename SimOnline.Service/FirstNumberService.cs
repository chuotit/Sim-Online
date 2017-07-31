using System.Collections.Generic;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface IFirstNumberService
    {
        FirstNumber Add(FirstNumber firstNumber);

        void Update(FirstNumber firstNumber);

        FirstNumber Delete(int id);

        IEnumerable<FirstNumber> GetAll();

        FirstNumber GetById(int id);

        IEnumerable<FirstNumber> GetByNetwork(int id);

        void SaveChanges();
    }

    public class FirstNumberService : IFirstNumberService
    {
        private IFirstNumberRepository _firstNumberRepository;
        private IUnitOfWork _unitOfWork;

        public FirstNumberService(IFirstNumberRepository firstNumberRepository, IUnitOfWork unitOfWork)
        {
            this._firstNumberRepository = firstNumberRepository;
            this._unitOfWork = unitOfWork;
        }

        public FirstNumber Add(FirstNumber firstNumber)
        {
            return _firstNumberRepository.Add(firstNumber);
        }

        public FirstNumber Delete(int id)
        {
            return _firstNumberRepository.Delete(id);
        }

        public IEnumerable<FirstNumber> GetAll()
        {
            return _firstNumberRepository.GetAll(new string[] { "SimNetwork" });
        }

        public FirstNumber GetById(int id)
        {
            return _firstNumberRepository.GetSingleById(id);
        }

        public IEnumerable<FirstNumber> GetByNetwork(int id)
        {
            return _firstNumberRepository.GetMulti(x => x.NetworkID == id, new string[] { "SimNetwork" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FirstNumber firstNumber)
        {
            _firstNumberRepository.Update(firstNumber);
        }
    }
}