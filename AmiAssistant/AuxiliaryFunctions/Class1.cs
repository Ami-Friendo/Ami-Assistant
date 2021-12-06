using System;
using System.Collections.Generic;

namespace AmiFriendo.AuxiliaryFunctions
{
    public class CommandStore
    {
        // <название аргумента, значение аргумента>
        Dictionary<string, string> Commands { get; set; } = new();
    }
}
