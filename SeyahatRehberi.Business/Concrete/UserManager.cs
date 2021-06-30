using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Business.Abstract;
using SeyahatRehberi.Core.Entities.Concrete;
using SeyahatRehberi.DataAccess.Abstract;

namespace SeyahatRehberi.Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User FindByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public User FindByName(string name)
        {
            return _userRepository.Get(u => u.FirstName +" "+u.LastName== name);
        }

    }
}
