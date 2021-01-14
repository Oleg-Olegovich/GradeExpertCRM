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
        private async Task OpenAddingDocumentView() => BaseWindow.Content = new AddingDocumentViewModel(BaseWindow, this);

        public ReactiveCommand<Unit, Unit> GoAddingDocumentView { get; }

        public DocumentsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingDocumentView = ReactiveCommand.CreateFromTask(OpenAddingDocumentView);
        }
    }
}