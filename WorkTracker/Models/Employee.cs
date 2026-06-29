using System.ComponentModel;

namespace WorkTracker.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string status = "";
        private string statusColor = "";

        public string Name { get; set; } = "";

        public string ImagePath { get; set; } = "";

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string StatusColor
        {
            get => statusColor;
            set
            {
                statusColor = value;
                OnPropertyChanged(nameof(StatusColor));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}