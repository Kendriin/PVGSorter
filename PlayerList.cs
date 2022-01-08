using System;
using System.Collections.Generic;
namespace PVG_PlayerListSorter
{
    class PlayerList
    {
        
        static void Main(string[] args)
        {
            PlayerList p = new PlayerList();
            List<string> currentList = new List<string>();
            string input = "default input";
            string openingStatement = "Hello and thank you for using my sorter!  To add a player use + or - at the start of a name to add or remove them respectively or %commands to view the commands.";
            string commandList = "Use %name to use a command, such as %viewlist.  The commands are: viewlist, randomizelist, viewteamshalf[displays a list of teams based on the halfway point of the list], " +
                                  " commands, terminate[terminates the program]";
            bool running = true;
            Console.WriteLine(openingStatement);
            while (running)
            {
                input = Console.ReadLine();
                if (input == "%terminate") {
                    running = false;
                } else {
                    currentList = p.ActionDetermine(input, currentList);
                }
            }
            
            Console.WriteLine("Thank you for using my sorter! :D");

        }

        public List<string> ActionDetermine(string action, List<string> list)
        {
            if (action.Substring(0, 1) == "+" || action.Substring(0, 1) == "-") {
                list = ActionListItems(action, list);
                } else if (action.Substring(0, 1) == "%") {
                list = ActionsCommands(action, list);
                } else {
                Console.WriteLine("Please enter a valid command.  Type + or - followed by a name to add or remove players respectively, or %commands to view the commands");
                }

            return list;
        }

        public List<string> ActionListItems(string action, List<string> list) {
            char[] remove = { '+', '-' };
            string player = action.TrimStart(remove);
            if (action.Substring(0, 1) == "+"){
                if (list.Contains(player)) {
                    Console.WriteLine(player + " is already in the list");
                } else {
                    list.Add(player);
                    Console.WriteLine(player + " has been added.  There are "+list.Count+" player(s) in the list");
                }
            }
            if(action.Substring(0, 1) == "-") {
                if (list.Contains(player)) {
                    list.Remove(player);
                    Console.WriteLine(player + " has been removed.  There are "+list.Count+" player(s) in the list");
                    } else {
                    Console.WriteLine("The list does not contain " + player);
                    }
                }
            return list;
        }

        public List<string> ActionsCommands(string action, List<string> list)
        {
            if (action == "%commands") {
                Console.WriteLine("Use %name to use a command, such as %viewlist.  The commands are: viewlist, randomizelist, viewteamshalf[displays a list of teams based on the halfway point of the list], " + "viewteamsalternate[Displays teams based on ever other player], commands, terminate[terminates the program]");
            }  else if(action == "%viewlist") {
                Console.WriteLine(displayList(list));
            } else if(action == "%randomizelist") {
                list = shuffeList(list);
            } else if(action == "%teamsbyhalf") {
                Console.WriteLine(teamsbyhalf(list));
                }

            return list;
        }
        public string displayList(List<string> list) {
            string t = "";
            foreach(string a in list) {
                t += a + " ";
                }
            return t;
            }



        public List<string> shuffeList(List<string> list) {
            List<string> shuffledList = new List<string>();
            List<int> picked = new List<int>();
            Random rng = new Random();
            int dice;
            while (picked.Count != list.Count) {
                dice = rng.Next(list.Count);
                while (picked.Contains(dice)) {
                    dice = rng.Next(list.Count);
                    }
                shuffledList.Add(list[dice]);
                picked.Add(dice);
                }
            return shuffledList;
            }



        public string teamsbyhalf(List<string> List) {
            string teams = "Team A: ";
            int cutoff = List.Count / 2;
            
            for(int i = 0; i < cutoff; i++) {
                teams += List[i]+" ";
                }
            teams += ".  Team B:";
            for(int i = cutoff; i < List.Count; i++) {
                teams += List[i] + " ";
                }
            return teams;
           }
    }
}
