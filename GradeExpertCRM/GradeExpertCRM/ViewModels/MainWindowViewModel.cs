using GradeExpertCRM.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace GradeExpertCRM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IBaseWindow
    {
        public string Language { get; set; }

        /// <summary>
        /// Reference to the changing content of the app window.
        /// </summary>
        private ViewModelBase _content;

        public ViewModelBase Content
        {
            get => _content;
            set
            {
                value.BaseWindow = this;
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }

        /// <summary>
        /// The constructor initializes Content properties.
        /// </summary>
        public MainWindowViewModel()
        {
            //Content = new SignInViewModel();
           Content = new MainViewModel();
        }
    }
}