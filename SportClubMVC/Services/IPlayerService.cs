using SportClubMVC.Models;

namespace SportClubMVC.Services
{
    public interface IPlayerService {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player?> GetPlayerByIdAsync(int id);
        Task CreatePlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
        Task<List<Player>> GetActivePlayersAsync();
        Task<List<Player>> SearchByPositionAsync(string position);
    }
}