using AppMuseo.Logic.Services;

namespace AppMuseo.Views
{
    public partial class StartPage : ContentPage
    {
        private readonly ILLamaCpp llm;

        public StartPage(ILLamaCpp llm)
        { 
            InitializeComponent();
            this.llm = llm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!await downloadAIModel())
            {
                await DisplayAlert("Error", "Failed to download AI model. Please check your internet connection and try again.", "OK");
                return;
            }
            ActInd_PresenceOfAIModel.IsRunning = false;

            if (!llm.LoadModel("Llama-3.2-1B-Instruct-Q4_0.gguf"))
            {
                await DisplayAlert("Error", "Failed to load AI model. Please check the model file and try again.", "OK");
                return;
            }
            ActInd_LoadedAIModel.IsRunning = false;

            llm.AddSystemMessage("""
                You are Anna, an expert and passionate museum guide.

                You are having a conversation with a User who sends you a JSON file describing an artwork. Your task is to reply with a spoken-style, immersive monologue, as if you were guiding a visitor in a museum.

                Your reply must follow these rules:

                * Use only the data contained in the JSON.
                * Do not invent or infer any additional facts.
                * Start by stating the title of the work and the author.
                * Then, in a natural, flowing speech, describe the artistic style, technique, subject, and location.
                * Avoid using lists or bullet points.
                * Keep a warm, human, and engaging tone, as if you were speaking to a curious visitor standing in front of the artwork.
                
                """);
            ActInd_SystemPromptLoaded.IsRunning = false;

            goToAppShell();
        }

        private void goToAppShell()
        {
            var newShell = new FlyoutShell();
            var currentWindow = Application.Current?.Windows.Count > 0 ? Application.Current.Windows[0] : null;

            if (currentWindow != null)
            {
                currentWindow.Page = newShell;
            }
        }

        private async Task<bool> downloadAIModel()
        {
            string appPackagePath = "Llama-3.2-1B-Instruct-Q4_0.gguf";
            string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, appPackagePath);
            if (!File.Exists(modelPath))
            {
                using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(appPackagePath);
                using FileStream outputStream = File.Create(modelPath);
                await inputStream.CopyToAsync(outputStream);
                outputStream.Close();
                inputStream.Close();
            }
            return true;
        }

    }

}
