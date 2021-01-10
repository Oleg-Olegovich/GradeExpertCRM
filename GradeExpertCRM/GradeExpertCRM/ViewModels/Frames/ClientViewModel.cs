using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using GradeExpertCRM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GradeExpertCRM.ViewModels.Frames
{
    class ClientViewModel : ViewModelBase
    {
        public ObservableCollection<Client> Clients { get; }

        public static ILanguageProvider Localization
        {
            get => MainViewModel.Localization;
        }

        private async Task OpenAddingClientWindow() => BaseWindow.Content = new AddingClientWindowViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingClientWindow { get; }

        public ClientViewModel()
        {
            GoAddingClientWindow = ReactiveCommand.CreateFromTask(OpenAddingClientWindow);
            Clients = new ObservableCollection<Client>(GenerateClientsTable());
        }

        private IEnumerable<Client> GenerateClientsTable()
            => new List<Client>()
                {
                    new Client()
                    {
                        Name="Иванов Иван Иванович",
                        City="Иваново",
                        PhoneNumber="88005553535"
                    },
                    new Client()
                    {
                        Name="Хер Элбан",
                        City="Лондон",
                        PhoneNumber="+79999999999"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    }
                };
    }
}