using System;
using System.Windows;
using System.Windows.Threading;
using SAME70_CLIENT.Model;
using SAME70_CLIENT.ViewModel;

namespace SAME70_CLIENT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Same70Model same70Model;
        Same70ViewModel same70ViewModel;
        DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Closing += MainWindow_Closing;

            //Instantiate Model, ViewModel, and set data context
            same70Model = new Same70Model();
            same70ViewModel = new Same70ViewModel(same70Model);
            this.DataContext = same70ViewModel;

            //Set a timer to update GUI every 250 ms
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Tick += UpdateDispatcherTimer;
            dispatcherTimer.Start();
        }

        /* Execute this code on every tick of dispatcherTimer */
        private void UpdateDispatcherTimer(object sender, EventArgs e)
        {
            same70ViewModel.Update();
        }

        /* Clean shutdown */
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            same70Model.StopUdpListener();
            dispatcherTimer.Stop();
        }
    }
}
