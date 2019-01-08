using System;
using NUnit.Framework;
using QueueLibrary;

namespace QueueLibrary.Nu.Tests
{
    [TestFixture]
    public class QueueNuTests<T>
    {
        #region Private fields

        private QueueLibrary.Queue<T> _queue;

        #endregion


        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { "", "" })]
        [TestCase(new[] { 1.0, 2.0, 3.0 })]
        [TestCase(new[] { '1', '2', '3' })]

        public void CreateQueue(Array array)
        {
            _queue = new QueueLibrary.Queue<typeof()>();
        }

    }
}
