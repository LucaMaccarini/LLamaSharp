using AppMuseo.Views;

namespace AppMuseo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AudioGuida), typeof(AudioGuida));            
        }
    }
}
