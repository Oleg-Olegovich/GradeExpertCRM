﻿using System.Collections.Generic;
using GradeExpertCRM.Models;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using System.Linq;
using GradeExpertCRM.Models.Data.Repositories;
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

        public ReactiveCommand<Unit, Unit> GoAddingDocumentView { get; }

        private IDocumentRepository documentRepository_;
        private ICarRepository carRepository_;
        public DocumentsViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            GoAddingDocumentView = ReactiveCommand.CreateFromTask(OpenAddingDocumentView);

            carRepository_ = Locator.Current.GetService<ICarRepository>();
            if (carRepository_.SelectedCarId == 0)
                return;

            documentRepository_ = Locator.Current.GetService<IDocumentRepository>();
            var documents = documentRepository_.Where(x=>x.CarId == carRepository_.SelectedCarId);
            _allDocuments = new ObservableCollection<Document>(documents);
            Documents = _allDocuments;
        }
    }
}