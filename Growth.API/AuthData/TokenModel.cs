using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.AuthData
{
    /// <summary>
    /// Model to store and share token details with token string, expiration and role of a user
    /// </summary>
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
