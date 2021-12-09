using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

using System.IO.IsolatedStorage;

using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Speaker
{






    class Talker
    {
        public static async Task RecognitionWithAutoDetectSourceLanguageAsync(SpeechConfig config)
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").

            // Creates an instance of AutoDetectSourceLanguageConfig with the 2 source language candidates
            // Currently this feature only supports 2 different language candidates
            // Replace the languages to be the language candidates for your speech. Please see https://docs.microsoft.com/azure/cognitive-services/speech-service/language-support for all supported languages
            var autoDetectSourceLanguageConfig = AutoDetectSourceLanguageConfig.FromLanguages(new string[] { "ru-RU", "en-US" });

            var stopRecognition = new TaskCompletionSource<int>();

            // Creates a speech recognizer using the auto detect source language config, and the file as audio input.
            // Replace with your own audio file name.
            using (var audioInput = AudioConfig.FromDefaultMicrophoneInput())
            {
                using (var recognizer = new SpeechRecognizer(config, autoDetectSourceLanguageConfig, audioInput))
                {
                    // Subscribes to events.
                    recognizer.Recognizing += (s, e) =>
                    {
                        if (e.Result.Reason == ResultReason.RecognizingSpeech)
                        {
                            Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                            // Retrieve the detected language
                            var autoDetectSourceLanguageResult = AutoDetectSourceLanguageResult.FromResult(e.Result);
                            Console.WriteLine($"DETECTED: Language={autoDetectSourceLanguageResult.Language}");
                        }
                    };

                    recognizer.Recognized += (s, e) =>
                    {
                        if (e.Result.Reason == ResultReason.RecognizedSpeech)
                        {
                            Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                            // Retrieve the detected language
                            var autoDetectSourceLanguageResult = AutoDetectSourceLanguageResult.FromResult(e.Result);
                            Console.WriteLine($"DETECTED: Language={autoDetectSourceLanguageResult.Language}");
                        }
                        else if (e.Result.Reason == ResultReason.NoMatch)
                        {
                            Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                        }
                    };

                    recognizer.Canceled += (s, e) =>
                    {
                        Console.WriteLine($"CANCELED: Reason={e.Reason}");

                        if (e.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }

                        stopRecognition.TrySetResult(0);
                    };

                    recognizer.SessionStarted += (s, e) =>
                    {
                        Console.WriteLine("\n    Session started event.");
                    };

                    recognizer.SessionStopped += (s, e) =>
                    {
                        Console.WriteLine("\n    Session stopped event.");
                        Console.WriteLine("\nStop recognition.");
                        stopRecognition.TrySetResult(0);
                    };

                    // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                    // Waits for completion.
                    // Use Task.WaitAny to keep the task rooted.
                    Task.WaitAny(new[] { stopRecognition.Task });

                    // Stops recognition.
                    await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                }
            }
        }






        public async static Task Speecher_Language(SpeechConfig speechConfig)
        {          

            // can switch "Latency" to "Accuracy" depending on priority
            speechConfig.SetProperty(PropertyId.SpeechServiceConnection_SingleLanguageIdPriority, "Latency");

            //var autoDetectSourceLanguageConfig =
            //    AutoDetectSourceLanguageConfig.FromLanguages(
            //        new string[] { "en-US", "de-DE", "ru-RU" });

            var sourceLanguageConfigs = new SourceLanguageConfig[]
{
    SourceLanguageConfig.FromLanguage("en-US"),
    SourceLanguageConfig.FromLanguage("ru-RU", "The Endpoint Id for custom model of fr-FR")
};

            var autoDetectSourceLanguageConfig =
    AutoDetectSourceLanguageConfig.FromSourceLanguageConfigs(
        sourceLanguageConfigs);

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using (var recognizer = new SpeechRecognizer(
                speechConfig,
                autoDetectSourceLanguageConfig,
                audioConfig))
            {
                var speechRecognitionResult = await recognizer.RecognizeOnceAsync();
                var autoDetectSourceLanguageResult =
                    AutoDetectSourceLanguageResult.FromResult(speechRecognitionResult);
                var detectedLanguage = autoDetectSourceLanguageResult.Language;
                //var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);
                //Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                Console.WriteLine($"Language: {detectedLanguage}");
            }


        }

        public static async Task Speecher_Voice(SpeechConfig speechConfig)
        {
            // Note: if only language is set, the default voice of that language is chosen.
            //speechConfig.SpeechSynthesisLanguage = "<your-synthesis-language>"; // e.g. "de-DE"
                                                                          // The voice setting will overwrite language setting.
                                                                          // The voice setting will not overwrite the voice element in input SSML.
            //speechConfig.SpeechSynthesisVoiceName = "ru-RU-DariyaNeural";
        }

        public async static Task Speecher()
        {
            var speechConfig = SpeechConfig.FromSubscription("d201cb5c2b814c719d199f12f7449b70", "westeurope");
            //await Speecher_Language(speechConfig);
            //await RecognitionWithAutoDetectSourceLanguageAsync(speechConfig);
            using var synthesizer = new SpeechSynthesizer(speechConfig);
            var botConfig = BotFr
            await synthesizer.SpeakTextAsync("Заплати майкрософт, или они прийдут за тобой...");

        }
    }
    
}