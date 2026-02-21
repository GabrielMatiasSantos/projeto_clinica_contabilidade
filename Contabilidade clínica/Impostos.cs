using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Impostos
    {
        private int id;
        private int membro;
        private  decimal taxa;
        private int pagamento;
        private decimal valor;
        private int mes;
        private int ano;


        public Impostos(int membro, decimal taxa, int pagamento, decimal valor, int mes, int ano)
        {
            this.membro = membro;
            this.taxa = taxa;
            this.pagamento = pagamento;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        public Impostos(int membro, decimal taxa, int pagamento, decimal valor, int mes, int ano, int id)
        {
            this.membro = membro;
            this.taxa = taxa;
            this.pagamento = pagamento;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
            this.id = id;
        }

        public Impostos(int id)
        {
            this.id = id;
        }

        public Impostos(decimal valor)
        {
            this.valor = valor;
        }


        public int Membro
        {
            get {return membro;}
        }

        public decimal Taxa
        {
            get {return taxa;}
        }

        public int Pagamento
        {
            get {return pagamento;}
        }

        public decimal Valor
        {
            get {return valor;}
        }

        public int Mes
        {
            get {return mes; }
        }

        public int Ano
        {
            get {return ano;}
        }

        public int Id
        {
            get { return id; }
        }
    }
}
