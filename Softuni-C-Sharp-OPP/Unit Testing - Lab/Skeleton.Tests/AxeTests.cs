using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints = 10;
        private int durabilityPoints = 10;
        private int brokenDurabilityAxePoints = 0;
        private int health = 10;
        private int experience = 10;
        Axe axe;
        Axe brokenAxe;
        Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(attackPoints, durabilityPoints);
            this.brokenAxe = new Axe(attackPoints, brokenDurabilityAxePoints);
            this.dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_Axe_Looses_Durability_After_Attack()
        {
            this.axe.Attack(this.dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(durabilityPoints - 1), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_Axe_Attacking_With_Broken_Axe()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.brokenAxe.Attack(dummy);
            });
        }
    }
}