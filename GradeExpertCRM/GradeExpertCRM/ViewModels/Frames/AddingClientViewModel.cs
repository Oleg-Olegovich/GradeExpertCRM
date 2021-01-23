using System.Reactive;
using System.Threading.Tasks;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using ReactiveUI;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingClientViewModel : ViewModelBase
    {
        public Client Client { get; set; } = new Client();
        private IRepository<Client> repository_;
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public AddingClientViewModel(IBaseWindow baseWindow, IRepository<Client> repository = null)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.CreateFromTask(SaveAsync);

            repository_ = repository ?? Locator.Current.GetService<IRepository<Client>>();
        }

        public async Task SaveAsync()
        {
            await repository_.AddAsync(Client);
            BaseWindow.Content = new ClientViewModel(BaseWindow);
        }
    }
}