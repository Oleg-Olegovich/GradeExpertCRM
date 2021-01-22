using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class SettingsViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> GoDetailsSettingsView { get; }

        private ILanguageProvider _localization;

        public new ILanguageProvider Localization
        {
            get => _localization;
            set => this.RaiseAndSetIfChanged(ref _localization, value);
        }

        public SettingsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            Localization = baseWindow.Localization;
            GoDetailsSettingsView = ReactiveCommand.CreateFromTask(OpenDetailsSettingsView);
        }

        private async Task OpenDetailsSettingsView() => BaseWindow.Content = new DetailsSettingsViewModel(BaseWindow);

        public void ChangeLanguage(string language) 
        { 
            BaseWindow.Language = language;
            Localization = BaseWindow.Localization;
        }
    }
}