using System;
using System.Linq;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IAgentRepository : IRepository<Agent>
    {
    }

    internal class AgentRepository : RepositoryBase<Agent>, IAgentRepository
    {
        public AgentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}