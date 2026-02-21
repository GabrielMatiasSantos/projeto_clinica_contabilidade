using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Escritorio
    {
        private int id;
        private decimal pis;
        private decimal cofins;
        private decimal iss;
        private decimal inss;
        private decimal ir;
        private decimal cs;
        private decimal ciee;
        private decimal aluguel;
        private decimal escritorio;
        private decimal total;
        private string mes;
        private string ano;


        public Escritorio(decimal pis, decimal cofins, decimal iss, decimal inss, decimal ir, decimal cs, decimal ciee, decimal aluguel, decimal escritorio, decimal total, string mes, string ano)
        {            
            this.pis = pis;
            this.cofins = cofins;
            this.iss = iss;
            this.inss = inss;
            this.ir = ir;
            this.cs = cs;
            this.ciee = ciee;
            this.aluguel = aluguel;
            this.escritorio = escritorio;
            this.total = total;
            this.mes = mes;
            this.ano = ano;
        }

        public Escritorio(int id, decimal pis, decimal cofins, decimal iss, decimal inss, decimal ir, decimal cs, decimal ciee, decimal aluguel, decimal escritorio, decimal total, string mes, string ano)
        {
            this.id = id;
            this.pis = pis;
            this.cofins = cofins;
            this.iss = iss;
            this.inss = inss;
            this.ir = ir;
            this.cs = cs;
            this.ciee = ciee;
            this.aluguel = aluguel;
            this.escritorio = escritorio;
            this.total = total;
            this.mes = mes;
            this.ano = ano;
        }

        public Escritorio(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public Escritorio(string ano)
        {            
            this.ano = ano;
        }

        public Escritorio(int id)
        {
            this.id = id;
        }

       
        public decimal Pis
        {
            get {return pis;}
        }

        public decimal Cofins
        {
            get {return cofins;}
        }

        public decimal Iss
        {
            get {return iss;}
        }

        public decimal Inss
        {
            get {return inss;}
        }

        public decimal Ir
        {
            get {return ir;}
        }

        public decimal Cs
        {
            get {return cs;}
        }

        public decimal Ciee
        {
            get {return ciee;}
        }

        public decimal Aluguel
        {
            get { return aluguel; }
        }

        public decimal Escritorio1
        {
            get {return escritorio;}
        }

        public decimal Total
        {
            get {return total;}
        }

        public string Mes
        {
            get {return mes;}
        }

        public string Ano
        {
            get {return ano;}
        }

        public int Id
        {
            get {return id;}
        }
    }
}
