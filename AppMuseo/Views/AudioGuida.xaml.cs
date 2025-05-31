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