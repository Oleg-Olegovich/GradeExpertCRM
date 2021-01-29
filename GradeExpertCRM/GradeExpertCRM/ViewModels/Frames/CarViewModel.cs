using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using GradeExpertCRM.Models.Data.Repositories;
using Splat;
using System.Linq;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class CarViewModel : ViewModelBase
    {
        private string _searchString;

        private ObservableCollection<Car> _allCars;

        private ObservableCollection<Car> _cars;

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => this.RaiseAndSetIfChanged(ref _cars, value);
        }

        public string SearchString
        {
            get => _searchString;
            set
            {
                this.RaiseAndSetIfChanged(ref _searchString, value);
                if (_allCars != null)
                {
                    var cars = _allCars.Where(car => car.Model.Contains(_searchString));
                    Cars = new ObservableCollection<Car>(cars);
                }
            }
        }

        private async Task OpenAddingCarView() => BaseWindow.Content = new AddingCarViewModel(BaseWindow);

        public ReactiveCommand<Unit, Unit> GoAddingCarView { get; }

        private IRepository<Car> carRepository_;
        private ICalculationRepository calculationRepository_;
        public Car SelectedCarId
        {
            set
            {
                if (value != null)
                    calculationRepository_.SelectedCarId = value.Id;
            }
        }

        public CarViewModel(IBaseWindow baseWindow, IRepository<Car> carRepository = null, ICalculationRepository calculationRepository = null)
        {
            BaseWindow = baseWindow;
            GoAddingCarView = ReactiveCommand.CreateFromTask(OpenAddingCarView);
            carRepository_ = carRepository ?? Locator.Current.GetService<IRepository<Car>>();
            calculationRepository_ = calculationRepository ?? Locator.Current.GetService<ICalculationRepository>();
            var cars = carRepository_.GetAll();
            _allCars = new ObservableCollection<Car>(cars);
            Cars = _allCars;
        }
    }
}