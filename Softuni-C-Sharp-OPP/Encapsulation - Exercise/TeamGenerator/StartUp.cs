using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string inputData = Console.ReadLine();

            while (inputData != "END")
            {
                var splitedData = inputData.Split(";").ToList();
                string comand = splitedData[0];
                string teamName = splitedData[1];

                try
                {
                    if (comand == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (comand == "Add")
                    {
                        string playerName = splitedData[2];
                        int endurance = int.Parse(splitedData[3]);
                        int sprint = int.Parse(splitedData[4]);
                        int dribble = int.Parse(splitedData[5]);
                        int passing = int.Parse(splitedData[6]);
                        int shooting = int.Parse(splitedData[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        if (IsContainedTeam(teams, teamName))
                        {
                            foreach (var team in teams)
                            {
                                if (team.Name == teamName)
                                {
                                    team.AddPlayer(player);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (comand == "Remove")
                    {
                        string playerName = splitedData[2];

                        if (IsContainedTeam(teams, teamName))
                        {
                            foreach (var team in teams)
                            {
                                if (team.Name == teamName)
                                {
                                    team.RemovePlayer(playerName);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (comand == "Rating")
                    {
                        if (IsContainedTeam(teams, teamName))
                        {
                            foreach (var team in teams)
                            {
                                if (team.Name == teamName)
                                {
                                    Console.WriteLine($"{teamName} - {team.GetAverageStatOfTeam()}");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                }

                inputData = Console.ReadLine();
            }
        }

        private static bool IsContainedTeam(List<Team> teams, string teamName)
        {
            foreach (var team in teams)
            {
                if (team.Name == teamName)
                    return true;
            }

            return false;
        }
    }
}
