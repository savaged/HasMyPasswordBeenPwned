using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public class PwnedServiceException : Exception
    {
        public PwnedServiceException(
            HttpResponseMessage response)
            : base(response.ReasonPhrase)
        {
        }
    }
}
