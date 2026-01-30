using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.ViewModels;


namespace BusinessLayer.IService
{
    public interface IUserService
    {
        Task<UserVM> GetByIdAsync(int id);
        Task<UserVM> AddAsync(UserAddVM userAddVM);
        Task<UserVM> UpdateAsync(int id, UserAddVM userAddVM);
        Task<bool> DeleteAsync(int id);
        Task<LoginResponseVM> LoginAsync(LoginVM loginInfo);
        Task<bool> RegisterAsync(RegisterVM registerInfo);
    }
}
