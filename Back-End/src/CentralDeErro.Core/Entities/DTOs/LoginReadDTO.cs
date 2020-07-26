using System;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LoginReadDTO
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; private set; }

        public string Token { get; private set; }
        public void AddToken(string token)
        {
            if (String.IsNullOrEmpty(token))
                throw new ArgumentNullException("Invalid token.");

            Token = token;
        }
    }
}
