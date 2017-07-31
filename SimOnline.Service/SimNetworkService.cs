using System.Collections.Generic;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface ISimNetworkService
    {
        SimNetwork Add(SimNetwork simNetwork);

        void Update(SimNetwork simNetwork);

        SimNetwork Delete(int id);

        IEnumerable<SimNetwork> GetAll();

        IEnumerable<SimNetwork> GetAll(string keyword);

        SimNetwork GetById(int id);

        void SaveChanges();
    }

    public class SimNetworkService : ISimNetworkService
    {
        private ISimNetworkRepository _simNetworkRepository;
        private IUnitOfWork _unitOfWork;

        public SimNetworkService(ISimNetworkRepository simNetworkRepository, IUnitOfWork unitOfWork)
        {
            this._simNetworkRepository = simNetworkRepository;
            this._unitOfWork = unitOfWork;
        }

        public SimNetwork Add(SimNetwork simNetwork)
        {
            return _simNetworkRepository.Add(simNetwork);
        }

        public SimNetwork Delete(int id)
        {
            return _simNetworkRepository.Delete(id);
        }

        public IEnumerable<SimNetwork> GetAll()
        {
            return _simNetworkRepository.GetAll();
        }

        public IEnumerable<SimNetwork> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _simNetworkRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _simNetworkRepository.GetAll();
        }

        public SimNetwork GetById(int id)
        {
            return _simNetworkRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SimNetwork simNetwork)
        {
            _simNetworkRepository.Update(simNetwork);
        }
    }
}