using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using RazorLight;
using ReactiveUI;
using SelectPdf;

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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter { Name = "PDF", Extensions = { "pdf" } });
            var result = await dialog.ShowAsync(new Window());

            if (result != null)
            {
                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(System.Reflection.Assembly.GetEntryAssembly())
                    .UseMemoryCachingProvider()
                    .Build();

                string html = await engine.CompileRenderAsync<object>("GradeExpertCRM.Resources.Templates.Template1", null);

                HtmlToPdf converter = new HtmlToPdf();

                int margin = 40;
                converter.Options.MarginLeft = margin;
                converter.Options.MarginTop = margin / 2;
                converter.Options.MarginRight = margin;
                converter.Options.MarginBottom = margin;

                PdfDocument doc = converter.ConvertHtmlString(html);

                doc.Save(result);
                doc.Close();
            }
        }
    }
}