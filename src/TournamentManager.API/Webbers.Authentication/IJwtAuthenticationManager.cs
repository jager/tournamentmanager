﻿namespace Webbers.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}