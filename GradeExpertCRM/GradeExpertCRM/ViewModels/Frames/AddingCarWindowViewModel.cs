using System;
using System.Collections.Generic;
using System.Text;
using GradeExpertCRM.Views;
using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.Views.Frames;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingCarWindowViewModel : ViewModelBase
    {
        public static ILanguageProvider Localization
        {
            get => MainViewModel.Localization;
        }

    }
}