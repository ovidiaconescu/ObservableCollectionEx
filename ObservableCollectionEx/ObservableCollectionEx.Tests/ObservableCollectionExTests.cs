using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableCollectionEx.Tests.Model;

namespace ObservableCollectionEx.Tests
{
    [TestClass]
    public class ObservableCollectionExTests
    {
        ObservableCollectionEx.ObservableCollectionEx<Element> col;

        [TestInitialize]
        public void CreateTheObservableCollectionForTracking()
        {
            col = new ObservableCollectionEx<Element>();
            col.Add(new Element() { Id = 0, Value = "elem 0" });
        }

        [TestMethod]
        public void ValuePropertyChangedEventIsRaised_WhenTheValueChanges()
        {
            List<string> receivedEvents = new List<string>();
            ((INotifyPropertyChanged)col).PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            col[0].Value = "new elem 0";
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("Value", receivedEvents[0]);
        }

        [TestMethod]
        public void ValuePropertyChangedEventRaised1000Times_CheckConsistencyOfEvents()
        {
            int count = 1000;
            List<string> receivedEvents = new List<string>();
            ((INotifyPropertyChanged)col).PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            for (int i = 0; i < count; i++)
                col[0].Value = string.Format("elem {0}", i);

            Assert.AreEqual(count, receivedEvents.Count);
        }
    }
}
