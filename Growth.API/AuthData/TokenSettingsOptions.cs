using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.AuthData
{
    /// <summary>
    /// To retain token settings - which defined in appsettings.json
    /// </summary>
    public class TokenSettingsOptions
    {
        public const string TokenSettings = "TokenSettings";
        public string Key { get; set; }
        public int DurationMinutes { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

    }
}
