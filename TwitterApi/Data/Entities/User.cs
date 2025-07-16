using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TwitterApi.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImagePath { get; set; } = string.Empty;
        public string FullName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        public DateTime LastUpdateAt { get; set; } = DateTime.Now;
        public ICollection<View> Views { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
