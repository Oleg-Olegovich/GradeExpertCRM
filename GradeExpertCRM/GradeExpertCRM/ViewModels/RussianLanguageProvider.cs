using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class RussianLanguageProvider : ILanguageProvider
    {
        public string ButtonClient { get => "Клиент"; }
        public string ButtonCar { get => "Автомобиль"; }
        public string ButtonCalculator { get => "Калькуляция"; }
        public string ButtonDocuments { get => "Документы"; }
        public string ButtonMail { get => "Почта"; }
    }
}
