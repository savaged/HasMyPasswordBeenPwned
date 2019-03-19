using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public class CheckInputService 
    {
        private string[] _args;
        
        public CheckInputService(string[] args)
        {
            _args = args;
        }

        public CheckInputService(string arg)
        {
            _args = new string[] { arg };
        }

        public async Task<string> CheckAsync()
        {
            var inputMgr = new InputManager(_args);
            var result = inputMgr
                .ValidateInput(out string feedback);
            if (result)
            {
                var hashServ = new HashService(inputMgr.Input);
                var pwnedServ = new PwnedService(hashServ.Hash);
                await pwnedServ.LoadAsync();
                result = pwnedServ.IsPwned == true;
                feedback += result ?
                    $"{Environment.NewLine} Pwned! Change it!" :
                    "Not Pwned, phew!";
            }
            return feedback;
        }
    }
}
