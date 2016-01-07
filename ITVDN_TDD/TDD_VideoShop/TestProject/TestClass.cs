
using NUnit.Framework;
using System;
using TDD_VideoShop;
using Rhino.Mocks;
using System.IO;

namespace TestProject
{
    [TestFixture]
    public class TestClass
    {
        static double price;
        static int days;
        static Movie movie;
        static Movie movie1;

        [Test]
        public static void CreateMovie()
        {
            Rental rental = new Rental(movie, days: days);

            Assert.AreEqual(rental.CalculateDebt(), price * days);
        }

        [SetUp]
        public static void SetValues()
        {
            price = 2;
            days = 6;
            movie = new Movie("Giver", rentalPrice: price);
            movie1 = new Movie("Terminator", rentalPrice: price);
        }

        [TearDown]
        public static void DefaultValues()
        {
            price = 0;
            days = 0;
        }

        [Test]
        public static void CreateCustomer()
        {
            Customer customer = new Customer(name: "Nick");
            customer.Rental.Add(new Rental(movie,days));
            customer.Rental.Add(new Rental(movie, days));

            Assert.AreEqual(customer.CalculateTotal(), price * days + price * days);
        }

        [Test]
        public static void ExeptionDays()
        {            
            try
            {
                Rental rental = new Rental(movie, -2);
            }
            catch (DaysExeptions e)
            {
                Assert.AreEqual(e.Days, -2);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public static void RelationsTest()
        {
            MockRepository rhinoEngine = new MockRepository();
            var mockWriter = rhinoEngine.DynamicMock<TextWriter>();

            TextWriterFactory.SetTextWriter(mockWriter);

            using (rhinoEngine.Record())
            {
                mockWriter.Write("Nothing");
                LastCall.Constraints(new Rhino.Mocks.Constraints.Contains("TestCustomer") &
                                     new Rhino.Mocks.Constraints.Contains("TestMovie") &
                                     new Rhino.Mocks.Constraints.Contains("6 days") &
                                     new Rhino.Mocks.Constraints.Contains(12.ToString("C")));
                mockWriter.Flush();

            }

            Customer customer = new Customer("TestCustomer");
            customer.Rental.Add(new Rental(new Movie("TestMovie", 2), 6));

            ReportManager.CreateReport("SomePath", customer);

            rhinoEngine.VerifyAll();
        }
    }
}
