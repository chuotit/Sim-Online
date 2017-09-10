using System.Collections.Generic;
using SimOnline.Data.Infrastructure;
using SimOnline.Data.Repositories;
using SimOnline.Model.Models;

namespace SimOnline.Service
{
    public interface IAgentService
    {
        Agent Add(Agent agent);

        void Update(Agent agent);

        Agent Delete(int id);

        IEnumerable<Agent> GetAll();

        IEnumerable<Agent> GetAll(string keyword);

        Agent GetById(int id);

        //IEnumerable<Agent> GetBySimID(int id);

        void SaveChanges();
    }

    internal class AgentService : IAgentService
    {
        private IAgentRepository _agentRepository;
        private IUnitOfWork _unitOfWork;

        public AgentService(IAgentRepository agentRepository, IUnitOfWork unitOfWork)
        {
            this._agentRepository = agentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Agent Add(Agent agent)
        {
            return _agentRepository.Add(agent);
        }

        public Agent Delete(int id)
        {
            return _agentRepository.Delete(id);
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agentRepository.GetAll();
        }

        public Agent GetById(int id)
        {
            return _agentRepository.GetSingleById(id);
        }

        public IEnumerable<Agent> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _agentRepository.GetMulti(x => x.Name.Contains(keyword) || x.Address.Contains(keyword) || x.Email.Contains(keyword) || x.Hotline.Contains(keyword));
            else
                return _agentRepository.GetAll();

        }

        // Đoạn này cần xem lại
        //public IEnumerable<Agent> GetBySimID(int id)
        //{
        //    return _agentRepository.GetMulti(x => x.ID == id, new string[] { "SimNetwork" });
        //}

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Agent agent)
        {
            _agentRepository.Update(agent);
        }
    }
}