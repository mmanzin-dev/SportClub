using SportClubWebAPI.Models;

namespace SportClubWebAPI.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team?> GetTeamByIdAsync(int id);
        Task<Team> CreateTeamAsync(Team team);
        Task<Team?> UpdateTeamAsync(int id, Team team);
        Task<bool> DeleteTeamAsync(int id);
    }
}
