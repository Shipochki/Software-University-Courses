using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int attackPoints = 5;
        private int durabilityPoints = 10;
        private int health = 10;
        private int experience = 10;
        private int DeadHealth = -1;
        Axe axe;
        Dummy dummy;
        Dummy deadDummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(attackPoints, durabilityPoints);
            this.dummy = new Dummy(health, experience);
            this.deadDummy = new Dummy(DeadHealth, experience);
        }

        [Test]
        public void Test_Dummy_Loses_Health_After_Attacked()
        {
            this.dummy.TakeAttack(this.attackPoints);

            Assert.That(this.dummy.Health, Is.EqualTo(health - this.attackPoints), "Dummy Health doesn't change after take attack.");
        }

        [Test]
        public void Test_DeadDummy_Is_Throwing_Message_After_Dead()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.deadDummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DeadDummy_Can_Give_XP()
        {
            var dummyXp = deadDummy.GiveExperience();

            Assert.That(dummyXp, Is.EqualTo(experience));
        }

        [Test]
        public void Test_Alive_Dummy_Cant_Give_XP()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dummy.GiveExperience();
            });
        }

        [Test]
        public void Test_DeadDummy_Is_Dead()
        {
            Assert.That(this.deadDummy.IsDead(), Is.True, "Dummy has to be dead");
        }
    }
}