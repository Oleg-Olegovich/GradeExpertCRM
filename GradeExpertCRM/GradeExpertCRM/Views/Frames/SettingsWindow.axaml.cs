using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GradeExpertCRM.Views.Frames
{
    public class SettingsWindow : UserControl
    {
        public SettingsWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
