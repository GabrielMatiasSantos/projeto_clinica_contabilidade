using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    public class PagamentosBruto
    {
        private int id;
        private int membro;
        private decimal valor;
        private string mes;
        private string ano;
       

        public PagamentosBruto(int membro, decimal valor, string mes, string ano)
        {
            this.membro = membro;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        public PagamentosBruto(int membro, decimal valor, string mes, string ano, int id)
        {
            this.membro = membro;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
            this.id = id;
        }

        public PagamentosBruto(int id)
        {
            this.id = id;
        }

        public PagamentosBruto(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public PagamentosBruto(int membro, string mes, string ano)
        {
            this.membro = membro;
            this.mes = mes;
            this.ano = ano;
        }


        public int Id
        {
            get { return id; }
        }

        public int Membro
        {
            get { return membro; }
        }

        public decimal Valor
        {
            get { return valor;}
            set {valor = value;}
        }

        public string Mes
        {
            get { return mes;}
        }

        public string Ano
        {
            get { return ano;}
        }        
    }
}
