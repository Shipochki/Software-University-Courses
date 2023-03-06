namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private int minAtackHp = 30;

        private string name = "Ivan";
        private int damage = 30;
        private int hp = 31;

        [Test]
        public void Test_Setter_Property_Name_With_Null_Input_Throwing_Exception()
        {
            string testName = null;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(testName, this.damage, this.hp);
            });
        }

        [Test]
        public void Test_Setter_Property_Name_With_StringEmpty_Input_Throwing_Exception()
        {
            string testName = string.Empty;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(testName, this.damage, this.hp);
            });
        }

        [Test]
        public void Test_Setter_Property_Name_With_WhiteSpace_Input_Throwing_Exception()
        {
            string testName = " ";
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(testName, this.damage, this.hp);
            });
        }

        [Test]
        public void Test_Getter_Property_Name_Save_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.Name, Is.EqualTo(this.name));
        }

        [Test]
        public void Test_Getter_Property_Name_Retturns_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.Name, Is.AssignableFrom(typeof(string)));
        }

        [Test]
        public void Test_Setter_Property_Damage_With_Zero_Input_Throwing_Exception()
        {
            int testDamage = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(this.name, testDamage, this.hp);
            });
        }

        [Test]
        public void Test_Setter_Property_Damage_With_Negative_Input_Throwing_Exception()
        {
            int testDamage = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(this.name, testDamage, this.hp);
            });
        }

        [Test]
        public void Test_Getter_Property_Damage_Save_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.Damage, Is.EqualTo(this.damage));
        }

        [Test]
        public void Test_Getter_Property_Damage_Retturns_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.Damage, Is.AssignableFrom(typeof(int)));
        }

        [Test]
        public void Test_Setter_Property_Hp_With_Negative_Input_Throwing_Exception()
        {
            int testHp = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(this.name, this.damage, testHp);
            });
        }

        [Test]
        public void Test_Getter_Property_Hp_Save_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.HP, Is.EqualTo(this.hp));
        }

        [Test]
        public void Test_Getter_Property_Hp_Retturns_Correctly()
        {
            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.That(warrior.HP, Is.AssignableFrom(typeof(int)));
        }

        [Test]
        public void Test_Method_Attack_With_Lower_Hp_Than_MinAtackHp_Throwing_Exception()
        {
            int testHp = 29;
            Warrior warrior = new Warrior(this.name, this.damage, testHp);

            Warrior attackedWarrior = new Warrior(this.name, this.damage, this.hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            });
        }

        [Test]
        public void Test_Method_Attack_With_Equal_Hp_Than_MinAtackHp_Throwing_Exception()
        {
            int testHp = 30;
            Warrior warrior = new Warrior(this.name, this.damage, testHp);

            Warrior attackedWarrior = new Warrior(this.name, this.damage, this.hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            });
        }

        [Test]
        public void Test_Method_Attack_AttackedWarrior_With_Lower_Hp_Than_MinAtackHp_Throwing_Exception()
        {
            int testHp = 29;

            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Warrior attackedWarrior = new Warrior(this.name, this.damage, testHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            });
        }

        [Test]
        public void Test_Method_Attack_AttackedWarrior_With_Equal_Hp_Than_MinAtackHp_Throwing_Exception()
        {
            int testHp = 30;

            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Warrior attackedWarrior = new Warrior(this.name, this.damage, testHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            });
        }

        [Test]
        public void Test_Method_Attack_AttackedWarrior_With_Bigger_Damage_Than_BaseWarrior_Hp_Throwing_Exception()
        {
            int testDemage = 32;

            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Warrior attackedWarrior = new Warrior(this.name, testDemage, this.hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            });
        }

        public void Test_Method_Attack_With_Correct_Input()
        {
            int testDemage = 30;

            Warrior warrior = new Warrior(this.name, this.damage, this.hp);

            Warrior attackedWarrior = new Warrior(this.name, testDemage, this.hp);

            warrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }
    }
}