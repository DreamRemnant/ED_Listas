using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDoblementeLigadas
{
    internal class Lista
    {
        Nodo nodoInicial;
        Nodo nodoActual;

        public Lista()
        {
            nodoInicial = new Nodo();
        }

        public bool ValidaVacio()
        {
            return nodoInicial.Siguiente == null;
        }

        public void VaciarLista()
        {
            nodoInicial.Siguiente = null;
        }

        public String RecorrerLista()
        {
            string valores = string.Empty;

            nodoActual = nodoInicial;

            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                valores += nodoActual.Valor + "\n";
            }
        
            return valores;
        }

        public void Agregar(string valor)
        {
            nodoActual = nodoInicial;

            while(nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }

            Nodo nuevoNodo = new Nodo(valor,nodoActual);
            nodoActual.Siguiente = nuevoNodo;
        }

        public void AgregarNodoInicio(string valor)
        {
            nodoActual = nodoInicial;
            if(nodoActual.Siguiente == null)
            {
                Agregar(valor);
                return;
            }
            Nodo nuevoNodo = new Nodo(valor, nodoActual, nodoActual.Siguiente);
            nodoActual.Siguiente.Anterior = nuevoNodo;
            nodoActual.Siguiente = nuevoNodo;            
        }

        public Nodo Buscar(string valor)
        {
            if (ValidaVacio())
            {
                return null;
            }

            nodoActual = nodoInicial;

            while(nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;

                if (nodoActual.Valor == valor)
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

            while(nodoActual.Siguiente != null)
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

        //Se eliminó buscarAnterior porque no es necesario, ya que se puede acceder al nodo Anterior mediante la propiedad del objeto

        public void BorrarNodo(string valor)
        {
            if (ValidaVacio())
            {
                return;
            }

            nodoActual = Buscar(valor);

            if (nodoActual != null)
            {
                if (nodoActual.Anterior != null) { nodoActual.Anterior.Siguiente = nodoActual.Siguiente; }
                if (nodoActual.Siguiente != null) { nodoActual.Siguiente.Anterior = nodoActual.Anterior; }
                nodoActual.Anterior = null;
                nodoActual.Siguiente = null;
            }
        }
    }
}
