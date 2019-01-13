using NUnit.Framework;
using System.Collections.Generic;

namespace QueueLibrary.Nu.Tests
{
    [TestFixture]
    public class QueueNuTests
    {
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        public void QueueEnqueAndDequeue_EnqueueSomeInts_DequeueThemIntoList(int[] actual)
        {
            var _queue = new Queue<int>();

            foreach (var item in actual)
            {
                _queue.Enqueue(item);
            }

            List<int> expected = new List<int>();
            var qLength = _queue.Count;

            for (var i = 0; i < qLength; i++)
            {
                expected.Add(_queue.Dequeue());
            }

            Assert.AreEqual(expected.ToArray(), actual);
        }

    }


}
