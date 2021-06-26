
using SeyahatRehberi.Core.Entities;

namespace SeyahatRehberi.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
