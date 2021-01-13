using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class DocumentsViewModel : ViewModelBase
    {
        public static ILanguageProvider Localization
        {
            get => MainViewModel.Localization;
        }

        private async Task OpenAddingDocumentView() => BaseWindow.Content = new AddingDocumentViewModel();

        public ReactiveCommand<Unit, Unit> GoAddingDocumentView { get; }

        public DocumentsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingDocumentView = ReactiveCommand.CreateFromTask(OpenAddingDocumentView);
        }
    }
}