using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using ReactiveUI;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingCarViewModel : ViewModelBase
    {
        public Car Car { get; set; } = new Car();

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient { get; set; } = new Client();
        private IRepository<Car> carRepository_;
        private IRepository<Client> clientRepository_;

        public AddingCarViewModel(IBaseWindow baseWindow, IRepository<Car> carRepository = null, IRepository<Client> clientRepository = null)
        {
            BaseWindow = baseWindow;
            // SaveCommand = ReactiveCommand.CreateFromTask(Save);
            SaveCommand = ReactiveCommand.CreateFromTask(Save);
            carRepository_ = carRepository ?? Locator.Current.GetService<IRepository<Car>>();
            clientRepository_ = clientRepository ?? Locator.Current.GetService<IRepository<Client>>();
            var clients = clientRepository_.GetAll();
            Clients = new ObservableCollection<Client>(clients);
        }

        public async Task Save()
        {
            Car.ClientId = SelectedClient.Id;
            await carRepository_.AddAsync(Car);
            BaseWindow.Content = new CarViewModel(BaseWindow);
        }
    }
}