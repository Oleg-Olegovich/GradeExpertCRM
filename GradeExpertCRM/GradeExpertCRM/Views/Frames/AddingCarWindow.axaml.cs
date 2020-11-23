using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GradeExpertCRM.Views.Frames
{
    public class AddingCarWindow : UserControl
    {
        public AddingCarWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
