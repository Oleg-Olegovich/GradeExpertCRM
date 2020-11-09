using System;

namespace GradeExpertCRM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Uri LogoImage => new Uri("Resources/logo.png", UriKind.Relative);
        public Uri GearsImage => new Uri("Resources/gears.png", UriKind.Relative);
    }
}