using SportClubMVC.Models;

namespace SportClubMVC.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly SportClubDbContext _context;

        public PlayerService(SportClubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Player
            .Include(p => p.Team)
            .ToListAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _context.Player
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePlayerAsync(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Player.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                _context.Player.Remove(player);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Player>> GetActivePlayersAsync()
        {
            return await _context.Player
            .Include(p => p.Team)
            .Where(p => p.Active == true)
            .ToListAsync();
        }

        public async Task<List<Player>> SearchByPositionAsync(string position)
        {
            return await _context.Player
            .Include(p => p.Team)
            .Where(p => p.Position.Contains(position))
            .ToListAsync();
        }
    }
    
}