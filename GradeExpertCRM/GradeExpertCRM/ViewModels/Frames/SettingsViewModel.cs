namespace GradeExpertCRM.ViewModels.Frames
{
    class SettingsViewModel : ViewModelBase
    {
        public void ChangeLanguageToRussian() => MainViewModel.Language = "Russian";

        public void ChangeLanguageToGerman() => MainViewModel.Language = "German";

        public void ChangeLanguageToEnglish() => MainViewModel.Language = "English";
    }
}