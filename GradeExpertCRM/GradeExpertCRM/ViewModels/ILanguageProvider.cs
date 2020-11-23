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
    }
}
