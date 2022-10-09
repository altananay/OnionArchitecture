using Application.Abstractions;
using Application.Repositories;
using Application.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concretes
{
    public class UserManager : IUserService
    {
        IUserReadRepository _userReadRepository;
        IUserWriteRepository _userWriteRepository;

        public UserManager(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public IResult Add(User user)
        {
            _userWriteRepository.Add(user);
            return new SuccessResult("kullanıcı eklendi");
        }

        //public IResult Delete(User user)
        //{
        //    try
        //    {
        //        _userDal.Delete(user);
        //        return new SuccessResult(Messages.UserDeleted);
        //    }
        //    catch (Exception)
        //    {
        //        return new ErrorResult(Messages.UnknownError);
        //    }
        //}

        //public IDataResult<List<User>> GetAll()
        //{
        //    return new SuccessDataResult<List<User>>(_userDal.GetAll());
        //}

        public IDataResult<User> GetByMail(string email)
        {
            //return _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(_userReadRepository.Get(u => u.Email == email));
        }

        //public List<OperationClaim> GetClaims(User user)
        //{
        //    return _userDal.GetClaims(user);
        //}

        //public IResult Update(User user)
        //{
        //    if (user._id == null)
        //    {
        //        return new ErrorResult(Messages.UnknownError);
        //    }
        //    else
        //    {
        //        return new SuccessResult(Messages.UserUpdated);
        //    }
        //}
    }
}