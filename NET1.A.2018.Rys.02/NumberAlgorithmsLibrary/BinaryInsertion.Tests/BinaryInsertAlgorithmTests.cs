using System;
using System.Text;
using NumberAlgorithmsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryInsertion.Tests
{
    [TestClass]
    public class BinaryInsertAlgorithmTests
    {
        [TestMethod]
        public void BinaryInsertion_StaticDataInsertion_IntWWithInsertedBits()
        {
            var expected = StringBinaryInsertionCheck(15, 8, 3, 8);
            var actual = BinaryInsertAlgorithm.BinaryInsert(15, 8, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryInsertion_EightAndFifteenWithThreeAndEightPositions_OneHundredTwenty()
        {
            const int expected = 120;
            var actual = BinaryInsertAlgorithm.BinaryInsert(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryInsertion_EightAndEightWithZeroAndZeroPositions_Eight()
        {
            const int expected = 8;
            var actual = BinaryInsertAlgorithm.BinaryInsert(8, 8, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryInsertion_StartIsLessThanZero_ArgumentOutOfRangeException()
        {
            BinaryInsertAlgorithm.BinaryInsert(10, 10, -1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryInsertion_EndIsGraterThanZero_ArgumentOutOfRangeException()
        {
            BinaryInsertAlgorithm.BinaryInsert(10, 10, 0, 32);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryInsertion_StartIsGraterThanEnd_ArgumentOutOfRangeException()
        {
            BinaryInsertAlgorithm.BinaryInsert(10, 10, 20, 10);
        }

        private static int StringBinaryInsertionCheck(int numSource, int numInsert, int start, int end)
        {
            if (start > end || start < 0 || end < 0)
            {
                throw new ArgumentOutOfRangeException($"{start} is grater than {end}");
            }

            StringBuilder source = new StringBuilder(32), insert = new StringBuilder(32);

            try
            {
                source.Append('0', 32 - Convert.ToString(numSource, 2).Length).Append(Convert.ToString(numSource, 2));
                insert.Append('0', 32 - Convert.ToString(numInsert, 2).Length).Append(Convert.ToString(numInsert, 2));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            for (var insertPos = 31 - end; insertPos < 32 - start; insertPos++)
            {
                source[insertPos] = insert[insertPos + start];
            }

            return Convert.ToInt32(source.ToString(), 2);
        }
    }
}
