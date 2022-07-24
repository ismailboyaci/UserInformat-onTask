using Microsoft.EntityFrameworkCore;
using UserWebApi.Models;

namespace UserWebApi.Data
{
    public class UserInformationContext :DbContext
    {
        public UserInformationContext(DbContextOptions<UserInformationContext>options) : base(options)
        {
        }
            public DbSet<UserInformation> UserInformations { get; set; }
    }
}
