using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FootballTeam.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				FootballTeam team = new FootballTeam(string.Empty, 20);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				FootballTeam team = new FootballTeam("Team", 10);
			});
		}

		[Test]
		public void Test2()
		{
			FootballPlayer player = new FootballPlayer("Name1", 1, "Forward");
			FootballTeam team = new FootballTeam("Team", 20);


			string excpectedResult = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
			string result = team.AddNewPlayer(player);

			Assert.That(excpectedResult.Equals(result));
		}

		[Test]
		public void Test3()
		{
			FootballPlayer player1 = new FootballPlayer($"name20", 16, "Midfielder");
			FootballTeam team = new FootballTeam("Team", 15);

			for (int i = 1; i <= 15; i++)
			{
				FootballPlayer player = new FootballPlayer($"name{i}", i, "Midfielder");
				team.AddNewPlayer(player);
			}

			string excpectedResult = "No more positions available!";
			string result = team.AddNewPlayer(player1);

			Assert.That(excpectedResult.Equals(result));
		}

		[Test]
		public void Test4()
		{
			FootballPlayer player1 = new FootballPlayer($"name20", 16, "Midfielder");
			FootballTeam team = new FootballTeam("Team", 15);

			team.AddNewPlayer(player1);
			FootballPlayer result = team.PickPlayer("name20");

			Assert.That(player1.Equals(result));
		}

		[Test]
		public void Test5()
		{
			FootballPlayer player = new FootballPlayer($"name20", 16, "Midfielder");
			FootballTeam team = new FootballTeam("Team", 15);

			team.AddNewPlayer(player);
			string excpected = $"{player.Name} scored and now has {player.ScoredGoals + 1} for this season!";
			string result = team.PlayerScore(16);

			Assert.That(excpected.Equals(result));
		}

		[Test]
		public void Test6()
		{
			FootballTeam team = new FootballTeam("Team", 15);
			List<FootballPlayer> players = new List<FootballPlayer>();

			for (int i = 1; i <= 15; i++)
			{
				FootballPlayer player = new FootballPlayer($"name{i}", i, "Midfielder");
				team.AddNewPlayer(player);
				players.Add(player);
			}

			List<FootballPlayer> playersResult = team.Players;

			Assert.That(players.Count.Equals(playersResult.Count));
		}

		[Test]
		public void Test7()
		{
			FootballTeam team = new FootballTeam("Team", 15);

			string name = "Team";
			int capacity = 15;

			Assert.That(name.Equals(team.Name));
			Assert.That(capacity.Equals(team.Capacity));
		}
	}
}