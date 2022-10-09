using Application.Abstractions;
using Application.DTOs;
using Application.Helpers;
using Application.Results;
using Application.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        //private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService /*ITokenHelper tokenHelper*/)
        {
            _userService = userService;
            //_tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "kullanıcı kayıt edildi");
        }

        //public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        //{
        //    var userToCheck = _userService.GetByMail(userForLoginDto.Email);
        //    if (userToCheck == null)
        //    {
        //        return new ErrorDataResult<User>(Messages.UserNotFound);
        //    }

        //    if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
        //    {
        //        return new ErrorDataResult<User>(Messages.PasswordError);
        //    }

        //    return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        //}

        //public IResult UserExists(string email)
        //{
        //    if (_userService.GetByMail(email) != null)
        //    {
        //        return new ErrorResult(Messages.UserAlreadyExists);
        //    }
        //    return new SuccessResult();
        //}

        //public IDataResult<AccessToken> CreateAccessToken(User user)
        //{
        //    var claims = _userService.GetClaims(user);
        //    var accessToken = _tokenHelper.CreateToken(user, claims);
        //    return new SuccessDataResult<AccessToken>(accessToken, Messages.LoginSuccessful);
        //}
    }
}