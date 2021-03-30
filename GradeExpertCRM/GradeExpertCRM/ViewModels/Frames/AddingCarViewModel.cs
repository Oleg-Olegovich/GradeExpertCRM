using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public int BodyTypeIndex
        {
            get => (int) Car.BodyType;
            set
            {
                Car.BodyType = (BodyType) value;
                this.RaisePropertyChanged(nameof(BodyTypeIndex));
            }
        }
        
        public Car Car { get; set; } = new Car();

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<string> InspectionPlaces { get; set; }
        public ObservableCollection<string> Inspectors { get; set; }
        public Client SelectedClient { get; set; } = new Client();

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        private ICarRepository carRepository_;
        private IClientRepository clientRepository_;

        public AddingCarViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.CreateFromTask(Save);
            carRepository_ = Locator.Current.GetService<ICarRepository>();
            clientRepository_ = Locator.Current.GetService<IClientRepository>();
            var clients = clientRepository_.All().ToList();
            Clients = new ObservableCollection<Client>(clients);

            var partners = (from client in clients
                where client.IsPartner
                select client).ToList();

            var inspectionPlaces = from partner in partners
                select new string($"{partner.Area} {partner.City} {partner.Address}");

            InspectionPlaces = new ObservableCollection<string>(inspectionPlaces);

            var inspectors = from partner in partners
                select partner.Name;
            Inspectors = new ObservableCollection<string>(inspectors);
        }

        public AddingCarViewModel(IBaseWindow baseWindow, Car car) : this(baseWindow)
        {
            Car = car;
            SelectedClient = Car.Client;
        }

        public async Task Save()
        {
            var validationContext = new ValidationContext(Car) {MemberName = nameof(Car)};
            var isValid = Validator.TryValidateObject(Car, validationContext, null);
            if (!isValid || SelectedClient.Id == 0)
                return;

            Car.ClientId = SelectedClient.Id;
            await carRepository_.UpdateAsync(Car);
            BaseWindow.Content = new CarViewModel(BaseWindow);
        }
    }
}