using System.IO;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using RazorLight;
using ReactiveUI;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingDocumentViewModel : ViewModelBase
    {
        private DocumentsViewModel Parent;

        private async Task OpenDocumentView() => BaseWindow.Content = Parent;

        public ReactiveCommand<Unit, Unit> GoDocumentView { get; }

        public ReactiveCommand<Unit, Unit> SavePdfCommand { get; }

        public AddingDocumentViewModel(IBaseWindow baseWindow, DocumentsViewModel parent)
        {
            BaseWindow = baseWindow;
            Parent = parent;
            GoDocumentView = ReactiveCommand.CreateFromTask(OpenDocumentView);

            SavePdfCommand = ReactiveCommand.CreateFromTask(SavePdf);

        }

        private async Task SavePdf()
        {

            string input = "GradeExpertCRM.Resources.Templates.template1";

            string output = @"C:\Users\Admin\Desktop\template1.pdf";


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter { Name = "PDF", Extensions = { "pdf" } });
            var result = await dialog.ShowAsync(new Window());

            if (result != null)
            {
                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(System.Reflection.Assembly.GetEntryAssembly())
                    .UseMemoryCachingProvider()
                    .Build();

                string html = await engine.CompileRenderAsync<object>(input, null);

                PdfWriter writer = new PdfWriter(result);
                PdfDocument pdfDoc = new PdfDocument(writer);

                pdfDoc.SetDefaultPageSize(new PageSize(1000, 1415));

                ConverterProperties converterProperties = new ConverterProperties();

                converterProperties.SetFontProvider(new DefaultFontProvider(true, true, true));

                HtmlConverter.ConvertToPdf(html, pdfDoc, converterProperties);

                pdfDoc.Close();
                writer.Close();
            }
        }
    }
}