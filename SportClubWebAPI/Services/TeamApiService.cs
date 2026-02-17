using Microsoft.EntityFrameworkCore;
using SportClubWebAPI.Models;

namespace SportClubWebAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly SportClubDbContext _context;

        public TeamService(SportClubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Team.Include(t => t.Players).ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _context.Team.Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            _context.Team.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team?> UpdateTeamAsync(int id, Team team)
        {
            if (id != team.Id)
                return null;

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return team;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TeamExistsAsync(id))
                    return null;
                throw;
            }
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Team.FindAsync(id);
            if (team == null)
                return false;

            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> TeamExistsAsync(int id)
        {
            return await _context.Team.AnyAsync(e => e.Id == id);
        }
    }
}
