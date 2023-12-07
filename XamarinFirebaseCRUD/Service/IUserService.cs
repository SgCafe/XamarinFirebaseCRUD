using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirebaseCRUD.Service
{
    public interface IUserService
    {
        Task<bool> RegisterUser(string username, string password);
        Task<bool> UserExist(string login, string loginPassword);

    }
}
