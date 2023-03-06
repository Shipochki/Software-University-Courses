namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_Method_Enroll_With_Excistring_Warrior_Throwing_Exception()
        {
            Warrior warrior = new Warrior("1", 40, 40);
            Warrior secondWarrior = new Warrior("1", 40, 40);
            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(secondWarrior);
            });
        }

        [Test]
        public void Test_Method_Enroll_With_Non_Excistring_Warrior_Throwing_Exception()
        {
            Warrior warrior = new Warrior("1", 40, 40);
            Warrior secondWarrior = new Warrior("2", 40, 40);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);

            Assert.That(arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Method_Fight_With_Non_Exciting_AttackWarrior_Name_Throwing_Exception()
        {
            Warrior warrior = new Warrior("1", 40, 40);
            Warrior secondWarrior = new Warrior("2", 40, 40);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("3", "1");
            });
        }

        [Test]
        public void Test_Method_Fight_With_Non_Exciting_DefenderWarrior_Name_Throwing_Exception()
        {
            Warrior warrior = new Warrior("1", 40, 40);
            Warrior secondWarrior = new Warrior("2", 40, 40);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("1", "3");
            });
        }

        [Test]
        public void Test_Method_Fight_With_Correct_Input()
        {
            Warrior warrior = new Warrior("1", 40, 40);
            Warrior secondWarrior = new Warrior("2", 31, 40);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);
            arena.Fight("1", "2");

            Assert.That(secondWarrior.HP, Is.EqualTo(0));
        }
    }
}
