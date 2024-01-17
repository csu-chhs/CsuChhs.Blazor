using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CsuChhs.Blazor.Services
{
    [Obsolete("Please use PageTitle in core blazor instead", true)]
    public class ViewDataService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }
}
