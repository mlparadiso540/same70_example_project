using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAME70_CLIENT.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SetValueAndRaisePropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property != null)
            {
                if (property.Equals(value))
                {
                    //only update if value is different
                    return;
                }
            }

            property = value;
            RaisePropertyChanged(propertyName);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
