using System;
using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Avalonia.Controls;
using GradeExpertCRM.Models.Data.Repositories;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using itext.pdfimage.Extensions;
using MessageBox.Avalonia.Enums;
using Splat;
using Icon = MessageBox.Avalonia.Enums.Icon;
using Image = System.Drawing.Image;

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

        private async Task OpenAddingDocumentView() =>
            BaseWindow.Content = new AddingDocumentViewModel(BaseWindow, this);

        public bool IsButtonEnabled => carRepository_.SelectedCarId > 0 && detailsSettings_ != null;
        public ReactiveCommand<Unit, Unit> GoAddingDocumentView { get; }

        public ReactiveCommand<Document, Unit> SaveCommand { get; }
        public ReactiveCommand<Document, Unit> PrintCommand { get; }
        public ReactiveCommand<Document, Unit> SendCommand { get; }
        public ReactiveCommand<Document, Unit> DeleteCommand { get; }

        private IDocumentRepository documentRepository_;
        private ICarRepository carRepository_;
        private DetailsSettings detailsSettings_;

        public DocumentsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingDocumentView = ReactiveCommand.CreateFromTask(OpenAddingDocumentView);
            SaveCommand = ReactiveCommand.CreateFromTask<Document>(Save);
            PrintCommand = ReactiveCommand.CreateFromTask<Document>(Print);
            SendCommand = ReactiveCommand.CreateFromTask<Document>(Send);
            DeleteCommand = ReactiveCommand.CreateFromTask<Document>(Delete);

            carRepository_ = Locator.Current.GetService<ICarRepository>();
            detailsSettings_ = Locator.Current.GetService<IDetailsSettingsRepository>().FirstOrDefault();
            if (carRepository_.SelectedCarId == 0 || detailsSettings_ == null)
                return;

            documentRepository_ = Locator.Current.GetService<IDocumentRepository>();
            var documents = documentRepository_.Where(x => x.CarId == carRepository_.SelectedCarId);
            _allDocuments = new ObservableCollection<Document>(documents);
            Documents = _allDocuments;
        }

        private async Task Save(Document document)
        {
            SaveFileDialog dialog = new SaveFileDialog() {InitialFileName = "Untitled", DefaultExtension = "pdf"};
            string path = await dialog.ShowAsync(new Window());

            if (path == null)
                return;

            MemoryStream memory = new MemoryStream(document.Content);
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(memory), new PdfWriter(path));
            pdfDoc.Close();
        }

        private PdfDocument pdfDocument_;

        private async Task Print(Document document)
        {
            MemoryStream memory = new MemoryStream(document.Content);
            pdfDocument_ = new PdfDocument(new PdfReader(memory));
            
            currentPage_ = 1;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage +=  pd_PrintPage;
            pd.Print();
        }

        private int currentPage_ = 1;
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int numberOfPages = pdfDocument_.GetNumberOfPages();

            Bitmap bitmap = pdfDocument_.GetPage(currentPage_).ConvertPageToBitmap();
            ev.Graphics.DrawImage(bitmap, new Point(0, 0));

            currentPage_++;
            ev.HasMorePages = currentPage_ <= numberOfPages;
        }

        private async Task Send(Document document)
        {
            var uri =
                "mailto:username@domainname?subject=SubjectText&body=BodyText&file:C:/Users/Admin/Desktop/demo.pdf";
            var psi = new ProcessStartInfo {UseShellExecute = true, FileName = uri};

            try
            {
                Process.Start(psi);
            }
            catch (Win32Exception)
            {
                string text = "Не найдено приложение по умолчаню для почты";
                await MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow(Localization.Error, text,
                        ButtonEnum.Ok, Icon.Error, WindowStartupLocation.CenterScreen, Style.MacOs)
                    .Show();
            }
        }

        private async Task Delete(Document document)
        {
            Documents.Remove(document);
            await documentRepository_.RemoveAsync(document);
        }
    }
}