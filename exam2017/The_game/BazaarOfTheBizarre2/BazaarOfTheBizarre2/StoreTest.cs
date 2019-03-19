using NUnit.Framework;
using System;

namespace BazaarOfTheBizarre2
{
    [TestFixture]
    public class StoreTest
    {
        
        
           [Test]
        public void TestIfStoreIsDifferent()
        {
            var store1 = new Store("RunningStore");
            var store2 = new Store("jalalaBad");
            Assert.IsFalse(store1 == store2);
        }

        [Test]
        public void TestStoreIsRunning()
        {
            var store = new Store("Expert");
            Assert.True(store.IsRunning == true);
        }

        [Test]
        public void TestIfNameIsEmpty()
        {
            var store = new Store("");
            Assert.IsEmpty(store.StoreName);
        }

    }

}


