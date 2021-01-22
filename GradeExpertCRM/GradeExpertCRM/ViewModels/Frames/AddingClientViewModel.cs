using System.Reactive;
using GradeExpertCRM.Models;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingClientViewModel : ViewModelBase
    {
        public Client Client { get; set; } = new Client();
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        public AddingClientViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.Create(Save);
        }

        public void Save()
        {
            Client.Name = "User";
            BaseWindow.Content = new ClientViewModel(BaseWindow);
        }
    }
}