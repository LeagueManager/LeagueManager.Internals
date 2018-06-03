using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueManager.Internals
{
    public class Main
    {
        public Utils.MemoryProgram _memoryProgram = new Utils.MemoryProgram();
        public Internals.LoadJSON _loadJson = new LoadJSON();
        public Dictionary<string,Utils.Team> _teams = new Dictionary<string, Utils.Team>();
        public Utils.User _user = new Utils.User();
    }
}
