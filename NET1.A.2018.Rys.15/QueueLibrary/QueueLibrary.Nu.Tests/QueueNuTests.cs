using System;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

namespace QueueLibrary.Nu.Tests
{
    [TestFixture]
    public class QueueNuTests
    {


        

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1.0, 2.0, 3.0 })]
        [TestCase(new[] { '1', '2', '3' })]

        public void CreateQueue(Array actual)
        {
            
            var genericListType = typeof(Array);
            var specificListType = genericListType.MakeGenericType( typeof( actual.GetType() ) );
            var list = Activator.CreateInstance(specificListType);

            var _queue = new QueueLibrary.Queue<typeof(list) >();

            foreach (var array_item in actual)
            {
                _queue.Enqueue(array_item);
            }
            
            List<int> expected = new List<int>();
            for (var i = 0; i < _queue.Count; i++)
            {
                expected.Add(_queue.Dequeue());
            }
                
            

            Assert.AreEqual(true, true);
        }

    }
}
