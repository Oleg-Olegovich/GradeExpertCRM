using System.Reactive;
using GradeExpertCRM.Models;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingCarViewModel : ViewModelBase
    {
        public Car Car { get; set; } = new Car();

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        public AddingCarViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.Create(Save);
        }

        public void Save()
        {
            CarViewModel.Cars.Add(Car);
            BaseWindow.Content = new CarViewModel(BaseWindow);
        }
    }
}