using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Saldo
    {
        private int id;
        private decimal valorInicial;
        private int escritorio;
        private decimal pagamentos;
        private decimal saldo;
        private string mes;
        private string ano;

       
        public Saldo(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public Saldo(string ano)
        {
            this.ano = ano;
        }

        public Saldo(int id)
        {
            this.id = id;
        }


        public int Id
        {
            get {return id;}
            set {id = value;}
        } 

        public decimal ValorInicial
        {
            get {return valorInicial;}
            set {valorInicial = value;}
        }

        public int Escritorio
        {
            get {return escritorio;}
            set {escritorio = value;}
        }

        public decimal Pagamentos
        {
            get {return pagamentos;}
            set {pagamentos = value;}
        }

        public decimal Saldo1
        {
            get {return saldo;}
            set {saldo = value;}
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
