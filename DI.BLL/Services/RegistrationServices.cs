using DI.Contracts.Model.Domain;
using DI.DAL.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.BLL.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationServices(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public async Task<IdentityResult?> Regist(UserRegistrationModel userRegistrationModel)
        {
            if (userRegistrationModel != null)
            {
                var result = await registrationRepository.RegisterUserAsync(userRegistrationModel);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
