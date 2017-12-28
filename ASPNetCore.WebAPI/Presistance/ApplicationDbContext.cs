using ASPNetCore.WebAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.WebAPI.Presistance
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AuthorBook>().HasKey(b => new { b.AuthorId, b.BookId });

            modelBuilder.Entity<AuthorBook>()
                        .HasOne(ab => ab.Author)
                        .WithMany(a => a.BooksLink)
                        .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                        .HasOne(ab => ab.Book)
                        .WithMany(b => b.AuthorsLink)
                        .HasForeignKey(ab => ab.BookId);
            
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.)
        }
    }
}
