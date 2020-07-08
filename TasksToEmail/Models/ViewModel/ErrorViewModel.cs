using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Models.ViewModel
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Menssagem { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}