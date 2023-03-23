 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Models
{ 
    /// <summary>
    /// THis class will connect to JSCISecurity database to create
    /// Users and Roles
    /// </summary>
    public class JCISecurityDbContext : IdentityDbContext 
    {
        public JCISecurityDbContext(DbContextOptions<JCISecurityDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
