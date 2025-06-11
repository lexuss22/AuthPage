using DI.Contracts.Model.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.DAL.Repository
{
    public interface IRegistrationRepository
    {
        Task<IdentityResult?> RegisterUserAsync(UserRegistrationModel userRegistrationModel);
    }
}
