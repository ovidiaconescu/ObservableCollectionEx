using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ObservableCollectionEx
{
    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
    {
        public object Sender { get; private set; }

        public PropertyChangedEventArgsEx(string propertyName, object sender)
            : base(propertyName)
        {
            this.Sender = sender;
        }
    }
}
