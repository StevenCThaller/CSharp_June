using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class IndexWrapper
    {
        public HeroOnTeam Form { get; set; }
        public List<Hero> AllHeroes { get; set; }
        public List<Team> AllTeams { get; set; }
    }
}