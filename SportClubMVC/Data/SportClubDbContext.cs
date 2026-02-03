using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportClubMVC.Models;

    public class SportClubDbContext : DbContext
    {
        public SportClubDbContext (DbContextOptions<SportClubDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportClubMVC.Models.Player> Player { get; set; } = default!;

        public DbSet<SportClubMVC.Models.Team> Team { get; set; } = default!;
    }