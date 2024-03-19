using JurDocs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace JurDocs.ViewModel
{
    internal class MainViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        //public ICommand BtnDogovors { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand aaa1;
        public ICommand ClickSpravki => aaa1 ??= new RelayCommand(Performaaa);

        private void Performaaa(object commandParameter)
        {
        }

        private RelayCommand btnDogovors;
        public ICommand BtnDogovors => btnDogovors ??= new RelayCommand((a) => { });

        private void PerformBtnDogovors(object commandParameter)
        {
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private object docList1;

        public object docList { get => docList1; set => SetProperty(ref docList1, value); }
    }
}
