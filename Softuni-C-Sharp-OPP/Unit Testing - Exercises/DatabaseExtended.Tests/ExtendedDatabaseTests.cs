namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] persons = new Person[16];
        private Person[] emptyPersons = new Person[0];

        [Test]
        public void Test_Constructor_Input_Data()
        {
            Database database = new Database(new Person[0]);
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Count_Property_Returning_Correct_Format()
        {
            Database database = new Database(new Person[0]);
            Assert.That(database.Count, Is.AssignableFrom(typeof(int)));
        }

        [Test]
        public void Test_AddRange_Throwing_Ecxeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(new Person[17]);
            });
        }

        [Test]
        public void Test_Adding_Person()
        {
            Person person = new Person(1, "1");
            Database database = new Database(person);
            database.Add(new Person(2, "2"));

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Adding_Person_More_Than_Capacity_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            Database database = new Database(person);
            for (int i = 2; i <= 16; i++)
            {
                database.Add(new Person(i, $"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "17"));
            });
        }

        [Test]
        public void Test_Adding_Еxisting_Person_WithName_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(2, "1"));
            });
        }

        [Test]
        public void Test_Adding_Еxisting_Person_WithId_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1, "2"));
            });
        }

        [Test]
        public void Test_Remove_Person_From_EmptyDatabase_Throwing_Exception()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_Remove_Person_From_Database()
        {
            Person person = new Person(1, "1");
            Database database = new Database(person);
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_FindByUsername_With_Null_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            string name = null;
            Database database = new Database(person);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        [Test]
        public void Test_FindByUsername_With_EmptyString_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            string name = string.Empty;
            Database database = new Database(person);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        [Test]
        public void Test_FindByUsername_With_Non_Existing_Person_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            string name = "2";
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        [Test]
        public void Test_FindByUsername_With_Correct_Input()
        {
            Person person = new Person(1, "1");
            string name = "1";
            Database database = new Database(person);

            Assert.That(database.FindByUsername(name), Is.EqualTo(person));
        }

        [Test]
        public void Test_FindByUsername_Retturn_Correct_Format()
        {
            Person person = new Person(1, "1");
            string name = "1";
            Database database = new Database(person);
            Person testPerson = database.FindByUsername(name);

            Assert.That(testPerson, Is.AssignableFrom(typeof(Person)));
        }

        [Test]
        public void Test_FindById_With_Input_Incorrect_Data_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            int id = -1;
            Database database = new Database(person);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            });
        }

        [Test]
        public void Test_FindById_With_Non_Existing_Person_Throwing_Exception()
        {
            Person person = new Person(1, "1");
            int id = 2;
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(id);
            });
        }

        [Test]
        public void Test_FindById_With_Correct_Input()
        {
            Person person = new Person(1, "1");
            int id = 1;
            Database database = new Database(person);

            Assert.That(database.FindById(id), Is.EqualTo(person));
        }

        [Test]
        public void Test_FindById_Retturn_Correct_Format()
        {
            Person person = new Person(1, "1");
            int id = 1;
            Database database = new Database(person);
            Person testPerson = database.FindById(id);

            Assert.That(testPerson, Is.AssignableFrom(typeof(Person)));
        }
    }
}