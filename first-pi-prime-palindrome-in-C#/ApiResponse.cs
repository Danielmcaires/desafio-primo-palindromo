using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace first_pi_prime_palindrome
{
    public class ApiResponse
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}