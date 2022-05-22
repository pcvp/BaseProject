using System;
using System.Collections.Generic;

namespace DTOs.Token {
    public class AuthResultDTO {
        public bool Authenticated { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
