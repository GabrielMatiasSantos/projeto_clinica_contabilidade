using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Convenio
    {
        private int id;
        private string convenio1;
        private int convenio2;
        private decimal valorInicial;
        private decimal glosa;
        private decimal desconto;
        private decimal valor;
        private string mes;
        private string ano;


        public Convenio(int id, int convenio, decimal valorInicial, decimal glosa, decimal desconto, decimal valor, string mes, string ano)
        {
            this.id = id;
            convenio2 = convenio;
            this.valorInicial = valorInicial;
            this.glosa = glosa;
            this.desconto = desconto;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        public Convenio(int convenio, decimal valorInicial, decimal glosa, decimal desconto, decimal valor, string mes, string ano)
        {
            convenio2 = convenio;
            this.valorInicial = valorInicial;
            this.glosa = glosa;
            this.desconto = desconto;
            this.valor = valor;
            this.mes = mes;
            this.ano = ano;
        }

        public Convenio(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public Convenio(int id, string convenio)
        {
            this.id = id;
            convenio1 = convenio;
        }

        public Convenio(string convenio)
        {
            convenio1 = convenio;
        } 
        
        public Convenio(int id)
        {
            this.id = id;
        }


        public int Id
        {
            get {return id;}
        }

        public string Convenio1
        {
            get {return convenio1;}
        }

        public int Convenio2
        {
            get {return convenio2;}
        }

        public decimal ValorInicial
        {
            get {return valorInicial;}
        }

        public decimal Glosa
        {
            get {return glosa;}
        }

        public decimal Desconto
        {
            get {return desconto;}
        }

        public decimal Valor
        {
            get {return valor;}
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
