﻿using System.Threading.Tasks;
using ReactiveUI;
using GradeExpertCRM.ViewModels.Frames;
using System.Reactive;

namespace GradeExpertCRM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private static string Language = "Russian";

        private ViewModelBase _content;

        private static ILanguageProvider[] LanguageProvider = new ILanguageProvider[]
        {
            new RussianLanguageProvider(),
            new GermanLanguageProvider(),
            new EnglishLanguageProvider()
        };

        public static ILanguageProvider Localization
        {
            get => Language switch
            {
                "Russian" => LanguageProvider[0],
                "German" => LanguageProvider[1],
                _ => LanguageProvider[2]
            };
        }

        public ViewModelBase Content
        {
            get => _content;
            set
            {
                _content = this;
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }

        private async Task OpenClientWindow() => Content = new ClientViewModel();

        private async Task OpenCarWindow() => Content = new CarWindowViewModel();

        private async Task OpenCalculatorWindow() => Content = new CalculatorWindowViewModel();

        private async Task OpenDocumentsWindow() => Content = new DocumentsWindowViewModel();

        private async Task OpenMailWindow() => Content = new MailWindowViewModel();

        private async Task OpenSettingsWindow() => Content = new SettingsWindowViewModel();


        public ReactiveCommand<Unit, Unit> GoClientWindow { get; }

        public ReactiveCommand<Unit, Unit> GoCarWindow { get; }

        public ReactiveCommand<Unit, Unit> GoCalculatorWindow { get; }

        public ReactiveCommand<Unit, Unit> GoDocumentsWindow { get; }

        public ReactiveCommand<Unit, Unit> GoMailWindow { get; }

        public ReactiveCommand<Unit, Unit> GoSettingsWindow { get; }


        public MainViewModel()
        {
            GoClientWindow = ReactiveCommand.CreateFromTask(OpenClientWindow);
            GoCarWindow = ReactiveCommand.CreateFromTask(OpenCarWindow);
            GoCalculatorWindow = ReactiveCommand.CreateFromTask(OpenCalculatorWindow);
            GoDocumentsWindow = ReactiveCommand.CreateFromTask(OpenDocumentsWindow);
            GoMailWindow = ReactiveCommand.CreateFromTask(OpenMailWindow);
            GoSettingsWindow = ReactiveCommand.CreateFromTask(OpenSettingsWindow);
            Content = new ClientViewModel();
        }
    }
}