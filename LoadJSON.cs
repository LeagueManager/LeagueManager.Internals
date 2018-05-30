using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace LeagueManager.Internals
{
    public class LoadJSON
    {
        internal static string LoadFileInit = File.ReadAllText("leaguemanager.init");
        internal static string[] Files_Init = LoadFileInit.Split(new string[] {"@\"" },StringSplitOptions.None);

        internal string memoryString = String.Empty;

        public void mainActivity(Main main)
        {
            for (int i = 0; i < Files_Init.Length; i++)
            {

                if (i >= 1)
                {

                    string a = Files_Init[i].Replace("\r\n", string.Empty);
                    string b = a.Replace("\"\\",string.Empty);
                    string c = String.Empty;
                    for(int x = 0; x < b.Length-1; x++)
                    {
                        c = c + b[x];
                    }

                    memoryString = File.ReadAllText(c);
                    main.memoryProgram_Utils.memoryStrings.Add(memoryString);
                }

            }
        }
        
    }
}
