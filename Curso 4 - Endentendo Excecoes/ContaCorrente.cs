using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_4___Endentendo_Excecoes
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public static int ContadorDeSaquesNaoPermitidos { get; private set; }
        public static int ContadorDeTransferenciasNaoPermitidas { get; private set; }


        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            private set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }
        public int Numero { get;} // Conseito de readonly - somente leiruta. 

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                 
                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            if (agencia <= 0)
            {
                throw new ArgumentException("A agencia tem que ser maior que zero",nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O numero tem que ser maior que zero",nameof(numero));
            }
            TotalDeContasCriadas++;
        }


        public void Sacar(double valor)
        {
            if (_saldo < valor)
            {
                ContadorDeSaquesNaoPermitidos++;
                throw new SaldoinsuficienteException("Saldo Insuficiente para saque no valor de: "+ valor );
            }

            _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            try
            {
                Sacar(valor);
            }
            catch (SaldoinsuficienteException ex)
            {
                ContadorDeTransferenciasNaoPermitidas++;
                throw new ArgumentException("Operação não realizada.", ex);
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
