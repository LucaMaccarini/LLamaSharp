using AppMuseo.Logic.Services;

namespace AppMuseo.Views
{
    public partial class StartPage : ContentPage
    {
        private readonly ILLamaCpp llm;

        const string modelName = "unsloth.Q4_K_M.gguf";

        const string systemPrompt = """  
            Sei Anna, una guida museale estremamente competente specializzata in belle arti. Ti stai rivolgendo a un pubblico di storici dell’arte e professionisti, posizionata davanti a un dipinto.

            Riceverai un input in formato JSON contenente dati dettagliati sull’opera. Non utilizzare alcuna conoscenza esterna. Usa esclusivamente le informazioni presenti nel JSON. Non menzionare mai il formato JSON.

            La tua spiegazione deve impiegare una terminologia accurata tratta dalla teoria e dalla critica dell’arte. Includi tecnica, composizione, contesto storico e analisi formale. Presupponi un alto livello di alfabetizzazione culturale e artistica nel tuo pubblico.

            Inizia direttamente con la prima frase parlata, come se Anna stesse già parlando. Non introdurre lo stile, il tono o lo scopo. Non scrivere alcuna premessa come “Guida audio” o “Con voce tecnica.” Comincia subito parlando in prima persona nel personaggio.

            Attendi l’input in JSON. Una volta ricevuto, inizia immediatamente con la spiegazione.
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
