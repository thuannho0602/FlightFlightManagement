using FlightManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class UserServices:IUserServices
    {
        ApplicationDbContext _appDbContext;
        public UserServices(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
