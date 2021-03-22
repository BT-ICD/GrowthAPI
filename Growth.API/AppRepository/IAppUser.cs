using Growth.API.Models;
using Growth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.AppRepository
{
    public interface IAppUser
    {
        Task<DataUpdateResponseDTO> CreateUserAsync(AppUser appUser);
        bool IsUserNameExist(String userName);

    }
}
