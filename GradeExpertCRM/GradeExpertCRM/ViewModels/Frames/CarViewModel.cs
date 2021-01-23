using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using GradeExpertCRM.Models.Data.Repositories;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class CarViewModel : ViewModelBase
    {
        public ObservableCollection<Car> Cars { get; }

        private async Task OpenAddingCarView() => BaseWindow.Content = new AddingCarViewModel(BaseWindow);

        public ReactiveCommand<Unit, Unit> GoAddingCarView { get; }

        private IRepository<Car> carRepository_;
        private ICalculationRepository calculationRepository_;

        public Car SelectedCarId
        {
            set => calculationRepository_.SelectedCarId = value.Id;
        }

        public CarViewModel(IBaseWindow baseWindow, IRepository<Car> carRepository = null, ICalculationRepository calculationRepository = null)
        {
            BaseWindow = baseWindow;
            GoAddingCarView = ReactiveCommand.CreateFromTask(OpenAddingCarView);
            carRepository_ = carRepository ?? Locator.Current.GetService<IRepository<Car>>();
            calculationRepository_ = calculationRepository ?? Locator.Current.GetService<ICalculationRepository>();
            var cars = carRepository_.GetAll();
            Cars = new ObservableCollection<Car>(cars);
        }

        /// <summary>
        /// Temporary code.
        /// </summary>
        private static IEnumerable<Car> GenerateCarsTable()
            => new List<Car>()
                {
                    new Car()
                    {
                        Brand="Лада седан",
                        Number="555",
                        Loss="керкеркеркер",
                        VIN="рекциектицкет",
                    },
                    new Car()
                    {
                        Brand="Баклажан",
                        Number="555",
                        Loss="керкеркеркер",
                        VIN="рекциектицкет",
                    },
                };
    }
}