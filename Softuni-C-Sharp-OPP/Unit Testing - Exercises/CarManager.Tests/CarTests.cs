namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarTests
    {
        private string make = "VW";
        private string model = "Golf 4";
        private double fuelConsumption = 1;
        private double fuelAmount = 0;
        private double fuelCapacity = 2;

        [Test]
        public void Test_Setter_Propperty_Make_With_Null_Thorwing_Exception()
        {
            string testMake = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(testMake, this.model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_Make_With_EmptyString_Thorwing_Exception()
        {
            string testMake = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(testMake, this.model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_Make_With_Correct_Input()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(this.make));
        }

        [Test]
        public void Test_Getter_Propperty_Make_Returning_Correct_Format()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.Make, Is.AssignableFrom(typeof(string)));
        }

        [Test]
        public void Test_Setter_Propperty_Model_With_Null_Thorwing_Exception()
        {
            string testModel = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, testModel, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_Model_With_EmptyString_Thorwing_Exception()
        {
            string testModel = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, testModel, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_Model_With_Correct_Input()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.Model, Is.EqualTo(this.model));
        }

        [Test]
        public void Test_Getter_Propperty_Model_Returning_Correct_Format()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.Model, Is.AssignableFrom(typeof(string)));
        }

        [Test]
        public void Test_Setter_Propperty_FuelConsumption_With_Zero_Throwing_Exception()
        {
            int testConsumption = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, testConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_FuelConsumption_With_Negative_Throwing_Exception()
        {
            int testConsumption = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, testConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_FuelConsumption_With_Correct_Input()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.FuelConsumption, Is.EqualTo(this.fuelConsumption));
        }

        [Test]
        public void Test_Getter_Propperty_FuelConsumption_Returning_Correct_Format()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.FuelConsumption, Is.AssignableFrom(typeof(double)));
        }

        [Test]
        public void Test_Setter_Propperty_FuelCapacity_With_Zero_Throwing_Exception()
        {
            int testCapacity = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, this.fuelConsumption, testCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_FuelCapacity_With_Negative_Throwing_Exception()
        {
            int testCapacity = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, this.fuelConsumption, testCapacity);
            });
        }

        [Test]
        public void Test_Setter_Propperty_FuelCapacity_With_Correct_Input()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.FuelCapacity, Is.EqualTo(this.fuelCapacity));
        }

        [Test]
        public void Test_Getter_Propperty_FuelCapacity_Returning_Correct_Format()
        {

            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.FuelCapacity, Is.AssignableFrom(typeof(double)));
        }

        [Test]
        public void Test_Refuel_With_Zero_Input_Throwing_Exception()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(testRefuel);
            });
        }

        [Test]
        public void Test_Refuel_With_Negative_Input_Throwing_Exception()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(testRefuel);
            });
        }

        [Test]
        public void Test_Refuel_With_Correct_Input()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = 1;
            car.Refuel(testRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(testRefuel));
        }

        [Test]
        public void Test_Drive_With_Bigger_Input_Throwing_Exception()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = 1;
            car.Refuel(testRefuel);
            double testDistance = 110;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(testDistance);
            });
        }

        [Test]
        public void Test_Drive_With_Negativ_Input_Throwing_Exception()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Test_Drive_With_Correct_Input_Throwing_Exception()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = 2;
            car.Refuel(testRefuel);
            double testDistance = 100;
            car.Drive(testDistance);

            Assert.That(car.FuelAmount, Is.EqualTo(1));
        }

        [Test]
        public void Test_Getter_Property_FuelAmount_Returning_Correct_Format()
        {
            Car car = new Car(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
            double testRefuel = 1;
            car.Refuel(testRefuel);

            Assert.That(car.FuelAmount, Is.AssignableFrom(typeof(double)));
        }
    }
}