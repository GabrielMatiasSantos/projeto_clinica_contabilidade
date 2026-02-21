using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class CondominioHorasTotal: Condominio
    {
        private int horas;
       

        public CondominioHorasTotal(int horas, string mes, string ano)
        {
            this.horas = horas;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioHorasTotal(int id)
        {
            this.id = id;
        }

           
        public int Horas
        {
            get {return horas;}
        }

    }
}
