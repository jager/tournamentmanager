﻿namespace TournamentManager.Framework
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message) : base(message)
        {
        }
    }
}
