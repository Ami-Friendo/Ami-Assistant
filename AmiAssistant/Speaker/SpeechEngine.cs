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

        public async static Task Speecher_Language(SpeechConfig speechConfig)
        {          

            // can switch "Latency" to "Accuracy" depending on priority
            speechConfig.SetProperty(PropertyId.SpeechServiceConnection_SingleLanguageIdPriority, "Latency");

            var autoDetectSourceLanguageConfig =
                AutoDetectSourceLanguageConfig.FromLanguages(
                    new string[] { "en-US", "de-DE", "ru-RU" });

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
            using var synthesizer = new SpeechSynthesizer(speechConfig);
            await synthesizer.SpeakTextAsync("Synthesizing directly to speaker output.");

        }
    }
    
}