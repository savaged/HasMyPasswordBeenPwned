using Savaged.HasMyPasswordBeenPwned.Lib;
using System;

namespace Savaged.HasMyPasswordBeenPwned.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var feedback = program.Run(args);
            Console.Write(feedback);
            Console.ReadLine();
        }

        public string Run(string[] args)
        {
            var inputMgr = new InputManager(args);
            var result = inputMgr
                .ValidateInput(out string feedback);
            if (result)
            {
                var hashServ = new HashService(inputMgr.Input);
                var pwnedServ = new PwnedService(hashServ.Hash);
                pwnedServ.LoadAsync().GetAwaiter().GetResult();
                result = pwnedServ.IsPwned == true;
                feedback += result ?
                    $"{Environment.NewLine}Pwned! Change it!" :
                    "Not Pwned, phew!";
            }
            return feedback;
        }
    }
}
