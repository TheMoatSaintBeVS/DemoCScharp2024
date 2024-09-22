using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Entities
{
    public class MemesContext : DbContext
    {


        public DbSet<Meme> Memes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //public DbSet<UpVote> UpVotes { get; set; }

        //public MemesContext(DbContextOptions<MemesContext> options)
        //: base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=M15R2\SQL20219;database=Db2023memes;User ID=UserDb2023Memes;Password=UserDb2023Memes;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meme>()
                .HasOne(p => p.User)
                .WithMany(b => b.Memes)
                .HasForeignKey(p => p.UserId);
        }

    }
}
