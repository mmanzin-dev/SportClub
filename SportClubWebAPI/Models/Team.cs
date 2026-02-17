namespace SportClubWebAPI.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Coach { get; set; } = string.Empty;

        public int NumberOfPlayers { get; set; }

        public int YearFounded { get; set; }

        public List<Player>? Players { get; set; }
    }
}
