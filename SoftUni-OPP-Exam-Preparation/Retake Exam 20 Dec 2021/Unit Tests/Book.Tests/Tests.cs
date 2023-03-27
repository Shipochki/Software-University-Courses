namespace Book.Tests
{
	using System;
	using NUnit.Framework;
	using static System.Net.Mime.MediaTypeNames;

	[TestFixture]
	public class Tests
	{
		[Test]
		public void Test1()
		{
			Book book = new Book("Book", "Author");

			Assert.That(book.BookName.Equals("Book"));

			Assert.Throws<ArgumentException>(() =>
			{
				Book book = new Book(null, "Author");
			});
		}

		[Test]
		public void Test2()
		{
			Book book = new Book("Book", "Author");

			Assert.That(book.Author.Equals("Author"));

			Assert.Throws<ArgumentException>(() =>
			{
				Book book = new Book("Book", null);
			});
		}

		[Test]
		public void Test3()
		{
			Book book = new Book("Book", "Author");

			book.AddFootnote(1, "Text");

			Assert.That(book.FootnoteCount.Equals(1));

			Assert.Throws<InvalidOperationException>(() =>
			{
				book.AddFootnote(1, "Text");
			});
		}

		[Test]
		public void Test4()
		{
			Book book = new Book("Book", "Author");

			book.AddFootnote(1, "Text");

			Assert.Throws<InvalidOperationException>(() =>
			{
				book.FindFootnote(2);
			});

			string expected = $"Footnote #1: Text";
			string result = book.FindFootnote(1);

			Assert.That(result.Equals(expected));
		}

		[Test]
		public void Test5()
		{
			Book book = new Book("Book", "Author");

			book.AddFootnote(1, "Text");

			Assert.Throws<InvalidOperationException>(() =>
			{
				book.AlterFootnote(2, "Text2");
			});

			book.AlterFootnote(1, "Text2");

			string expected = $"Footnote #1: Text2";
			string result = book.FindFootnote(1);

			Assert.That(result.Equals(expected));
		}
	}
}