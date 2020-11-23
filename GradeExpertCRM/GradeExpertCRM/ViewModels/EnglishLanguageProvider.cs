using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    class EnglishLanguageProvider : ILanguageProvider
    {
        public string ButtonClient => "КЛИЕНТ";

        public string ButtonAddClient => "ДОБАВИТЬ НОВОГО КЛИЕНТА";

        public string ButtonCar => "АВТОМОБИЛЬ";

        public string ButtonCalculator => "КАЛЬКУЛЯЦИЯ";

        public string ButtonDocuments => "ДОКУМЕНТЫ";

        public string ButtonMail => "ПОЧТА";

        public string ButtonSave => "СОХРАНИТЬ";

        public string LabelAddingNewClient => "ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА";

        public string TextBoxIndex => "ИНДЕКС";

        public string TextBoxArea => "ОБЛАСТЬ, КРАЙ";

        public string TextBoxCity => "ГОРОД";

        public string TextBoxAddress => "УЛИЦА, ДОМ, КВ";

        public string TextBoxPhoneNumber => "ТЕЛЕФОН";

        public string TextBoxEmail => "E-MAIL";

        public string TextBoxTIN => "ИНН";

        public string TextBoxCRR => "КПП";

        public string TextBoxBank => "БАНК, АДРЕС БАНКА";

        public string TextBoxBIC => "БИК";

        public string TextBoxPaymentAccount => "РАСЧ/СЧЁТ";

        public string TextBoxCorrespondentAccount => "КОРР/СЧЁТ";
    }
}
