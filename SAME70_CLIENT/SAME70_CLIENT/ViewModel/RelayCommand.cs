using System;
using System.Windows.Input;

namespace SAME70_CLIENT.ViewModel
{
    /*
     * RelayCommand defines an action to take when something happens in a View
     * 
     * <usage>
     * bind RelayCommand to an object in View:
     * <Button Command="{Binding myCommand}"/>
     * 
     * define RelayCommand in ViewModel:
     * public ICommand myCommand { get; set; }
     * 
     * public myViewModel() {
     * //constructor code here
     *  myCommand = new RelayCommand(o=> myFunction());
     * }
     * 
     * public void myFunction { //do something here }
     * 
     * myFunction() will execute when Button is pressed
     * </usage>
     */
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }   

        public void Execute(object parameter)
        {
            _execute(parameter ?? "<N/A>");
        }
    }
}
