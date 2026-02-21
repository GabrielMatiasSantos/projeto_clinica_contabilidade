using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class CondominioHoraValor: Condominio2
    {
        private int condominioTotal;
        private int horasTotal;
        private decimal valor;

        public CondominioHoraValor(int condominioTotal, int horasTotal, decimal valor, int mes, int ano)
        {
            this.condominioTotal = condominioTotal;
            this.horasTotal = horasTotal;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        
        public int CondominioTotal
        {
            get {return condominioTotal;}
        }

        public int HorasTotal
        {
            get {return horasTotal;}
        }

        public decimal Valor
        {
            get {return valor;}
        }      
    }
}
