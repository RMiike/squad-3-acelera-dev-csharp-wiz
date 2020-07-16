using System;

namespace CentralDeErro.Core.Entities.DTOs
{
    public class LoginReadDTO
    {
        public string Email { get; private set; }

        //TODO Remover token e método
        public string Token { get; private set; }
        public void AddToken(string token)
        {
            if (String.IsNullOrEmpty(token))
                throw new ArgumentNullException("Invalid token.");

            Token = token;
        }
    }
}
