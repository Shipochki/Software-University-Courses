namespace UniversityLibrary.Test
{
    using NUnit.Framework;
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using System.Text;

    public class Tests
    {
		[SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            TextBook textBook = new TextBook("Title", "Author", "Category");

            UniversityLibrary library = new UniversityLibrary();

            var actualResult = library.AddTextBookToLibrary(textBook);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Book: Title - 1");
			sb.AppendLine($"Category: Category");
			sb.AppendLine($"Author: Author");

			var result = sb.ToString().TrimEnd();

            Assert.That( result.Equals(actualResult));
		}

		[Test]
		public void Test2()
		{
			TextBook textBook = new TextBook("Title", "Author", "Category");
			TextBook textBook1 = new TextBook("Title1", "Author1", "Category1");
			TextBook textBook2 = new TextBook("Title2", "Author2", "Category2");

			UniversityLibrary library = new UniversityLibrary();

			library.AddTextBookToLibrary(textBook);
			library.AddTextBookToLibrary(textBook1);
			library.AddTextBookToLibrary(textBook2);

			var expectedResult = textBook2.InventoryNumber;

			Assert.That(expectedResult.Equals(3));
		}

		[Test]
		public void Test3()
		{
			TextBook textBook = new TextBook("Title", "Author", "Category");
			TextBook textBook1 = new TextBook("Title1", "Author1", "Category1");
			TextBook textBook2 = new TextBook("Title2", "Author2", "Category2");

			UniversityLibrary library = new UniversityLibrary();

			library.AddTextBookToLibrary(textBook);
			library.AddTextBookToLibrary(textBook1);
			library.AddTextBookToLibrary(textBook2);

			Assert.That(library.Catalogue.Count.Equals(3));
		}

		[Test]
		public void Test4()
		{
			TextBook textBook = new TextBook("Title", "Author", "Category");
			TextBook textBook1 = new TextBook("Title1", "Author1", "Category1");
			TextBook textBook2 = new TextBook("Title2", "Author2", "Category2");

			UniversityLibrary library = new UniversityLibrary();

			library.AddTextBookToLibrary(textBook);
			library.AddTextBookToLibrary(textBook1);
			library.AddTextBookToLibrary(textBook2);

			var expectedResult = library.LoanTextBook(2, "Pesho");
			var result = "Title1 loaned to Pesho.";

			Assert.That(expectedResult.Equals(result));
			Assert.That(textBook1.Holder.Equals("Pesho"));
		}

		[Test]
		public void Test5()
		{
			TextBook textBook = new TextBook("Title", "Author", "Category");
			TextBook textBook1 = new TextBook("Title1", "Author1", "Category1");
			TextBook textBook2 = new TextBook("Title2", "Author2", "Category2");

			UniversityLibrary library = new UniversityLibrary();

			library.AddTextBookToLibrary(textBook);
			library.AddTextBookToLibrary(textBook1);
			library.AddTextBookToLibrary(textBook2);

			library.LoanTextBook(2, "Pesho");
			var expectedResult = library.LoanTextBook(2, "Pesho");
			var result = "Pesho still hasn't returned Title1!";

			Assert.That(expectedResult.Equals(result));
		}

		[Test]
		public void Test6()
		{
			TextBook textBook = new TextBook("Title", "Author", "Category");
			TextBook textBook1 = new TextBook("Title1", "Author1", "Category1");
			TextBook textBook2 = new TextBook("Title2", "Author2", "Category2");

			UniversityLibrary library = new UniversityLibrary();

			library.AddTextBookToLibrary(textBook);
			library.AddTextBookToLibrary(textBook1);
			library.AddTextBookToLibrary(textBook2);

			var expectedResult = library.ReturnTextBook(2);
			var result = "Title1 is returned to the library.";

			Assert.That(expectedResult.Equals(result));
			Assert.That(textBook1.Holder.Equals(string.Empty));
		}
	}
}