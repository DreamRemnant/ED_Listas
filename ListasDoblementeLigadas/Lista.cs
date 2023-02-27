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
        Nodo nodoFinal; //27 - Febrero - 2023

        public Lista()
        {
            nodoInicial = null;
        }

        public bool ValidaVacio()
        {
            return nodoInicial == null;
        }

        public void VaciarLista()
        {
            nodoInicial = null;
            nodoFinal = null;
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

        public String RecorrerListaReversa(){
            string valores = string.Empty;

            nodoActual = nodoFinal;

            while (nodoActual.Anterior != null)
            {
                nodoActual = nodoActual.Anterior;
                valores += nodoActual.Valor + "\n";
            }
        
            return valores;
        }

        //27 - Feb - 2023
        public void AgregarFinal(String valor) {
            if (ValidaVacio){
                Nodo nuevoNodo = new Nodo(valor);
                nodoInicial = nuevoNodo;
                nodoFinal = nuevoNodo;
                return;
            }

            nodoActual = nodoFinal;
            Nodo nuevoNodo = new Nodo(valor,nodoActual);
            nodoActual.Siguiente = nuevoNodo;
            nodoFinal = nuevoNodo;
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
            if(ValidaVacio)
            {
                Nodo nuevoNodo = new Nodo(valor);
                nodoInicial = nuevoNodo;
                nodoFinal = nuevoNodo;
                return;
            }

            nodoActual = nodoInicial;
            Nodo nuevoNodo = new Nodo(valor, null, nodoActual);
            nodoActual.Anterior = nuevoNodo;
            nodoInicial = nuevoNodo;
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
