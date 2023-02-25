using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasSimplementeLigadas
{
    internal class Lista
    {
        Nodo nodoInicial;
        Nodo nodoActual;
        public Lista()
        {
            nodoInicial= new Nodo();
        }
        public bool ValidaVacio()
        {
            return nodoInicial.Siguiente == null;
        }
        public void VaciarLista()
        {
            nodoInicial.Siguiente = null;
        }
        public string Recorrer()
        {
            string datos = string.Empty;
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                datos += nodoActual.Valor + "\n";
            }
            return datos;
        }
        public void Agregar(string valor)
        {
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            Nodo nodoNuevo = new Nodo(valor);
            nodoActual.Siguiente= nodoNuevo;
        }

        public void AgregarAlInicio(String valor)
        {
            nodoActual = nodoInicial;
            Nodo nuevoNodo = new Nodo(valor, nodoActual.Siguiente);
            nodoActual.Siguiente = nuevoNodo;
        }

        public Nodo Buscar(string valor)
        {
            if (ValidaVacio())
            {
                return null;
            }
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                if (nodoActual.Valor==valor)
                {
                    return nodoActual;
                }
            }
            return null;
        }

        public Nodo BuscarPorIndice(int indice)
        {
            int Indice = -1;

            if (ValidaVacio())
            {
                return null;
            }

            nodoActual = nodoInicial;

            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                Indice++;

                if(Indice == indice)
                {
                    return nodoActual;
                }
            }

            return null;
        }

        public Nodo BuscarAnterior(String valor)
        {
            if (ValidaVacio()) 
            {
                return null;
            }

            nodoActual = nodoInicial;

            while(nodoActual.Siguiente != null && nodoActual.Siguiente.Valor != valor)
            {
                nodoActual = nodoActual.Siguiente;
                if (nodoActual.Siguiente.Valor == valor)
                {
                    return nodoActual;
                }
            }

            return null;
        }

        public void BorrarNodo(String valor)
        {
            if (ValidaVacio())
            {
                return;
            }

            nodoActual = Buscar(valor);

            if (nodoActual != null)
            {
                Nodo nodoAnterior = BuscarAnterior(valor);
                nodoAnterior.Siguiente = nodoActual.Siguiente;
                nodoActual.Siguiente = null;
            }
        }
    }
}
