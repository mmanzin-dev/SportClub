using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportClubWebAPI.Models;

    public class SportClubDbContext : DbContext
    {
        public SportClubDbContext (DbContextOptions<SportClubDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportClubWebAPI.Models.Player> Player { get; set; } = default!;

        public DbSet<SportClubWebAPI.Models.Team> Team { get; set; } = default!;
    }
