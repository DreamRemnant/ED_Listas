using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDoblementeLigadas
{
    internal class Nodo
    {
        public Nodo Anterior { get; set; }
        public String Valor { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo(String valor = "",Nodo anterior = null, Nodo siguiente = null)
        {
            Anterior = anterior;
            Valor = valor;
            Siguiente = siguiente;
        }
    }
}
