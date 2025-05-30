namespace AppMuseo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            string appPackagePath = "Llama-3.2-3B-Instruct-Q4_0.gguf";
            string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, appPackagePath);
            if (!File.Exists(modelPath))
            {
                using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(appPackagePath);
                using FileStream outputStream = File.Create(modelPath);
                await inputStream.CopyToAsync(outputStream);
                outputStream.Close();
                inputStream.Close();
            }
        }
    }
}
