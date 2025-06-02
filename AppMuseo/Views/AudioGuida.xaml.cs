using AppMuseo.Logic.Services;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

    private async void ScriviAlModello(object sender, EventArgs e)
    {
        if (llm is not null) {
            await foreach (
            var text
            in llm.ChatAsync(tx_text.Text))
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
            in llm.ChatAsync(schedaOperaDataProvider.GetSchedaOperaData(tx_text.Text)))
            {
                lbl_risp.Text += text;
                //Debug.Write(text);
            }
        }
    }

    private async void Leggi(object sender, EventArgs e)
    {
        //var locales = await TextToSpeech.Default.GetLocalesAsync();

        var settings = new SpeechOptions()
        {
            Volume = 1.0f,
            Pitch = 0f
        };

        await TextToSpeech.Default.SpeakAsync(lbl_risp.Text, settings);
    }

    private async void Pulisci(object sender, EventArgs e)
    {
        lbl_risp.Text = String.Empty;
    }

}