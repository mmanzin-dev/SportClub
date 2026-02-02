using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

namespace SportClub.Pages.Players
{
    public class FilterByTeamModel : PageModel
    {
        private readonly SportClubDbContext _context;

        public FilterByTeamModel(SportClubDbContext context)
        {
            _context = context;
        }

        public IList<Player> Players {get; set;}
        public IList<Team> Teams {get; set;}
        public int? SelectedTeamId {get; set;}

        public async Task OnGetAsync(int? teamId)
        {
            SelectedTeamId = teamId;

            Teams = await _context.Team.
            ToListAsync();

            if (teamId != null)
            {
                Players = await _context.Player
                .Include(p => p.Team)
                .Where(p => p.TeamId == teamId)
                .ToListAsync();
            } else
            {
                Players = await _context.Player
                .Include(p => p.Team)
                .ToListAsync();
            }
        }
    }
}