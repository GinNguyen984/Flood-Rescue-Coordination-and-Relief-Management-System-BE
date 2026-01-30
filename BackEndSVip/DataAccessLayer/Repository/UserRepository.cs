using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly RescueManagementDbContext _rescueManagementDBContext;

        public UserRepository(RescueManagementDbContext rescueManagementDbContext) : base(rescueManagementDbContext)
        {
            _rescueManagementDBContext = rescueManagementDbContext;
        }
    }
}
