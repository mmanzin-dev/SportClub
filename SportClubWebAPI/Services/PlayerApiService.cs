using Microsoft.EntityFrameworkCore;
using SportClubWebAPI.Models;

namespace SportClubWebAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly SportClubDbContext _context;

        public PlayerService(SportClubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Player.Include(p => p.Team).ToListAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _context.Player.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> UpdatePlayerAsync(int id, Player player)
        {
            if (id != player.Id)
                return null;

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return player;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PlayerExistsAsync(id))
                    return null;
                throw;
            }
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null)
                return false;

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Player>> FilterPlayersAsync(string? position, bool? active)
        {
            var query = _context.Player.Include(p => p.Team).AsQueryable();

            if (!string.IsNullOrEmpty(position))
            {
                query = query.Where(p => p.Position.Contains(position));
            }

            if (active.HasValue)
            {
                query = query.Where(p => p.Active == active.Value);
            }

            return await query.ToListAsync();
        }

        private async Task<bool> PlayerExistsAsync(int id)
        {
            return await _context.Player.AnyAsync(e => e.Id == id);
        }
    }
}
