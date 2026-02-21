using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class PeriodoValor
    {
        private int id;
        private decimal valor;

        
        public PeriodoValor(int id, decimal valor)
        {
            this.id = id;
            this.valor = valor;
        }


        public int Id
        {
            get { return id;}
        }

        public decimal Valor
        {
            get { return valor;}
        }
    }
}
