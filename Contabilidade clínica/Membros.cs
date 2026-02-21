using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    class Membros
    {
        private int id;
        private string nome;
        private string funcao;        
        private string relacao;
        private string situacao;


        public Membros(string nome, string funcao, string relacao, string situacao)
        {
            this.nome = nome;
            this.funcao = funcao;            
            this.relacao = relacao;
            this.situacao = situacao;
        }

        public Membros(string nome, string funcao, string relacao, string situacao, int id)
        {
            this.nome = nome;
            this.funcao = funcao;            
            this.relacao = relacao;
            this.situacao = situacao;
            this.id = id;
        }


        public Membros(int id)
        {
            this.id = id;
        }

        public Membros(string funcao, string relacao)
        {
            this.funcao = funcao;
            this.relacao = relacao;
        }

        public Membros(string situacao)
        {
            this.situacao = situacao;
        }

       
        public string Nome
        {
            get {return nome;}
        }

        public string Funcao
        {
            get {return funcao;}
        }       

        public string Relacao
        {
            get {return relacao;}
        }

        public string Situacao
        {
            get {return situacao;}
        }

        public int Id
        {
            get {return id;}
        }
    }
}
