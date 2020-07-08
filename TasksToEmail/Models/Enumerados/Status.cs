using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Models.Enumerados
{
    public enum Status : int
    {
        Pendente = 1,
        Dimensionamento = 2,
        Desenvolvimento = 3,
        Entregue = 4,
    }
}