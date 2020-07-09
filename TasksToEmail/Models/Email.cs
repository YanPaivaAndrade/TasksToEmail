using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Models
{
    public class Email
    {
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string CorpoDoEmail { get; set;}
        public Email() { 
        }
                
    }
}