﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeExpertCRM.Views;
using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.Views.Frames;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class MailWindowViewModel : ViewModelBase
    {
        public static ILanguageProvider Localization
        {
            get => MainWindowViewModel.Localization;
        }
    }
}