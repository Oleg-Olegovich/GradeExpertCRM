using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class CarViewModel : ViewModelBase
    {
        public ObservableCollection<Car> Cars { get; }

        public static ILanguageProvider Localization
        {
            get => MainViewModel.Localization;
        }

        private async Task OpenAddingCarView() => BaseWindow.Content = new AddingCarViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingCarView { get; }

        public CarViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingCarView = ReactiveCommand.CreateFromTask(OpenAddingCarView);
            Cars = new ObservableCollection<Car>(GenerateCarsTable());
        }

        /// <summary>
        /// Temporary code.
        /// </summary>
        private IEnumerable<Car> GenerateCarsTable()
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