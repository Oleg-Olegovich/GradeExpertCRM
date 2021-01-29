using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using GradeExpertCRM.Models;
using GradeExpertCRM.Models.Data.Repositories;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using Splat;

namespace GradeExpertCRM.ViewModels.Frames
{
    class AddingClientViewModel : ViewModelBase
    {
        public Client Client { get; set; } = new Client();
        private IClientRepository clientRepository_;
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        public int ClientOrPartner
        {
            get => Client.IsPartner ? 1 : 0;
            set => Client.IsPartner = value == 1;
        }

        public AddingClientViewModel(IBaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
            SaveCommand = ReactiveCommand.CreateFromTask(SaveAsync);

            clientRepository_ = Locator.Current.GetService<IClientRepository>();
        }

        public async Task SaveAsync()
        {

            var validationContext = new ValidationContext(Client) { MemberName = nameof(Client) };
            var isValid = Validator.TryValidateObject(Client, validationContext, null);
            if (!isValid)
                return;

            await clientRepository_.AddAsync(Client);
            BaseWindow.Content = new ClientViewModel(BaseWindow);

            //try
            //{
            //    await repository_.AddAsync(Client);
            //    BaseWindow.Content = new ClientViewModel(BaseWindow);
            //}
            //catch
            //{
            //    await MessageBox.Avalonia.MessageBoxManager
            //        .GetMessageBoxStandardWindow(Localization.Error, Localization.IncorrectFillingInOfFields,
            //        ButtonEnum.Ok, Icon.Error, WindowStartupLocation.CenterScreen, Style.MacOs)
            //        .Show();
            //}
        }
    }
}