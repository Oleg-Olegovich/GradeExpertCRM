using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.ViewModels.Frames;
using System.Reactive;
using GradeExpertCRM.Models;

namespace GradeExpertCRM.ViewModels
{
    class MainViewModel : ViewModelBase, IBaseWindow
    {
        public static string Language = "Russian";

        private ViewModelBase _content;

        private static ILanguageProvider[] LanguageProvider = new ILanguageProvider[]
        {
            new RussianLanguageProvider(),
            new GermanLanguageProvider(),
            new EnglishLanguageProvider()
        };

        public new static ILanguageProvider Localization 
            => Language switch
            {
                "Russian" => LanguageProvider[0],
                "German" => LanguageProvider[1],
                _ => LanguageProvider[2]
            };

        public ViewModelBase Content
        {
            get => _content;
            set
            {
                _content = this;
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }

        private async Task OpenClientWindow() => Content = new ClientViewModel(this);

        private async Task OpenCarView() => Content = new CarViewModel(this);

        private async Task OpenCalculatorView() => Content = new CalculationDataViewModel(this);

        private async Task OpenDocumentsView() => Content = new DocumentsViewModel(this);

        private async Task OpenMailView() => Content = new MailViewModel();

        private async Task OpenSettingsView() => Content = new SettingsViewModel(this);


        public ReactiveCommand<Unit, Unit> GoClientWindow { get; }

        public ReactiveCommand<Unit, Unit> GoCarView { get; }

        public ReactiveCommand<Unit, Unit> GoCalculatorView { get; }

        public ReactiveCommand<Unit, Unit> GoDocumentsView { get; }

        public ReactiveCommand<Unit, Unit> GoMailView { get; }

        public ReactiveCommand<Unit, Unit> GoSettingsView { get; }

        public MainViewModel()
        {
            GoClientWindow = ReactiveCommand.CreateFromTask(OpenClientWindow);
            GoCarView = ReactiveCommand.CreateFromTask(OpenCarView);
            GoCalculatorView = ReactiveCommand.CreateFromTask(OpenCalculatorView);
            GoDocumentsView = ReactiveCommand.CreateFromTask(OpenDocumentsView);
            GoMailView = ReactiveCommand.CreateFromTask(OpenMailView);
            GoSettingsView = ReactiveCommand.CreateFromTask(OpenSettingsView);
            Content = new ClientViewModel(this);
        }
    }
}