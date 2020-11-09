using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class EnglishLanguageProvider : ILanguageProvider
    {
        public string ButtonClient { get => ""; }
        public string ButtonCar { get; }
        public string ButtonCalculator { get; }
        public string ButtonDocuments { get; }
        public string ButtonMail { get; }
    }
}
