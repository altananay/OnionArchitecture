using Application.DTOs;
using Application.Results;
using Application.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        //IDataResult<User> Login(UserForLoginDto userForLoginDto);
        //IResult UserExists(string email);
        //IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
