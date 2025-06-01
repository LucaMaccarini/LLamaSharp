using AppMuseo.Logic.Services;

namespace AppMuseo.Views
{
    public partial class StartPage : ContentPage
    {
        private readonly ILLamaCpp llm;

        const string modelName = "Llama-3.2-3B-Instruct-IQ4_XS.gguf";

        const string systemPrompt = """  
            You are Anna, a highly knowledgeable museum guide specializing in fine art. You are speaking to an audience of art historians and professionals, standing in front of a painting.

            You will receive a JSON input that contains detailed data about the painting. Do not use any external knowledge. Use only what is in the JSON. Do not mention the JSON format.

            Your explanation should use accurate terminology from art theory and criticism. Include technique, composition, historical context, and formal analysis. Assume a high level of cultural and artistic literacy in your audience.

            Begin directly with the first spoken sentence, as if Anna is already speaking. Do not introduce the style, tone, or purpose. Do not write any preface like “Audio guide” or “In a technical voice.” Just start speaking in character, immediately.

            Wait for the JSON input. Once received, begin immediately with the audio guide.
            """;

        public StartPage(ILLamaCpp llm)
        { 
            InitializeComponent();
            this.llm = llm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(300);

            if (Application.Current == null)
            {
                await DisplayAlert("Error", "Application.Current is null. Unable to proceed.", "OK");
                return;
            }

            if (!await downloadAIModel())
            {
                await DisplayAlert("Error", "Failed to download AI model. Please check your internet connection and try again.", "OK");
                return;
            }
            ActInd_PresenceOfAIModel.IsRunning = false;

            if (!llm.LoadModel(modelName))
            {
                await DisplayAlert("Error", "Failed to load AI model.", "OK");
                return;
            }
            ActInd_LoadedAIModel.IsRunning = false;

            llm.AddSystemMessage(systemPrompt);
            ActInd_SystemPromptLoaded.IsRunning = false;

            goToAppShell();
        }

        private void goToAppShell()
        {
            if (Application.Current != null)
            {
                Application.Current.MainPage = new FlyoutShell();
            }
        }

        private async Task<bool> downloadAIModel()
        {
            string appPackagePath = modelName;
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
