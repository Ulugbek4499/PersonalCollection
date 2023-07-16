using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
