using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Services.Exceções
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string menssagem) : base(menssagem)
        {

        }
    }
}