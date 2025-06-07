﻿namespace PANAMA.Share.Infrastructure
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Expiry { get; set; }
    }
}
