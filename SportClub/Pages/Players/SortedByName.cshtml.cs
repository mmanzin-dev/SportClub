using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

namespace SportClub.Pages.Players
{
    public class SortedByNameModel : PageModel
    {
        private readonly SportClubDbContext _context;

        public SortedByNameModel(SportClubDbContext context)
        {
            _context = context;
        }

        public IList<Player> Players {get; set;}
        public string SortOrder {get; set;}

        public async Task OnGetAsync(string sortOrder)
        {
            SortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;

            var PlayersQuery = _context.Player.Include(p => p.Team);

            if (SortOrder == "desc")
            {
                Players = await PlayersQuery
                .OrderByDescending(p => p.FirstName)
                .ThenByDescending(p => p.LastName)
                .ToListAsync();
            } else
            {
                Players = await PlayersQuery
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync();
            }
        }
    }
}