using CentralDeErro.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAuthentication
    {
        Task<AuthenticationOutPut> SignUp(SignUpDto signUpDto);
        Task<AuthenticationOutPut> SignIn(SignInDto signInDto);
    }
}
