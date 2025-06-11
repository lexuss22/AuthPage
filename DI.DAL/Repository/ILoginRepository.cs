using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Contracts.Model.Domain;

namespace DI.DAL.Repository
{
    public interface ILoginRepository
    {
        Task<string?> LoginAsync(UserLoginRequest userLoginModel);
    }
}
