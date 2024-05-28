using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.DTOs.Request;
using TechGamer.Application.DTOs.Response;

namespace TechGamer.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<UserRegisteredResponse> RegisterUser(UserRegisteredRequest request);
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
