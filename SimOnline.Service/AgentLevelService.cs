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
    public interface IAgentLevelService
    {
        AgentLevel Add(AgentLevel agentLevel);

        void Update(AgentLevel agentLevel);

        AgentLevel Delete(int id);

        IEnumerable<AgentLevel> GetAll();

        AgentLevel GetById(int id);

        IEnumerable<AgentLevel> GetByAgentID(int id);

        void SaveChanges();
    }

    class AgentLevelService : IAgentLevelService
    {
        private IAgentLevelRepository _agentLevelRepository;
        private IUnitOfWork _unitOfWork;

        public AgentLevelService(IAgentLevelRepository agentLevelRepository, IUnitOfWork unitOfWork)
        {
            this._agentLevelRepository = agentLevelRepository;
            this._unitOfWork = unitOfWork;
        }

        public AgentLevel Add(AgentLevel agentLevel)
        {
            return _agentLevelRepository.Add(agentLevel);
        }

        public AgentLevel Delete(int id)
        {
            return _agentLevelRepository.Delete(id);
        }

        public IEnumerable<AgentLevel> GetAll()
        {
            return _agentLevelRepository.GetAll();
        }

        public AgentLevel GetById(int id)
        {
            return _agentLevelRepository.GetSingleById(id);
        }
        
        public IEnumerable<AgentLevel> GetByAgentID(int id)
        {
            return _agentLevelRepository.GetMulti(x => x.AgentID == id.ToString());
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(AgentLevel agentLevel)
        {
            _agentLevelRepository.Update(agentLevel);
        }
    }
}
