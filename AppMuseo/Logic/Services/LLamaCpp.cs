using LLama;
using LLama.Common;
using LLama.Sampling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMuseo.Logic.Services
{
    internal class LLamaCpp : ILLamaCpp
    {

        ChatHistory chatHistory;
        ChatSession session;

        InferenceParams inferenceParams = new InferenceParams()
        {
            MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
            AntiPrompts = new List<string> { "User:" }, // Stop generation once antiprompts appear.
            SamplingPipeline = new DefaultSamplingPipeline(),
        };


        public LLamaCpp(string path, uint? ContextSize = 1024, int GpuLayerCount = 5)
        {
            var modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, path);

            var parameters = new ModelParams(modelPath)
            {
                ContextSize = ContextSize, //The longest length of chat as memory.
                GpuLayerCount = GpuLayerCount //How many layers to offload to GPU. Please adjust it according to your GPU memory.
            };

            var model = LLamaWeights.LoadFromFile(parameters);
            var context = model.CreateContext(parameters);
            var executor = new InteractiveExecutor(context);

            // Add chat histories as prompt to tell AI how to act.
            chatHistory = new ChatHistory();
            chatHistory.AddMessage(AuthorRole.System, """
                You are an expert museum guide and storyteller. Every time the user provides you with artwork data in JSON format, your task is to generate a narrative-style audio guide script that brings the artwork to life for museum visitors.

                Your script should:

                Be 2–3 minutes long when spoken aloud.

                Be written in fluent, expressive English.

                Use a warm, engaging, and immersive storytelling tone.

                Speak directly to the listener, as if you were guiding them through an exhibit.

                Weave factual information from the JSON (such as title, artist, creation date, technique, style, subject, curiosities, emotional tone, and storage location) into a natural and compelling narrative.

                Avoid listing data or using a robotic tone.

                Include vivid visual descriptions and emotional insights.

                If relevant, treat the subject of the artwork as a character and reflect on their possible story or inner world.

                End with a reflective or evocative closing remark to leave a lasting impression.

                Do not invent new facts or deviate from the data provided, but feel free to use creative language, metaphors, and atmosphere to enrich the experience.

                JSON Format Explanation:

                The user will provide artwork data in structured JSON format with fields such as:

                titolo: the title of the artwork

                titolo_alternativo: any alternative title

                autore: the artist's name

                data_realizzazione: the time period of creation

                tecnica: the artistic technique used

                dimensioni: includes altezza_cm and larghezza_cm

                luogo_conservazione: includes nome_museo, città, and stato

                descrizione: general background on the artwork

                stile_artistico: the artistic style (e.g., Renaissance)

                soggetto: includes nome and descrizione of the subject portrayed

                curiosità: a list of interesting facts

                note_tecniche: technical artistic notes

                emozioni_trasmesse: a list of intended or perceived emotional effects

                When you receive this JSON, generate the corresponding audio guide narration automatically.



                """);
            
            chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

            session = new ChatSession(executor, chatHistory);

        }

        public async IAsyncEnumerable<string> ChatAsync(string input)
        {
            await foreach (var text in session.ChatAsync(new ChatHistory.Message(AuthorRole.User, input), inferenceParams))
            {
                yield return text;
            }
        }
    }
}
