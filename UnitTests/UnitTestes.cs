using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAssignmentApp;

namespace UnitTests
{
    [TestClass]
    public class UnitTestes
    {
        [TestMethod]
        public void CountLuckyNumbers_Correct()
        {
            ulong expected = 9203637295151;
            ulong actual = Program.CountLuckyNumbers();
            Assert.AreEqual(expected, actual, "Answer is not correct.");
        }

        [TestMethod]
        public void CountCombinationsFor_2_2()
        {
            int expected = 3;
            int actual = Program.CountCombinationsFor(2, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountCombinationsFor_0_2()
        {
            int expected = 1;
            int actual = Program.CountCombinationsFor(0, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountCombinationsFor_84_7()
        {
            int expected = 1;
            int actual = Program.CountCombinationsFor(84, 7);
            Assert.AreEqual(expected, actual);
        }
    }
}