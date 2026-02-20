using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

namespace SportClub.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly SportClubDbContext _context;

        public DetailsModel(SportClubDbContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.Include(p => p.Team).FirstOrDefaultAsync(m => m.Id == id);

            if (player is not null)
            {
                Player = player;

                return Page();
            }

            return NotFound();
        }
    }
}
