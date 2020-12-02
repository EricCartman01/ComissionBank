using System;

namespace ComissionBank.Services.Exceptions
{
    public class DbconcurrencyException : ApplicationException
    {
        public DbconcurrencyException(string message) : base(message)
        {

        }
    }
}
