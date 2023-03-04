namespace Database.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] data = new int[16];
        private Database database;
        private Database emptyDatabase;

        [Test]
        public void Test_Constructor_Database_InputData()
        {
            Database database = new Database(this.data);
        }

        [Test]
        public void Database_Count_Returning_Correct_Format()
        {
            Database database = new Database(this.data);
            Assert.That(database.Count, Is.AssignableFrom(typeof(int)));
        }

        [Test]
        public void Adding_More_Than_Capacity_Throw_Exeption()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database newDatabase = new Database(new int[16]);
                int element = 5;
                newDatabase.Add(element);
            });
        }

        [Test]
        public void Adding_Element()
        {
            this.emptyDatabase = new Database(new int[0]);
            emptyDatabase.Add(5);
            Assert.That(emptyDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void Removing_From_Empty_Database_Throw_Expetion()
        {
            this.emptyDatabase = new Database(new int[0]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.emptyDatabase.Remove();
            });
        }

        [Test]
        public void Removing_Element()
        {
            this.emptyDatabase = new Database(new int[1]);
            this.emptyDatabase.Remove();
            Assert.That(emptyDatabase.Count, Is.EqualTo(0));
        }

        [Test]
        public void Fetch_Return_Correct_Format()
        {
            this.database = new Database(this.data);

            Assert.That(this.database.Fetch(), Is.AssignableFrom(typeof(int[])));
        }
    }
}
