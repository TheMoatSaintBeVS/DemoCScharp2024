using Memes.Core.Interfaces;
using Memes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Diagnostics;

namespace Memes.Repositories.EfCore
{
    public class MemesDbContext : DbContext
    {


        public DbSet<Meme> Memes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UpVote> UpVotes { get; set; }

        private readonly string _connectionString;

        public MemesDbContext(string connectionString)
        {
            _connectionString = connectionString;

        }

        public MemesDbContext(DbContextOptions<MemesDbContext> options) : base(options)
        {

            //_connectionString = options.
        }

        // Server=tcp:micgiserver2022.database.windows.net,1433;
        // Initial Catalog=Db2022Memes;Persist Security Info=False;
        // User ID=micgi;Password={your_password};
        // MultipleActiveResultSets=False;Encrypt=True;
        // TrustServerCertificate=False;Connection Timeout=30;


        //"Server=tcp:micgiserver2022.database.windows.net,1433;"
        //        + " Initial Catalog=Db2022Memes ; "
        //        + " User ID=Teacher;Password=$PSG#is#Magic$; "

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
          
            // simple logging
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            modelBuilder.Entity<Meme>()
                .HasOne<Image>(m => m.Image)
                .WithMany(i => i.Memes)
                .HasForeignKey(m => m.ImageId);

            modelBuilder.Entity<Meme>()
                .HasOne<User>(m => m.User)
                .WithMany(u => u.Memes)
                .HasForeignKey(m => m.UserId);


            // many to many 
            // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            modelBuilder.Entity<MemeTag>()
                .HasKey(mt => new { mt.MemeId, mt.TagId });


            modelBuilder.Entity<MemeTag>()
                .HasOne(mt => mt.Meme)
                .WithMany(m => m.MemeTags)
                .HasForeignKey(mt => mt.MemeId);

            modelBuilder.Entity<MemeTag>()
                .HasOne(mt => mt.Tag)
                .WithMany(t => t.MemeTags)
                .HasForeignKey(mt => mt.TagId);




            modelBuilder.Entity<UpVote>()
               .HasKey(uv => new { uv.MemeId, uv.UserId })
               ;


            modelBuilder.Entity<UpVote>()
                .HasOne(uv => uv.Meme)
                .WithMany(m => m.UpVotes)
                .HasForeignKey(uv => uv.MemeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UpVote>()
               .HasOne(uv => uv.User)
               .WithMany(u => u.UpVotes)
               .HasForeignKey(uv => uv.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
