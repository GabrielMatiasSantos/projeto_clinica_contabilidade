using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidade_clínica
{
    abstract class Condominio
    {
        protected int id;
        protected string mes;
        protected string ano;


        public int Id
        {
            get {return id;}
            set {id = value;}
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
