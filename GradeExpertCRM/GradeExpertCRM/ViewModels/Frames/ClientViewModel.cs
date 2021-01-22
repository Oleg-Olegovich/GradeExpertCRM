using System.Collections.Generic;
using System.Collections.ObjectModel;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using GradeExpertCRM.Models.Data.Repositories;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class ClientViewModel : ViewModelBase
    {
        public ObservableCollection<Client> Clients { get; }

        private async Task OpenAddingClientView() => BaseWindow.Content = new AddingClientViewModel(BaseWindow);

        public ReactiveCommand<Unit, Unit> GoAddingClientView { get; }

        private IRepository<Client> repository_;

        public ClientViewModel(IBaseWindow baseWindow, IRepository<Client> repository = null)
        {
            BaseWindow = baseWindow;
            GoAddingClientView = ReactiveCommand.CreateFromTask(OpenAddingClientView);

            repository_ = repository ?? Locator.Current.GetService<IRepository<Client>>();
            var clients = repository_.GetAll();
            Clients = new ObservableCollection<Client>(clients);
        }

        /// <summary>
        /// Temporary code.
        /// </summary>
        private static IEnumerable<Client> GenerateClientsTable()
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