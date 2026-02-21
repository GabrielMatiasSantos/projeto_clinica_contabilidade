using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Aluguel
    {
        private int id;
        private int membro;
        private string periodo;
        private decimal valor;
        private string mes;
        private string ano;


        public Aluguel(int membro, string periodo, decimal valor, string mes, string ano, int id)
        {
            this.membro = membro;
            this.periodo = periodo;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
            this.id = id;
        }

        public Aluguel(int membro, string periodo, decimal valor, string mes, string ano)
        {
            this.membro = membro;
            this.periodo = periodo;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        public Aluguel(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }       

        public Aluguel(decimal valor)
        {
            this.valor = valor;
        }

        public Aluguel(int id)
        {
            this.id = id;
        }


        public int Id
        {
            get {return id;}
        }
        
        public string Periodo
        {
            get {return periodo;}
            set {periodo = value;}
        }

        public int Membro
        {
            get {return membro;}
            set {membro = value;}
        }

        public decimal Valor
        {
            get {return valor;}
            set {valor = value;}
        }

        public string Mes
        {
            get {return mes;}
        }

        public string Ano
        {
            get {return ano;}
        }
    }
}
