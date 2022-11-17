using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<Category> Categories { get; set; } 
        public DbSet<PostCategory> postCategories { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> postTags { get; set; }

    }
}
