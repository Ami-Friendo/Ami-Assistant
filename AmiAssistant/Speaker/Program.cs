using System;

namespace Speaker
{
    class Program
    {
        async static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await Talker.Speecher();
        }
    }
}
