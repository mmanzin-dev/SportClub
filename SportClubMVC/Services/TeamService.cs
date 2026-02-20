using SportClubMVC.Models;

namespace SportClubMVC.Services
{
    public class TeamService : ITeamService
    {
        private readonly SportClubDbContext _context;

        public TeamService(SportClubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Team.ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _context.Team.FindAsync(id);
        }

        public async Task CreateTeamAsync(Team team)
        {
            _context.Team.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            _context.Team.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _context.Team.FindAsync(id);
            if (team != null)
            {
                _context.Team.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}