using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlantsForum.Models;

namespace PlantsForum.Data
{
    public class PlantsForumContext : DbContext
    {
        public PlantsForumContext (DbContextOptions<PlantsForumContext> options)
            : base(options)
        {
        }

        public DbSet<PlantsForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<PlantsForum.Models.Comment> Comment { get; set; } = default!;
    }
}
