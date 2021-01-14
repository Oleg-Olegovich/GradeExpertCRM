using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingDocumentViewModel : ViewModelBase
    {
        private DocumentsViewModel Parent;

        private async Task OpenDocumentView() => BaseWindow.Content = Parent;

        public ReactiveCommand<Unit, Unit> GoDocumentView { get; }

        public AddingDocumentViewModel(IBaseWindow baseWindow, DocumentsViewModel parent)
        {
            BaseWindow = baseWindow;
            Parent = parent;
            GoDocumentView = ReactiveCommand.CreateFromTask(OpenDocumentView);
        }
    }
}