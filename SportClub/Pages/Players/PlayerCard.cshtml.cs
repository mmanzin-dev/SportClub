using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

namespace SportClub.Pages.Players
{
    public class PlayerCardModel : PageModel
    {
        private readonly SportClubDbContext _context;

        public PlayerCardModel(SportClubDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Player
                .Include(p => p.Team).ToListAsync();
        }
    }
}
