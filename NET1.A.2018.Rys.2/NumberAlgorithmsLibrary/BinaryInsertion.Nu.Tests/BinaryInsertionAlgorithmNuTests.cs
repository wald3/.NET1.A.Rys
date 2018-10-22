using System;
using System.Text;
using NUnit.Framework;
using NumberAlgorithmsLibrary;

namespace BinaryInsertion.Nu.Tests
{
    [TestFixture]
    public class BinaryInsertionAlgorithmNuTests
    {
        [TestCase(15, 8, 3, 8)]
        [TestCase(8, 15, 3, 8)]
        [TestCase(-1, 2, 3, 8)]
        [TestCase(15, -15, 31, 31)]
        [TestCase(99, 999, 15, 20)]
        [TestCase(15, 15, 0, 0)]
        public void BinaryInsertion_ValidInputs_ValidAnswer(int nIn, int nInsert, int start, int end)
        {
            var expected = StringBinaryInsertionCheck(nIn, nInsert, start, end);
            var actual = BinaryInsertAlgorithm.BinaryInsert(nIn, nInsert, start, end);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinaryInsertion_StartIsLessThanZero_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                BinaryInsertAlgorithm.BinaryInsert(15, 8, -1, 5));
        }

        [Test]
        public void BinaryInsertion_EndIsGraterThan31_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                BinaryInsertAlgorithm.BinaryInsert(15, 8, 0, 32));
        }

        [Test]
        public void BinaryInsertion_StartIsGraterThanEnd_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                BinaryInsertAlgorithm.BinaryInsert(15, 8, 0, 32));
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
