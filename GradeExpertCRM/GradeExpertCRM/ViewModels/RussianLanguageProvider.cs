using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class RussianLanguageProvider : ILanguageProvider
    {
        public string ButtonClient => "Клиент";

        public string ButtonAddClient => "Добавить нового клиента";

        public string ButtonCar => "Автомобиль";

        public string ButtonCalculator => "Калькуляция";

        public string ButtonDocuments => "Документы";

        public string ButtonMail => "Почта";

        public string ButtonSave => "Сохранить";

        public string LabelAddingNewClient => "Добавление нового клиента";

        public string TextBoxIndex => "Индекс";

        public string TextBoxArea => "Область, край";

        public string TextBoxCity => "";

        public string TextBoxAddress => "";

        public string TextBoxPhoneNumber => "";

        public string TextBoxEmail => "";

        public string TextBoxTIN => "";

        public string TextBoxCRR => "";

        public string TextBoxBank => "";

        public string TextBoxBIC => "";

        public string TextBoxPaymentAccount => "";

        public string TextBoxCorrespondentAccount => "";
    }
}
