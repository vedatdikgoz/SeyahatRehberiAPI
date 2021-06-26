using System.Collections.Generic;
using SeyahatRehberi.Core.Entities.Concrete;

namespace SeyahatRehberi.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
