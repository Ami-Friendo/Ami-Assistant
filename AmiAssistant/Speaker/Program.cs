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
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await Talker.Speecher();
        }
    }
}
