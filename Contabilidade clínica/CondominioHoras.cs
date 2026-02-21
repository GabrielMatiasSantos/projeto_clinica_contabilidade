using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class CondominioHoras: Condominio
    {
        private int membro;
        private int horas;

        public CondominioHoras(int membro, int horas, string mes, string ano)
        {
            this.membro = membro;
            this.horas = horas;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioHoras(int id, int membro, int horas, string mes, string ano)
        {
            this.id = id;
            this.membro = membro;
            this.horas = horas;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioHoras(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioHoras(int id)
        {
            this.id = id;
        }


        public int Membro
        {
            get {return membro;}
        }

        public int Horas
        {
            get {return horas;}
        }
    }
}
