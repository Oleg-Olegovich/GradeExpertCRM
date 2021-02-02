using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using MessageBox.Avalonia.Enums;
using Org.BouncyCastle.Crypto.Tls;
using ReactiveUI;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingCarViewModel : ViewModelBase
    {
        public Car Car { get; set; } = new Car();

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<string> InspectionPlaces { get; set; }
        public ObservableCollection<string> Inspectors { get; set; }
        public Client SelectedClient { get; set; } = new Client();

        public int BodyTypeIndex
        {
            get => (int) Car.BodyType;
            set => Car.BodyType = (BodyType)value;
        }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        private ICarRepository carRepository_;
        private IClientRepository clientRepository_;

        public AddingCarViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.CreateFromTask(Save);
            carRepository_ =  Locator.Current.GetService<ICarRepository>();
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

        public async Task Save()
        {
<<<<<<< HEAD
            var validationContext = new ValidationContext(Car) { MemberName = nameof(Car) };
            var isValid = Validator.TryValidateObject(Car, validationContext, null);
            if (!isValid || SelectedClient.Id == 0)
                return;

            Car.ClientId = SelectedClient.Id;
            await carRepository_.AddAsync(Car);
            BaseWindow.Content = new CarViewModel(BaseWindow);

            /*
=======
>>>>>>> c976383740f6d7f13ae5d437a87efe60b9897ba1
            try
            {
                var validationContext = new ValidationContext(Car) { MemberName = nameof(Car) };
                var isValid = Validator.TryValidateObject(Car, validationContext, null);
                if (!isValid)
                    return;
                Car.ClientId = SelectedClient.Id;
                await carRepository_.AddAsync(Car);
                BaseWindow.Content = new CarViewModel(BaseWindow);
            }
            catch
            {
                await MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow(Localization.Error, Localization.IncorrectFillingInOfFields,
                    ButtonEnum.Ok, Icon.Error, WindowStartupLocation.CenterScreen, Style.MacOs)
                    .Show();
            }
        }
    }
}