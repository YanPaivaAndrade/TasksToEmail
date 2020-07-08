using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Services.Exceções
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base(mensagem)
        {

        }
    }
}