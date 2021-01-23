using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Avalonia.Media.Imaging;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class CalculatorViewModel : ViewModelBase
    {
        private string _carImageName = "01-1";

        private const string ImagePath = @"..\..\..\Resources\Cars\2\";

        private Bitmap _carImage = new Bitmap(@"..\..\..\Resources\Cars\2\01-1.png");

        public Bitmap CarImage
        {
            get => _carImage;
            set => this.RaiseAndSetIfChanged(ref _carImage, value);
        }

        public Calculation Calculation { get; set; } = new Calculation();

        public string CarImageDescription
            => _carImageName switch
            {
                "01-1" => Localization.FrontLeftDoor,
                "02-1" => Localization.FrontRightDoor,
                "03-1" => Localization.RearRightDoor,
                "04-1" => Localization.RearLeftDoor,
                "05-1" => Localization.FrontLeftFender,
                "06-1" => Localization.FrontRightFender,
                "07-1" => Localization.LeftRack,
                "08-1" => Localization.RightRack,
                "09-1" => Localization.Roof,
                "10-1" => Localization.Hood,
                "11-1" => Localization.Trunk,
                "12-1" => Localization.RearLeftFender,
                "13-1" => Localization.RearRightFender,
                "14-1" => Localization.RearBumper,
                _ => "Error"
            };

        public ObservableCollection<DismantlingWork> DismantlingWorks { get; }
        public ObservableCollection<SparePart> SpareParts { get; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        private ICalculationRepository calculationRepository_;
        private Car selectedCar_;
        public CalculatorViewModel(IBaseWindow baseWindow, string carImageName, ICalculationRepository calculationRepository = null, IRepository<Car> carRepository = null)
        {
            BaseWindow = baseWindow;
            _carImageName = carImageName;
            Calculation.ComponentName = CarImageDescription;
            CarImage = new Bitmap($"{ImagePath}{carImageName}.png");
            SaveCommand = ReactiveCommand.CreateFromTask(Save);

            calculationRepository_ = calculationRepository ?? Locator.Current.GetService<ICalculationRepository>();
            var carRepository_ = carRepository ?? Locator.Current.GetService<IRepository<Car>>();
            selectedCar_ = carRepository_.FindById(calculationRepository_.SelectedCarId);

            //TODO change items of collections depending on Car's BodyType
            DismantlingWorks = new ObservableCollection<DismantlingWork>();
            SpareParts = new ObservableCollection<SparePart>();
        }

        public void SelectTypeOfRepair(string type)
        {
            Calculation.TypeOfRepair = Enum.Parse<TypeOfRepair>(type);
        }

        public async Task Save()
        {
            Calculation.CarId = selectedCar_.Id;
            await calculationRepository_.AddAsync(Calculation);
            BaseWindow.Content = new CalculationDataViewModel(BaseWindow);
        }

        public void Cancel()
        {
            BaseWindow.Content = new CalculationDataViewModel(BaseWindow);
        }
    }
}