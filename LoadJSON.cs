using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace LeagueManager.Internals
{
    public class LoadJSON
    {
        internal static string LoadFileInit = File.ReadAllText("leaguemanager.init");
        internal static string[] Files_Init = LoadFileInit.Split(new string[] { "0x1" }, StringSplitOptions.None);

        internal string memoryString = String.Empty;

        public void mainActivity(Main main)
        {
            for (int i = 0; i < Files_Init.Length-1; i++)
            {
                if(i>0)
                memoryString = File.ReadAllText(String.Concat(Files_Init[0],"\\",Files_Init[i]));
                main._memoryProgram.memoryStrings.Add(@memoryString);
            }
            realiseConfig(main);
        }

        private void realiseConfig(Main main)
        {
            main._memoryProgram.memoryStrings.Remove("");
            #region team
            JArray jsonArrayTeam = JArray.Parse(@main._memoryProgram.memoryStrings[0]);
            for (int i = 0; i < jsonArrayTeam.Count; i++)
            {
                var JSONFileTeam = JObject.Parse(jsonArrayTeam[i].ToString());
                main._teams.Add(JSONFileTeam["name"].ToString(), new Utils.Team
                {
                    name = JSONFileTeam["name"].ToString(),
                    wins = int.Parse(JSONFileTeam["wins"].ToString()),
                    loses = int.Parse(JSONFileTeam["loses"].ToString()),
                    rank = int.Parse(JSONFileTeam["rank"].ToString())
                });
            }
            #endregion

            #region user
            JArray jsonArrayUserData = JArray.Parse(@main._memoryProgram.memoryStrings[1]);
                var JSONFileUser = JObject.Parse(jsonArrayUserData[0].ToString());
                main._user.Name = JSONFileUser["name"].ToString();
                JSONFileUser = JObject.Parse(jsonArrayUserData[1].ToString());
            main._user.Team = new Utils.Team()
            {
                name = JSONFileUser["name"].ToString(),
                wins = int.Parse(JSONFileUser["wins"].ToString()),
                loses = int.Parse(JSONFileUser["loses"].ToString()),
                rank = int.Parse(JSONFileUser["rank"].ToString())
            };
            #endregion
        }
    }
}
