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
            var checkInputServ = new CheckInputService(args);
            var feedback = checkInputServ.CheckAsync().GetAwaiter().GetResult();
            return feedback;
        }
    }
}
