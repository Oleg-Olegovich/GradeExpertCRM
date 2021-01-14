using ReactiveUI;

namespace GradeExpertCRM.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        /// <summary>
        /// Reference to the base window of the 
        /// application where the controls are located.
        /// </summary>
        public IBaseWindow BaseWindow;

        public ILanguageProvider Localization => MainViewModel.Localization;
    }
}
