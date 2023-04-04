// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void test1()
	    {
			Stage stage = new Stage();
			Performer performer1 = new Performer("Name1", "Name2", 18);
			Performer performer = new Performer("FirstName", "LastName", 5);

			stage.AddPerformer(performer1);

			Assert.That(stage.Performers.Count.Equals(1));

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			});
		}

		[Test]
		public void test2()
		{
			Stage stage = new Stage();
			Performer performer1 = new Performer("Name1", "Name2", 18);
			DateTime date1 = new DateTime(2010, 8, 18, 13, 30, 15);
			DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

			TimeSpan interval = date2 - date1;
			Song song = new Song("Song", interval);

			stage.AddPerformer(performer1);

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(null);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}

		[Test]
		public void Test3()
		{
			Stage stage = new Stage();
			Performer performer1 = new Performer("Name1", "Name2", 18);
			DateTime date1 = new DateTime(2010, 8, 18, 13, 29, 15);
			DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

			TimeSpan interval = date2 - date1;
			Song song = new Song("Song", interval);
			stage.AddPerformer(performer1);
			stage.AddSong(song);

			string expected = $"{$"{song.Name} ({song.Duration:mm\\:ss})"} will be performed by Name1 Name2";
			string result = stage.AddSongToPerformer("Song", "Name1 Name2");

			Assert.That(result.Equals(expected));

			Assert.That(performer1.SongList.Count.Equals(1));

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSongToPerformer(null, "Name1 Name2");
			});

			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSongToPerformer("Song", null);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("Song", "Name2");
			});

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("Song1", "Name1 Name2");
			});
		}

		[Test]
		public void Test4()
		{
			Stage stage = new Stage();
			Performer performer1 = new Performer("Name1", "Name2", 18);
			DateTime date1 = new DateTime(2010, 8, 18, 13, 29, 15);
			DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

			TimeSpan interval = date2 - date1;
			Song song = new Song("Song", interval);
			stage.AddPerformer(performer1);
			stage.AddSong(song);
			stage.AddSongToPerformer("Song", "Name1 Name2");

			string expected = $"1 performers played 1 songs";
			string result = stage.Play();

			Assert.That(result.Equals(result));
		}
	}
}