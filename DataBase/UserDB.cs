using Microsoft.EntityFrameworkCore;

namespace Authorisation.DataBase;

public class UserDB :DbContext
{
    public UserDB (DbContextOptions options) :base (options)
    {

    }
    public DbSet<User> Users { get; set; }
}
