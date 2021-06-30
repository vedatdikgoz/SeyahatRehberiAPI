

using SeyahatRehberi.Core.Entities;

namespace SeyahatRehberi.Entities.DTOs
{
    public class UserDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
