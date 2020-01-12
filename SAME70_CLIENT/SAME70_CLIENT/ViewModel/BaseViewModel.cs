using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAME70_CLIENT.ViewModel
{
    /*
     * Base class for ViewModel
     * ViewModel does the background work for View
     * 
     * <usage>
     * set a private and public variable in ViewModel:
     * public class MyViewModel() {
     *      private string _myString;
     *      public string MyString {
     *          get { return _myString; }
     *          set { SetValueAndRaisePropertyChanged(ref _myString, value); }
     *      }
     *      //Rest of class code...
     * }
     * 
     * bind public property to an object in View:
     * <TextBlock Text="{Binding MyString}"/>
     * 
     * TextBlock will now display the value of MyString and update when changed
     * </usage>
     */
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /* Changes value of property and tells View to update it */
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

        /* Tell View to update value */
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
