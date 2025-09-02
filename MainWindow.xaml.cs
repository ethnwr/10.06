using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace GasStationApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _timeDateString;
        public string TimeDateString
        {
            get { return _timeDateString; }
            set
            {
                _timeDateString = value;
                OnPropertyChanged("TimeDateString");
            }
        }

        private string _currentDayOfWeek;
        public string CurrentDayOfWeek
        {
            get { return _currentDayOfWeek; }
            set
            {
                _currentDayOfWeek = value;
                OnPropertyChanged("CurrentDayOfWeek");
            }
        }

        private DispatcherTimer _timer;

        public MainViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            Timer_Tick(null, null); // Initial update
            CurrentDayOfWeek = DateTime.Now.ToString("dddd");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                TimeDateString = DateTime.Now.ToLongTimeString();
            }
            else
            {
                TimeDateString = DateTime.Now.ToShortDateString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
