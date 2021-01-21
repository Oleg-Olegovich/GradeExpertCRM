using System;
using ReactiveUI;
using Avalonia.Media.Imaging;
using GradeExpertCRM.Models;

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

        public CalculatorViewModel(IBaseWindow baseWindow, string carImageName)
        {
            _carImageName = carImageName;
            CarImage = new Bitmap($"{ImagePath}{carImageName}.png");
            BaseWindow = baseWindow;
        }

        public void SelectTypeOfRepair(string type)
        {
            Calculation.TypeOfRepair = Enum.Parse<TypeOfRepair>(type);
        }

        public void Cancel()
        {
            BaseWindow.Content = new CalculationDataViewModel(BaseWindow);
        }
    }
}