using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Internals
{
    public enum Status
    {
        NL = 0,
        L = 1
    }
    public class Team
    {
        public string name;
        public int score;
        public int reputation;
        public int fans;
    }

    public class TeamPlayers
    {
        public string top;
        public string mid;
        public string jungler;
        public string adcarry;
        public string support;
    }



    public class Ext
    {
        public Status status = new Status();
        public class Player
        {
            public string name;
            public Team team;
            public TeamPlayers team_players;
        }

    }
}
