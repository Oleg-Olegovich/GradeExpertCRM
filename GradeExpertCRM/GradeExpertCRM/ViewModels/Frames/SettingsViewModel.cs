using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Threading.Tasks;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using ReactiveUI;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class SettingsViewModel : ViewModelBase
    {
        public Settings Settings { get; set; }

        public ReactiveCommand<Unit, Unit> GoDetailsSettingsView { get; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        private ILanguageProvider _localization;

        public new ILanguageProvider Localization
        {
            get => _localization;
            set => this.RaiseAndSetIfChanged(ref _localization, value);
        }

<<<<<<< HEAD
        private readonly ISettingsRepository settingsRepository_;
=======
        private readonly IRepository<Settings> settingsRepository_;

        private bool _isVatEnabled = false;

        public bool IsVatEnabled 
        {
            get => _isVatEnabled;
            set
            {
                if (!value)
                {
                    Settings.TaxPercent = null;
                }
                this.RaiseAndSetIfChanged(ref _isVatEnabled, value);
            }
        }

>>>>>>> c976383740f6d7f13ae5d437a87efe60b9897ba1
        public SettingsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            Localization = baseWindow.Localization;

            settingsRepository_ = Locator.Current.GetService<ISettingsRepository>();
            Settings = settingsRepository_.FirstOrDefault() ?? new Settings();

            GoDetailsSettingsView = ReactiveCommand.CreateFromTask(OpenDetailsSettingsView);
            SaveCommand = ReactiveCommand.CreateFromTask(Save);
        }

        private async Task OpenDetailsSettingsView() 
            => BaseWindow.Content = new DetailsSettingsViewModel(BaseWindow);

        public void ChangeLanguage(string language)
        {
            Settings.Language = language;
            BaseWindow.Language = language;
            Localization = BaseWindow.Localization;
        }

        public async Task Save()
        {
            var validationContext = new ValidationContext(Settings) { MemberName = nameof(Settings) };
            var isValid = Validator.TryValidateObject(Settings, validationContext, null);
            if (!isValid)
                return;

            await settingsRepository_.UpdateAsync(Settings);
        }
    }
}