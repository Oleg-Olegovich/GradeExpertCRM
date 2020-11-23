using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class GermanLanguageProvider : ILanguageProvider
    {
        public string ButtonClient => "Клиент";

        public string ButtonAddClient => "Добавить нового клиента";

        public string ButtonCar => "Автомобиль";

        public string ButtonCalculator => "Калькуляция";

        public string ButtonDocuments => "Документы";

        public string ButtonMail => "Почта";

        public string ButtonSave => "Сохранить";
    }
}
