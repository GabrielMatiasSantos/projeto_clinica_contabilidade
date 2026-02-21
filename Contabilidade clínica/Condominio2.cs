using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    abstract class Condominio2
    {
        protected int id;
        protected int mes;
        protected int ano;

        public int Id
        {
            get {return id;}
            set {id = value;}
        }

        public int Mes
        {
            get {return mes;}
            set {mes = value;}
        }

        public int Ano
        {
            get {return ano;}
            set {ano = value;}
        }
    }
}
