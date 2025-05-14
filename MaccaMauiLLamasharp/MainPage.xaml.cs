using System.Diagnostics;
using LLama;
using LLama.Common;
using LLama.Native;
using LLama.Sampling;

namespace MaccaMauiLLamasharp;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	async void OnButtonClicked(object sender, EventArgs e)
	{

		string[] fileNames = { "Llama-3.2-1B-Instruct-Q4_0.gguf" };

		foreach (var fileName in fileNames)
		{
			string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);


			using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
			using FileStream outputStream = File.Create(targetFile);
			await inputStream.CopyToAsync(outputStream);

			outputStream.Close();
			inputStream.Close();
			
		}

		string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, fileNames[0]);

		var parameters = new ModelParams(modelPath)
		{
			ContextSize = 1024, // The longest length of chat as memory.
			GpuLayerCount = 5 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
		};
		using var model = LLamaWeights.LoadFromFile(parameters);
		using var context = model.CreateContext(parameters);
		var executor = new InteractiveExecutor(context);

		// Add chat histories as prompt to tell AI how to act.
		var chatHistory = new ChatHistory();
		chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");
		chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
		chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

		ChatSession session = new(executor, chatHistory);
		InferenceParams inferenceParams = new InferenceParams()
		{
			MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
			AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
			SamplingPipeline = new DefaultSamplingPipeline(),
		};


		string userInput = tx_input.Text;

		Debug.WriteLine($"answer:");

		await foreach ( // Generate the response streamingly.
	   var text
	   in session.ChatAsync(
		   new ChatHistory.Message(AuthorRole.User, userInput),
		   inferenceParams))
		{
			lbl.Text += text;
			Debug.Write(text);
		}


	}
}

