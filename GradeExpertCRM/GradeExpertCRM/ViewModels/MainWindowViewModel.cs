using System;

namespace GradeExpertCRM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string Language = "Russian";
        private ILanguageProvider[] LanguageProvider = new ILanguageProvider[] 
        {
            new RussianLanguageProvider(),
            new GermanLanguageProvider(),
            new EnglishLanguageProvider()
        };

        public ILanguageProvider Localization 
        {
            get => Language switch 
            {
                "Russian" => LanguageProvider[0],
                "German" => LanguageProvider[1],
                _ => LanguageProvider[2]
            }; 
        }
    }
}