using System.Collections.ObjectModel;
using System.Reactive;
using GradeExpertCRM.Models;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingClientViewModel : ViewModelBase
    {
        public Client Client { get; set; } = new Client();
        private ObservableCollection<Client> Clients { get; }
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        public AddingClientViewModel(IBaseWindow baseWindow, ObservableCollection<Client> clients)
        {
            BaseWindow = baseWindow;
            Clients = clients;

            SaveCommand = ReactiveCommand.Create(Save);
        }

        public void Save()
        {
            Client.Name = "User";
            Clients.Add(Client);
            BaseWindow.Content = new ClientViewModel(BaseWindow, Clients);
        }
    }
}