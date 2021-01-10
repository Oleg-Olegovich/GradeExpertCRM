using System;
using System.Collections.Generic;
using System.Text;
using GradeExpertCRM.Views;
using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.Views.Frames;
using Avalonia.Media.Imaging;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class CalculatorViewModel : ViewModelBase
    {
        private string _carImageName = "01-1";

        private Bitmap _carImage = new Bitmap(@"..\..\..\Resources\Cars\2\01-1.png");

        public Bitmap CarImage
        {
            get => _carImage;
            set => this.RaiseAndSetIfChanged(ref _carImage, value);
        }

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

        public static ILanguageProvider Localization => MainViewModel.Localization;
    }
}