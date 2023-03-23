 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Models
{
    /// <summary>
    /// This class will CReate IdentityDatabase and Identity Tables in tat Database
    /// using Code-First Approach of EF Core
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
