using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_4___Endentendo_Excecoes
{
    public class SaldoinsuficienteException : Exception
    {
        public SaldoinsuficienteException(string mensagem) : base(mensagem)
        {

        }
    }
}
