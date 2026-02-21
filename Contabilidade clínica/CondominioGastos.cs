using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class CondominioGastos: Condominio
    {
        private decimal cpfl;
        private decimal sanebavi;
        private decimal vivo;
        private decimal correio;
        private decimal aguaBeber;
        private decimal copos;
        private decimal papelHigienico;
        private decimal papelToalha;
        private decimal cafe;
        private decimal acucar;
        private decimal produtosLimpeza;
        private decimal faxina;
        private decimal recargaCelular;
        private decimal outros;
        private decimal total;


        public CondominioGastos(decimal cpfl, decimal sanebavi, decimal vivo, decimal correio, decimal aguaBeber, decimal copos, decimal papelHigienico, decimal papelToalha, decimal cafe, decimal acucar, decimal produtosLimpeza, decimal faxina, decimal recargaCelular, decimal outros, decimal total, string mes, string ano)
        {
            this.cpfl = cpfl;
            this.sanebavi = sanebavi;
            this.vivo = vivo;
            this.correio = correio;
            this.aguaBeber = aguaBeber;
            this.copos = copos;
            this.papelHigienico = papelHigienico;
            this.papelToalha = papelToalha;
            this.cafe = cafe;
            this.acucar = acucar;
            this.produtosLimpeza = produtosLimpeza;
            this.faxina = faxina;
            this.recargaCelular = recargaCelular;
            this.outros = outros;
            this.total = total;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioGastos(int id, decimal cpfl, decimal sanebavi, decimal vivo, decimal correio, decimal aguaBeber, decimal copos, decimal papelHigienico, decimal papelToalha, decimal cafe, decimal acucar, decimal produtosLimpeza, decimal faxina, decimal recargaCelular, decimal outros, decimal total, string mes, string ano)
        {
            this.id = id;
            this.cpfl = cpfl;
            this.sanebavi = sanebavi;
            this.vivo = vivo;
            this.correio = correio;
            this.aguaBeber = aguaBeber;
            this.copos = copos;
            this.papelHigienico = papelHigienico;
            this.papelToalha = papelToalha;
            this.cafe = cafe;
            this.acucar = acucar;
            this.produtosLimpeza = produtosLimpeza;
            this.faxina = faxina;
            this.recargaCelular = recargaCelular;
            this.outros = outros;
            this.total = total;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioGastos(int id, decimal total, string mes, string ano)
        {
            this.id = id;
            this.total = total;
            this.mes = mes;
            this.ano = ano;
        }

        public CondominioGastos(int id)
        {
            this.id = id;
        }

        public CondominioGastos(string mes, string ano)
        {
            this.mes = mes;
            this.ano = ano;
        }        

        public CondominioGastos(string ano)
        {
            this.ano = ano;
        }


        public decimal Cpfl
        {
            get {return cpfl;}
        }

        public decimal Sanebavi
        {
            get {return sanebavi;}
        }

        public decimal Vivo
        {
            get {return vivo;}
        }

        public decimal Correio
        {
            get {return correio;}
        }

        public decimal AguaBeber
        {
            get {return aguaBeber;}
        }

        public decimal Copos
        {
            get {return copos;}
        }

        public decimal PapelHigienico
        {
            get {return papelHigienico;}
        }

        public decimal PapelToalha
        {
            get {return papelToalha;}
        }

        public decimal Cafe
        {
            get {return cafe;}
        }

        public decimal Acucar
        {
            get {return acucar;}
        }

        public decimal ProdutosLimpeza
        {
            get {return produtosLimpeza;}
        }

        public decimal Faxina
        {
            get {return faxina;}
        }

        public decimal RecargaCelular
        {
            get {return recargaCelular;}
        }

        public decimal Outros
        {
            get {return outros;}
        }

        public decimal Total
        {
            get {return total;}
        }
    }
}
