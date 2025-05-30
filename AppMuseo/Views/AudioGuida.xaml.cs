using AppMuseo.Logic.Services;
using System.Diagnostics;

namespace AppMuseo.Views;

public partial class AudioGuida : ContentPage
{
    private readonly ILLamaCpp llm;
    private readonly ISchedaOperaDataProvider schedaOperaDataProvider;
    public AudioGuida(ILLamaCpp llm, ISchedaOperaDataProvider schedaOperaDataProvider)
    {
        InitializeComponent();
        this.llm = llm;
        this.schedaOperaDataProvider = schedaOperaDataProvider;
    }

    private void CaricaModello(object sender, EventArgs e)
    {
        llm.LoadModel("Llama-3.2-3B-Instruct-Q4_0.gguf");
        llm.AddAndProcessSystemMessage("Transcript of a dialog where the User sends a JSON about an artwork to Anna, an expert museum guide. Anna replies with a warm, immersive spoken-style description, using only the JSON data. She starts with title and author, then describes style, technique, subject, and location. No lists, no invented info.");
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

    private async void GeneraAudioGuida(object sender, EventArgs e)
    {
        if (llm is not null)
        {
            await foreach (
            var text
            in llm.ChatAsync(schedaOperaDataProvider.GetSchedaOperaData(lbl_text.Text)))
            {
                lbl_risp.Text += text;
                //Debug.Write(text);
            }
        }
    }


}