namespace AppMuseo.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(5000);

            var newShell = new FlyoutShell();
            var currentWindow = Application.Current?.Windows.Count > 0 ? Application.Current.Windows[0] : null;

            if (currentWindow != null)
            {
                currentWindow.Page = newShell;
            }
        }
    }

}
