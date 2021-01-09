using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace GradeExpertCRM.ViewModels.Frames
{
    class ClientViewModel : ViewModelBase
    {
        public static ILanguageProvider Localization
        {
            get => MainViewModel.Localization;
        }

        private async Task OpenAddingClientWindow() => BaseWindow.Content = new AddingClientWindowViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingClientWindow { get; }

        public ClientViewModel()
        {
            GoAddingClientWindow = ReactiveCommand.CreateFromTask(OpenAddingClientWindow);
        }
    }
}