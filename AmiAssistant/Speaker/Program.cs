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

namespace Speaker_Engine
{
    public class Listen
    {
        static void Main(string[] args)
        {

        }
        public static string respond;
        public static string language;
        public async static Task Speaker()
        {
            respond = await Talker.Speecher_Listen(respond);
        }
        public async static Task Speaker_Talk(string answer)
        {
            await Talker.Speecher_Voice(answer);
        }
    }
}
