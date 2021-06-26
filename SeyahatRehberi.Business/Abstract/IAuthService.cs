using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.Entities.Concrete;
using SeyahatRehberi.Core.Utilities.Results;
using SeyahatRehberi.Core.Utilities.Security.JWT;
using SeyahatRehberi.Entities.DTOs;

namespace SeyahatRehberi.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
