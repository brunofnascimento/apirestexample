using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Retorno : Success
    {
        public string mensagem { get; set; }
        //public dynamic results { get; set; }
    }
}