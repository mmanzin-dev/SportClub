using SportClubWebAPI.Models;

namespace SportClubWebAPI.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player?> GetPlayerByIdAsync(int id);
        Task<Player> CreatePlayerAsync(Player player);
        Task<Player?> UpdatePlayerAsync(int id, Player player);
        Task<bool> DeletePlayerAsync(int id);
        Task<IEnumerable<Player>> FilterPlayersAsync(string? position, bool? active);
    }
}
