using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class CondominioMembros: Condominio2
    {
        private int[] membro;
        private int membroHoras;
        private int horaValor;
        private decimal valor;


        public CondominioMembros(int horaValor)
        {
            this.horaValor = horaValor;
        }

        public CondominioMembros(decimal valor)
        {
            this.valor = valor;
        }

       
        public int[] Membro
        {
            get {return membro;}
            set {membro = value;}
        }

        public int MembroHoras
        {
            get {return membroHoras;}
            set {membroHoras = value;}
        }

        public int HoraValor
        {
            get {return horaValor;}
        }

        public decimal Valor
        {
            get {return valor;}
            set {valor = value;}
        }
    }
}
