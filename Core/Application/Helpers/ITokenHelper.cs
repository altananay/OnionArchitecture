using Application.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user/*, OperationClaim operationClaims*/);
    }
}