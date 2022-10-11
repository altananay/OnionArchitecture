using Application.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserService
    {
        //IDataResult<List<User>> GetAll();
        IResult Add(User user);
        //IResult Delete(User user);
        //IResult Update(User user);
        //Refactor edilecek.
        //Task<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
