using System;
using System.Collections.Generic;
using System.Text;
using GradeExpertCRM.Views;
using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.Views.Frames;
using System.Reactive;

namespace GradeExpertCRM.ViewModels.Frames
{
    class ClientWindowViewModel : ViewModelBase
    {
        public static ILanguageProvider Localization
        {
            get => MainWindowViewModel.Localization;
        }

        private async Task OpenAddingClientWindow() => MainWindowViewModel.Instance.Content = new AddingClientWindowViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingClientWindow { get; }

        public ClientWindowViewModel()
        {
            GoAddingClientWindow = ReactiveCommand.CreateFromTask(OpenAddingClientWindow);
        }
    }
}