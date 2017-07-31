using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface IConsignerLevelService
    {
        ConsignerLevel Add(ConsignerLevel consignerLevel);

        void Update(ConsignerLevel consignerLevel);

        ConsignerLevel Delete(int id);

        IEnumerable<ConsignerLevel> GetAll();

        ConsignerLevel GetById(int id);

        IEnumerable<ConsignerLevel> GetByConsignerID(int id);

        void SaveChanges();
    }

    class ConsignerLevelService : IConsignerLevelService
    {
        private IConsignerLevelRepository _consignerLevelRepository;
        private IUnitOfWork _unitOfWork;

        public ConsignerLevelService(IConsignerLevelRepository consignerLevelRepository, IUnitOfWork unitOfWork)
        {
            this._consignerLevelRepository = consignerLevelRepository;
            this._unitOfWork = unitOfWork;
        }

        public ConsignerLevel Add(ConsignerLevel consignerLevel)
        {
            return _consignerLevelRepository.Add(consignerLevel);
        }

        public ConsignerLevel Delete(int id)
        {
            return _consignerLevelRepository.Delete(id);
        }

        public IEnumerable<ConsignerLevel> GetAll()
        {
            return _consignerLevelRepository.GetAll();
        }

        public ConsignerLevel GetById(int id)
        {
            return _consignerLevelRepository.GetSingleById(id);
        }
        
        public IEnumerable<ConsignerLevel> GetByConsignerID(int id)
        {
            return _consignerLevelRepository.GetMulti(x => x.ConsignerID == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ConsignerLevel consignerLevel)
        {
            _consignerLevelRepository.Update(consignerLevel);
        }
    }
}
