using NUnit.Framework;
using System;

namespace Codecool.EinsenhowerMatrix.Tests
{
    [TestFixture]
    public class TodoMatrixTests
    {
        [Test]
        public void TestAddingtasktoAQuaterIN()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(10), true);
            Assert.That(matrix.Quarters["IN"].Items.Count, Is.EqualTo(1));

        }
        [Test]
        public void TestAddingtasktoAQuaterIU()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(2), true);
            Assert.That(matrix.Quarters["IU"].Items.Count, Is.EqualTo(1));

        }
        [Test]
        public void TestAddingtasktoAQuaterNN()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(10));
            Assert.That(matrix.Quarters["NN"].Items.Count, Is.EqualTo(1));

        }
        [Test]
        public void TestAddingtasktoAQuaterNU()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(2));
            Assert.That(matrix.Quarters["NU"].Items.Count, Is.EqualTo(1));

        }
        [Test]
        public void TestRemoveTaskFromQuaterIN()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(10), true);
            matrix.Quarters["IN"].RemoveItem(0);
            Assert.That(matrix.Quarters["IN"].Items.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestRemoveTaskFromQuaterIU()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(2), true);
            matrix.Quarters["IU"].RemoveItem(0);
            Assert.That(matrix.Quarters["IU"].Items.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestRemoveTaskFromQuaterNN()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(10));
            matrix.Quarters["NN"].RemoveItem(0);
            Assert.That(matrix.Quarters["NN"].Items.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestRemoveTaskFromQuaterNU()
        {

            TodoMatrix matrix = new TodoMatrix();
            matrix.AddItem("Test Task", DateTime.Now.AddDays(2));
            matrix.Quarters["NU"].RemoveItem(0);
            Assert.That(matrix.Quarters["NU"].Items.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestRemoveItemHandlesErrors()
        {
            // Arrange
            TodoQuarter quarter = new TodoQuarter();

            Assert.DoesNotThrow(() => quarter.RemoveItem(0));
            Assert.DoesNotThrow(() => quarter.RemoveItem(-1));

        }


    }
}