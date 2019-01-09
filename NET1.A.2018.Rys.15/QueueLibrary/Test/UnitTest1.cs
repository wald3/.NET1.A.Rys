using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        #region Private fields

        private QueueLibrary.Queue<int> _queue;

        #endregion

        [Test]
        public void Test()
        {
            Assert.AreEqual(true, true);
        }

        [TestCase(new[] { 1, 2, 3 })]
        //[TestCase(new[] { "", "" })]
        //[TestCase(new[] { 1.0, 2.0, 3.0 })]
       // [TestCase(new[] { '1', '2', '3' })]

        public void CreateQueue(int[] actual)
        {
            _queue = new QueueLibrary.Queue<int>();

            foreach (var array_item in actual)
            {
                _queue.Enqueue(array_item);
            }

            List<int> expected = new List<int>();
            for (var i = 0; i < _queue.Count; i++)
            {
                expected.Add(_queue.Dequeue());
            }

            CollectionAssert.AreEqual(expected.ToArray(), actual);
        }
    }
}