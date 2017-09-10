using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface ISimStoreService
    {
        SimStore Add(SimStore simStore);

        void Update(SimStore simStore);

        SimStore Delete(int id);

        IEnumerable<SimStore> GetAll();

        SimStore GetById(int id);

        int CheckSim(string simName, string price, string agentId);

        IEnumerable<SimStore> GetByNetwork(int id);

        IEnumerable<SimStore> SearchSim(Expression<Func<SimStore, bool>> where);

        void SaveChanges();
        int SearchSim(string simStore, string price, string agentId);
    }

    public class SimStoreService : ISimStoreService
    {
        private ISimStoreRepository _simStoreRepository;
        private IUnitOfWork _unitOfWork;

        public SimStoreService(ISimStoreRepository simStoreRepository, IUnitOfWork unitOfWork)
        {
            this._simStoreRepository = simStoreRepository;
            this._unitOfWork = unitOfWork;
        }

        public SimStore Add(SimStore simStore)
        {
            return _simStoreRepository.Add(simStore);
        }

        public int CheckSim(string simName, string price, string agentId)
        {
            return _simStoreRepository.CheckSim(simName, price, agentId);
        }

        public SimStore Delete(int id)
        {
            return _simStoreRepository.Delete(id);
        }

        public IEnumerable<SimStore> GetAll()
        {
            return _simStoreRepository.GetAll(new string[] { "SimNetwork", "Agent" });
        }

        public SimStore GetById(int id)
        {
            return _simStoreRepository.GetSingleById(id);
        }

        public IEnumerable<SimStore> GetByNetwork(int id)
        {
            return _simStoreRepository.GetMulti(x => x.NetWorkID == id, new string[] { "SimNetwork" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<SimStore> SearchSim(Expression<Func<SimStore, bool>> where)
        {
            var query = _simStoreRepository.GetMulti(where, new string[] { "SimNetwork", "Agent" });

            return query;
        }

        public int SearchSim(string simStore, string price, string agentId)
        {
            throw new NotImplementedException();
        }

        public void Update(SimStore simStore)
        {
            _simStoreRepository.Update(simStore);
        }
    }
}
