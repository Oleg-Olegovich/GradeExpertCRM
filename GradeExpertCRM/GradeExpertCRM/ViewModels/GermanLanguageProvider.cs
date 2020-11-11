using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class GermanLanguageProvider : ILanguageProvider
    {
        public string ButtonClient { get => ""; }
        public string ButtonAddClient { get => ""; }
        public string ButtonCar { get; }
        public string ButtonCalculator { get; }
        public string ButtonDocuments { get; }
        public string ButtonMail { get; }
    }
}
