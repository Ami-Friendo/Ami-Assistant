using System;
using System.Collections.Generic;
using System.Text;

namespace AmiFriendo.CommandHandler.Exceptions
{
    public class NonCanExecuteActionException : Exception
    {
        public NonCanExecuteActionException() : base("action cannot be executed") { }
    }
}
