using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        //Exceção personalizada DbConcurrency
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
