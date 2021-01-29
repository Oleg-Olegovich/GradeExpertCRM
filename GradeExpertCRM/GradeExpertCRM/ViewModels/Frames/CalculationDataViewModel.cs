using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Avalonia.Controls.Primitives;
using ReactiveUI;
using Avalonia.Media.Imaging;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using GradeExpertCRM.ViewModels.Frames;
using Microsoft.AspNetCore.Mvc.Formatters;
using Splat;
using System.Linq;
using System.Reactive;
using Org.BouncyCastle.Utilities.Collections;

namespace GradeExpertCRM.ViewModels.Frames
{
    class CalculationDataViewModel : ViewModelBase
    {
        private int LeftIndex = 0;

        private string[] _carImageNames = { "01-1", "02-1", "03-1", "04-1", "05-1",
                                            "06-1", "07-1", "08-1", "09-1", "10-1",
                                            "11-1", "12-1", "13-1", "14-1"};

        private Bitmap[] _carImages = { new Bitmap(@"..\..\..\Resources\Cars\2\01-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\02-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\03-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\04-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\05-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\06-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\07-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\08-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\09-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\10-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\11-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\12-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\13-1.png"),
                                        new Bitmap(@"..\..\..\Resources\Cars\2\14-1.png") };

        private Bitmap[] _carImagesInInterface = { new Bitmap(@"..\..\..\Resources\Cars\2\01-1.png"),
                                                   new Bitmap(@"..\..\..\Resources\Cars\2\02-1.png"),
                                                   new Bitmap(@"..\..\..\Resources\Cars\2\03-1.png"),
                                                   new Bitmap(@"..\..\..\Resources\Cars\2\04-1.png") };

        private string[] _carImagesDescriprions = { "", "", "", "" };

        public Bitmap CarImage0
        {
            get => _carImagesInInterface[0];
            set => this.RaiseAndSetIfChanged(ref _carImagesInInterface[0], value);
        }

        public Bitmap CarImage1
        {
            get => _carImagesInInterface[1];
            set => this.RaiseAndSetIfChanged(ref _carImagesInInterface[1], value);
        }

        public Bitmap CarImage2
        {
            get => _carImagesInInterface[2];
            set => this.RaiseAndSetIfChanged(ref _carImagesInInterface[2], value);
        }

        public Bitmap CarImage3
        {
            get => _carImagesInInterface[3];
            set => this.RaiseAndSetIfChanged(ref _carImagesInInterface[3], value);
        }

        public string CarImageDescription0
        {
            get => _carImagesDescriprions[0];
            set => this.RaiseAndSetIfChanged(ref _carImagesDescriprions[0], value);
        }

        public string CarImageDescription1
        {
            get => _carImagesDescriprions[1];
            set => this.RaiseAndSetIfChanged(ref _carImagesDescriprions[1], value);
        }

        public string CarImageDescription2
        {
            get => _carImagesDescriprions[2];
            set => this.RaiseAndSetIfChanged(ref _carImagesDescriprions[2], value);
        }

        public string CarImageDescription3
        {
            get => _carImagesDescriprions[3];
            set => this.RaiseAndSetIfChanged(ref _carImagesDescriprions[3], value);
        }

        public bool IsButtonEnabled => calculationRepository_.SelectedCarId > 0;
        public ReactiveCommand<Calculation, Unit> DeleteCommand { get; }

        public ObservableCollection<Calculation> Calculations { get; }

        private ICalculationRepository calculationRepository_;
        private ICarRepository carRepository_;

        public CalculationDataViewModel(IBaseWindow baseWindow, ICalculationRepository calculationRepository = null, ICarRepository carRepository = null)
        {
            BaseWindow = baseWindow;
            UpdateImagesAndDescriptions();

            DeleteCommand = ReactiveCommand.Create<Calculation>(Delete);

            calculationRepository_ = calculationRepository ?? Locator.Current.GetService<ICalculationRepository>();
            carRepository_ = carRepository ?? Locator.Current.GetService<ICarRepository>();

            var selectedCarId = calculationRepository_.SelectedCarId;
            var calculations = carRepository_.GetCalculationsByCarId(selectedCarId);

            Calculations = calculations != null ? new ObservableCollection<Calculation>(calculations) 
                                                : new ObservableCollection<Calculation>();
        }

        public void Delete(Calculation calculation)
        {
            Calculations.Remove(calculation);
            calculationRepository_.Remove(calculation);
        }

        public void ScrollLeft()
        {
            LeftIndex = (LeftIndex + _carImages.Length - 1) % _carImages.Length;
            UpdateImagesAndDescriptions();
        }

        public void ScrollRight()
        {
            LeftIndex = (LeftIndex + 1) % _carImages.Length;
            UpdateImagesAndDescriptions();
        }

        public void SelectDetail(string imageNumber)
        {
            string carImageName = imageNumber switch
            {
                "image0" => _carImageNames[LeftIndex],
                "image1" => _carImageNames[(LeftIndex + 1) % _carImages.Length],
                "image2" => _carImageNames[(LeftIndex + 2) % _carImages.Length],
                "image3" => _carImageNames[(LeftIndex + 3) % _carImages.Length],
                _ => ""
            };

            BaseWindow.Content = new CalculatorViewModel(BaseWindow, carImageName);
        }

        private void UpdateImagesAndDescriptions()
        {
            CarImage0 = _carImages[LeftIndex];
            CarImage1 = _carImages[(LeftIndex + 1) % _carImages.Length];
            CarImage2 = _carImages[(LeftIndex + 2) % _carImages.Length];
            CarImage3 = _carImages[(LeftIndex + 3) % _carImages.Length];
            CarImageDescription0 = GetCarImageDescription(LeftIndex);
            CarImageDescription1 = GetCarImageDescription((LeftIndex + 1) % _carImages.Length);
            CarImageDescription2 = GetCarImageDescription((LeftIndex + 2) % _carImages.Length);
            CarImageDescription3 = GetCarImageDescription((LeftIndex + 3) % _carImages.Length);
        }

        private string GetCarImageDescription(int index)
            => _carImageNames[index] switch
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
    }
}
