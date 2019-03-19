using System;
using System.Collections.Generic;

namespace New
{
    public static class New
    { 
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            ListaLeniwa nowaLista = new ListaLeniwa();
            Console.WriteLine(nowaLista.element(10));
            Console.WriteLine(nowaLista.element(0));
            Console.WriteLine(nowaLista._size);
            Console.WriteLine(nowaLista.element(11));
            Console.WriteLine(nowaLista._size);
            Console.WriteLine(nowaLista.element(10));
            Console.WriteLine(nowaLista.element(11));
            Console.WriteLine(nowaLista.element(7));
            Console.WriteLine(nowaLista._size);
            Pierwsze pierw = new Pierwsze();
            Console.WriteLine();
            Console.WriteLine(pierw._size);
            Console.WriteLine(pierw.element(3));
            Console.WriteLine(pierw.element(8));
            Console.WriteLine(pierw.element(3));
            Console.WriteLine(pierw.element(9));
            Console.WriteLine(pierw.element(11));
            Console.WriteLine(pierw._size);
            Console.WriteLine();
            pierw.wypiszListe();
        }
    }

    public class ListaLeniwa
    {
        public int _size;
        protected List<int> lista;

        public ListaLeniwa()
        {
            this._size = 0;
            this.lista = new List<int>();
        }

        public int element(int i)
        {
            if(i>this._size)
            {
                Random rand = new Random();
                for (int k = 1; k <= i - this._size; k++)
                {
                    this.lista.Add(rand.Next());
                }
                this._size = i;
            }
            if (i>0)
            return this.lista[i-1];
            Console.WriteLine("Brak takiego elementu! Zwrocona zostanie wartosc 0");
            return 0;
        }

        public int size()
        {
            return this._size;
        }

        public void wypiszListe()
        {
            for (int i = 0; i < this._size; i++)
            {
                Console.WriteLine(this.lista[i]);
            }
        }

    }

    public class Pierwsze : ListaLeniwa
    {

        public Pierwsze()
        {
            this._size = 0;
            this.lista = new List<int>();
        }

        public bool czyPierwsza(int liczba)
        {
            if(liczba==1 || liczba==0) return false;
            if(liczba==2) return true;
            if(liczba%2==0) return false;
            for (int i = 3; i <= Math.Sqrt(liczba); i+=2)
            {
                if(liczba%i==0) return false;
            }
            return true;
        }

        public int kolejnaLiczbaPierwsza(int liczba)
        {
            do
            {
                liczba+=2;
            }while(!czyPierwsza(liczba));
            return liczba;
        }

        public new int element(int i)
        {
            if(i==1) 
            {
                this.lista.Add(2);
                this._size = i;
            }
            else if(i==2) 
            {
                this.lista.Add(3);
                this._size = i;
            } 
            else if(i>this._size)
            {
                int k = this._size;
                if(k==0) 
                {
                    this.lista.Add(2);
                    this.lista.Add(3);
                    k += 2; 
                }
                for (; k < i; k++)
                { 
                    this.lista.Add(kolejnaLiczbaPierwsza(this.lista[k-1]));
                }
                this._size = i;
            }
           

            if (i>0)
            return this.lista[i-1];
            Console.WriteLine("Brak takiego elementu! Zwrocona zostanie wartosc 0");
            return 0;
        }

    }
}