using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Entidades
{
    public class LogExcecao
    {
        [Key]
        public Guid Guid { get; private set; }
        public string Mensagem { get; private set; }
        public string StackTrace { get; private set; }
        public DateTime Data { get; private set; }

        public LogExcecao(string mensagem, string stackTrace)
        {
            Guid = Guid.NewGuid();
            Mensagem = mensagem;
            StackTrace = stackTrace;
            Data = DateTime.Now;
        }
    }
}
