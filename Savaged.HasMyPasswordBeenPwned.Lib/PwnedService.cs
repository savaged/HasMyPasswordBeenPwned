using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public class PwnedService : IPwnedService
    {
        public const string URI = 
            "https://api.pwnedpasswords.com/range/";
        private readonly string _hash;
        private readonly string _hashStart;
        private bool? _isPwned;

        public PwnedService(string hash)
        {
            _hash = hash;
            if (!string.IsNullOrEmpty(_hash))
            {
                _hashStart = _hash.Substring(0, 5);
            }
            else
            {
                _hashStart = string.Empty;
            }
        }

        public async Task LoadAsync()
        {
            var client = new HttpClient();
            var url = $"{URI}{_hashStart}";
            var response = await client.GetAsync(url);
            
            if (response is null)
            {
                _isPwned = false;
                return;
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PwnedServiceException(
                    response);
            }
            var content = await response
                .Content.ReadAsStringAsync();
            var records = content.Split("\r\n");
            var match = false;
            foreach (var record in records)
            {
                var fields = record.Split(':');
                if (fields[0] == _hash.Substring(5))
                {
                    match = true;
                    break;
                }
            }
            _isPwned = match;
        }

        public bool? IsPwned => _isPwned;
    }
}
