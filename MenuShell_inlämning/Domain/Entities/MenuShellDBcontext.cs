using genomgång_Menushell.Domain;
using System.Data.Entity;

namespace MenuShell_inlämning.Domain.Entities
{
    class MenuShellDBcontext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MenuShellDBcontext() : base("MenuShellDBcontext")
        {

        }
    }
}
