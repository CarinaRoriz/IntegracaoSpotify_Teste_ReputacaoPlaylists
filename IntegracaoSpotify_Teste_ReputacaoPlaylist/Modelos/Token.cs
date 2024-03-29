﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracaoSpotify_Teste_ReputacaoPlaylist.Modelos
{
    public class Token
    {
        public Token()
        {
            CreateDate = DateTime.Now;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
