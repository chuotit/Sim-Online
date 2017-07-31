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
    public interface ISimNumberService
    {
        SimNumber Add(SimNumber simNumber);

        void Update(SimNumber simNumber);

        SimNumber Delete(int id);

        IEnumerable<SimNumber> GetAll();

        SimNumber GetById(int id);

        IEnumerable<SimNumber> GetByNetwork(int id);

        IEnumerable<SimNumber> Search(string keyword, int consignerId, int networkId, decimal minPrice, decimal maxPrice);

        void SaveChanges();
    }

    public class SimNumberService : ISimNumberService
    {
        private ISimNumberRepository _simNumberRepository;
        private IUnitOfWork _unitOfWork;

        public SimNumberService(ISimNumberRepository simNumberRepository, IUnitOfWork unitOfWork)
        {
            this._simNumberRepository = simNumberRepository;
            this._unitOfWork = unitOfWork;
        }

        public SimNumber Add(SimNumber simNumber)
        {
            return _simNumberRepository.Add(simNumber);
        }

        public SimNumber Delete(int id)
        {
            return _simNumberRepository.Delete(id);
        }

        public IEnumerable<SimNumber> GetAll()
        {
            return _simNumberRepository.GetAll(new string[] { "SimNetwork", "Consigner" });
        }

        public SimNumber GetById(int id)
        {
            return _simNumberRepository.GetSingleById(id);
        }

        public IEnumerable<SimNumber> GetByNetwork(int id)
        {
            return _simNumberRepository.GetMulti(x => x.NetWorkID == id, new string[] { "SimNetwork" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<SimNumber> Search(string keyword, int consignerId, int networkId, decimal minPrice, decimal maxPrice)
        {
            return _simNumberRepository.SearchSimNumber(keyword, consignerId, networkId, minPrice, maxPrice, new string[] { "SimNetwork", "Consigner" });
        }

        public void Update(SimNumber simNumber)
        {
            _simNumberRepository.Update(simNumber);
        }
    }
}
