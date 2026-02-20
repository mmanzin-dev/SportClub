namespace SportClub.Models
{
    public class Team
    {
        public int Id {get; set;}
        
        public string Name {get; set;}

        public string Coach {get; set;}

        public int NumberOfPlayers {get; set;}

        public int YearFounded {get; set;}

        public List<Player> Players {get; set;} = new ();
    }
}