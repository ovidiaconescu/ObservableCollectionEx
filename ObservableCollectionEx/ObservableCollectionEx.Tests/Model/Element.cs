using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionEx.Tests.Model
{
    class Element : INotifyPropertyChanged 
    {
        public int Id { get; set; }

        string _value { get; set; }
        public string Value
        {
            get { return _value; }
            set { _value = value; onPropertyChanged(this, "Value"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
