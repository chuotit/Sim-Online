using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IAppRoleGroupRepository : IRepository<AppRoleGroup>
    {

    }
    public class AppRoleGroupRepository : RepositoryBase<AppRoleGroup>, IAppRoleGroupRepository
    {
        public AppRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
