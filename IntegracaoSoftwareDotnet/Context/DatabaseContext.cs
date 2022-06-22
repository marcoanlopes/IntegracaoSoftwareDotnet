using IntegacaoSoftwareDotnet.Models;
using IntegracaoSoftwareDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoSoftwareDotnet.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Character> Characters { get; set; } = null;
        public DbSet<Party> Party { get; set; } = null;
        public DbSet<CharacterAvailable> CharactersAvailable { get; set; } = null;
        
    }
}
