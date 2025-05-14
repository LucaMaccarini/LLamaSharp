using System.Diagnostics;
using LLama;
using LLama.Common;
using LLama.Native;
using LLama.Sampling;

namespace MaccaMauiLLamasharp;

public partial class MainPage : ContentPage
{
	ChatSession? session = null;

	InferenceParams inferenceParams = new InferenceParams()
	{
		MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
		AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
		SamplingPipeline = new DefaultSamplingPipeline(),
	};


	public MainPage()
	{
		InitializeComponent();

		string appDataDirectory = FileSystem.Current.AppDataDirectory;
		IEnumerable<string> allFiles = Directory.EnumerateFiles(appDataDirectory, "*", SearchOption.AllDirectories);

		foreach (string file in allFiles)
		{
			Debug.WriteLine(file);
		}

	}

	async void OnButtonClicked(object sender, EventArgs e)
	{
		if (session == null)
		{
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


			string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, fileNames[0]);

			var parameters = new ModelParams(modelPath)
			{
				ContextSize = 1024, // The longest length of chat as memory.
				GpuLayerCount = 5 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
			};
			var model = LLamaWeights.LoadFromFile(parameters);
			var context = model.CreateContext(parameters);
			var executor = new InteractiveExecutor(context);

			// Add chat histories as prompt to tell AI how to act.
			var chatHistory = new ChatHistory();
			chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");
			chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
			chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

			session = new(executor, chatHistory);

		}

		await foreach (
		var text
		in session.ChatAsync(
			new ChatHistory.Message(AuthorRole.User, tx_input.Text),
			inferenceParams))
		{
			lbl.Text += text;
			Debug.Write(text);
		}

	}
}
