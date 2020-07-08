using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Services.Exceções
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string menssagem) : base(menssagem)
        {

        }
    }
}