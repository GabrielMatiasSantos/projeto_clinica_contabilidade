using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    public class PagamentosLiquido
    {        
        private int[] membro;
        private int valorBruto;
        private int imposto;
        private int condominio;
        private int aluguel;
        private decimal valor;
        private int mes;
        private int ano;

       
        public int[] Membro
        {
            get {return membro;}
            set {membro = value;}
        }

        public int ValorBruto
        {
            get {return valorBruto;}
            set {valorBruto = value;}
        }

        public int Imposto
        {
            get {return imposto;}
            set {imposto = value;}
        }

        public decimal Valor
        {
            get {return valor;}
            set {valor = value;}
        }

        public int Mes
        {
            get {return mes;}
            set { mes = value; }
        }

        public int Aluguel
        {
            get {return aluguel;}
            set {aluguel = value;}
        }

        public int Condominio
        {
            get {return condominio;}
            set {condominio = value;}
        }

        public int Ano
        {
            get {return ano;}
            set {ano = value;}
        }
    }
}
