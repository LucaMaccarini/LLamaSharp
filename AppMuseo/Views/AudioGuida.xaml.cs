using AppMuseo.Logic;

namespace AppMuseo.Views;

public partial class AudioGuida : ContentPage
{
    private readonly ILLamaCpp llm;
    public AudioGuida(ILLamaCpp llm)
    {
        InitializeComponent();
        this.llm = llm;
    }

    //public AudioGuida(ITest test)
    //{
    //    InitializeComponent();
    //    this.llm = new LLamaCpp("Llama-3.2-1B-Instruct-Q4_0.gguf", 1024, 5);
    //    lbl_log.Text = test.a();
    //}

    //void CaricaModello(object sender, EventArgs e)
    //{
    //    lbl_log.Text = "...";
    //    llm = new LLamaCpp("Llama-3.2-1B-Instruct-Q4_0.gguf", 1024, 5);
    //    lbl_log.Text = "Modello caricato con successo!";
    //}

    private async void EstraiModello(object sender, EventArgs e)
    {
        lbl_log.Text = "...";
        string[] fileNames = { "Llama-3.2-1B-Instruct-Q4_0.gguf" };

        foreach (var fileName in fileNames)
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

            if (!File.Exists(targetFile))
            {
                using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
                using FileStream outputStream = File.Create(targetFile);
                await inputStream.CopyToAsync(outputStream);
                outputStream.Close();
                inputStream.Close();
            }
        }

        lbl_log.Text = "Modello estratto con successo!";
    }

    private async void ScriviAlModello(object sender, EventArgs e)
    {
        if (llm is not null) {
            await foreach (
            var text
            in llm.ChatAsync(lbl_text.Text))
            {
                lbl_risp.Text += text;
            }
        }
    }
}