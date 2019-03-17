using System;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public class InputManager
    {
        private readonly string[] _args;

        public InputManager(string[] args)
        {
            _args = args;
            if (_args != null && _args.Length > 0)
            {
                if (_args.Length > 1)
                {
                    Input = string.Join(" ", _args);
                }
                else
                {
                    Input = _args[0];
                }
            }
            else
            {
                Input = string.Empty;
            }
        }

        public bool ValidateInput(out string feedback)
        {
            feedback = string.Empty;
            if (_args is null || _args.Length == 0)
            {
                feedback = "Include a command line" +
                    " argument as a value to check";
                return false;
            }
            var input = string.Empty;
            if (_args.Length > 1)
            {
                feedback = "Warning! Concatenating all your inputs to one.";
            }
            return true;
        }

        public string Input { get; }
    }
}
