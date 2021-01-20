using System.Collections.Generic;
using System.Collections.ObjectModel;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace GradeExpertCRM.ViewModels.Frames
{
    class ClientViewModel : ViewModelBase
    {
        public static ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();

        private async Task OpenAddingClientView() => BaseWindow.Content = new AddingClientViewModel(BaseWindow);

        public ReactiveCommand<Unit, Unit> GoAddingClientView { get; }

        public ClientViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingClientView = ReactiveCommand.CreateFromTask(OpenAddingClientView);
            // Clients = new ObservableCollection<Client>(GenerateClientsTable());
        }

        /// <summary>
        /// Temporary code.
        /// </summary>
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
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
                    },
                   new Client()
                    {
                        Name="Apple",
                        City="Воронеж",
                        PhoneNumber="00000000000"
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