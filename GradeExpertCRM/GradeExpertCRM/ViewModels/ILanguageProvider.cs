using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.ViewModels
{
    public interface ILanguageProvider
    {
        string ButtonClient { get; }

        string ButtonAddClient { get; }

        string ButtonCar { get; }

        string ButtonCalculator { get; }

        string ButtonDocuments { get; }

        string ButtonMail { get; }

        string ButtonSave { get; }

        string LabelAddingNewClient { get; }

        string TextBoxIndex { get; }

        string TextBoxArea { get; }

        string TextBoxCity { get; }

        string TextBoxAddress { get; }

        string TextBoxPhoneNumber { get; }

        string TextBoxEmail { get; }

        string TextBoxTIN { get; }

        string TextBoxCRR { get; }

        string TextBoxBank { get; }

        string TextBoxBIC { get; }

        string TextBoxPaymentAccount { get; }

        string TextBoxCorrespondentAccount { get; }
    }
}
