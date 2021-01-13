using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
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

        private async Task OpenAddingClientView() => BaseWindow.Content = new AddingClientViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingClientView { get; }

        public ClientViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingClientView = ReactiveCommand.CreateFromTask(OpenAddingClientView);
            Clients = new ObservableCollection<Client>(GenerateClientsTable());
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
                    }
                };
    }
}