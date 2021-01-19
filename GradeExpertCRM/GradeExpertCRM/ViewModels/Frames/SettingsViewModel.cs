using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class SettingsViewModel : ViewModelBase
    {
        public void ChangeLanguageToRussian() => MainViewModel.Language = "Russian";

        public void ChangeLanguageToGerman() => MainViewModel.Language = "German";

        public void ChangeLanguageToEnglish() => MainViewModel.Language = "English";

        private async Task OpenDetailsSettingsView() => BaseWindow.Content = new DetailsSettingsViewModel();

        public ReactiveCommand<Unit, Unit> GoDetailsSettingsView { get; }

        public SettingsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoDetailsSettingsView = ReactiveCommand.CreateFromTask(OpenDetailsSettingsView);
        }
    }
}