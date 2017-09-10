using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IAgentLevelRepository : IRepository<AgentLevel>
    {
    }

    internal class AgentLevelRepository : RepositoryBase<AgentLevel>, IAgentLevelRepository
    {
        public AgentLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}