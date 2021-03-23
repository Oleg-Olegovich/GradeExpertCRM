using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using GradeExpertCRM.Models.Data.Repositories;
using iText.Kernel.Pdf;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    internal class DocumentsViewModel : ViewModelBase
    {
        private string _searchString;

        private ObservableCollection<Document> _allDocuments;

        private ObservableCollection<Document> _documents;

        public ObservableCollection<Document> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }

        public string SearchString
        {
            get => _searchString;
            set
            {
                this.RaiseAndSetIfChanged(ref _searchString, value);
                if (_allDocuments != null)
                {
                    var documents = _allDocuments.Where(client => client.Title.Contains(_searchString));
                    Documents = new ObservableCollection<Document>(documents);
                }
            }
        }

        private async Task OpenAddingDocumentView() => BaseWindow.Content = new AddingDocumentViewModel(BaseWindow, this);

        public bool IsButtonEnabled => carRepository_.SelectedCarId > 0 && detailsSettings_ != null;
        public ReactiveCommand<Unit, Unit> GoAddingDocumentView { get; }
        
        public ReactiveCommand<Document, Unit> DeleteCommand { get; }
        public ReactiveCommand<Document, Unit> PrintCommand { get; }
        public ReactiveCommand<Document, Unit> SendCommand { get; }

        private IDocumentRepository documentRepository_;
        private ICarRepository carRepository_;
        private DetailsSettings detailsSettings_;
        public DocumentsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingDocumentView = ReactiveCommand.CreateFromTask(OpenAddingDocumentView);
            DeleteCommand = ReactiveCommand.CreateFromTask<Document>(Delete);
            PrintCommand = ReactiveCommand.CreateFromTask<Document>(Print);
            SendCommand = ReactiveCommand.CreateFromTask<Document>(Send);

            carRepository_ = Locator.Current.GetService<ICarRepository>();
            detailsSettings_ = Locator.Current.GetService<IDetailsSettingsRepository>().FirstOrDefault();
            if (carRepository_.SelectedCarId == 0 || detailsSettings_ == null)
                return;

            documentRepository_ = Locator.Current.GetService<IDocumentRepository>();
            var documents = documentRepository_.Where(x=>x.CarId == carRepository_.SelectedCarId);
            _allDocuments = new ObservableCollection<Document>(documents);
            Documents = _allDocuments;
        }

        private async Task Delete(Document document)
        {
            Documents.Remove(document);
            await documentRepository_.RemoveAsync(document);
        }

        private async Task Print(Document document)
        {
            SaveFileDialog dialog = new SaveFileDialog() { InitialFileName = "Untitled",DefaultExtension = "pdf"};
            string path = await dialog.ShowAsync(new Window());
            
            if(path == null)
                return;
            
            MemoryStream memory = new MemoryStream(document.Content);
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(memory), new PdfWriter(path));
            pdfDoc.Close();
        }

        private async Task Send(Document document)
        {
            
        }
    }
}