using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

    public class SportClubDbContext : DbContext
    {
        public SportClubDbContext (DbContextOptions<SportClubDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportClub.Models.Player> Player { get; set; } = default!;

        public DbSet<SportClub.Models.Team> Team { get; set; } = default!;
    }
