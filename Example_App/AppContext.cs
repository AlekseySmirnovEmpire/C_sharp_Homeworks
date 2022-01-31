using System;
using System.Data.Entity;

namespace Example_App
{
    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}
