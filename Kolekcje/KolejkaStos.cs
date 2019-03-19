using System;
using System.Collections;

namespace L {

    public class Program{
        
        public static void Main(string [] args){

            //prezentacja kolejki
            Kolejka<string> kol = new Kolejka<string>();
            kol.Dodaj("pierwszy"); //dodajemy elementy
            kol.Dodaj(kol.ToString<int>(2));
            kol.Dodaj("trzeci");
            kol.Dodaj("czwarty");
            Console.WriteLine("pierwszy to : " +kol[0].obiekt); //sprawdzamy jak wyglada pierwszy
            kol.Usun(); //usuwamy pierwszy element
            kol.Wypisz(); //wypisujemy liste juz bez pierwszego

            Console.WriteLine();

            //przechodzimy do stosu
            Console.WriteLine("Stos:");
             Stos<string>st = new Stos<string>();
            st.Dodaj("pierwszy"); //dodajemy elementy
            st.Dodaj("drugi");
            st.Dodaj("trzeci");
            st.Dodaj("czwarty");
            Console.WriteLine("usuniety: " +st.Usun().obiekt); //pokazujemy, ktory element usunelismy
            st.Wypisz(); //wypisujemy bez ostatniego elementu


            Console.WriteLine("\nczas na foreach: "); 

            //wypisanie foreach'em kolejki
            foreach (string item in kol)
            {
                Console.WriteLine(item);
            }
        }

    }



    interface IKolekcje<T>
    {
        void       Dodaj(T nowy);
        Element<T> Usun();
        bool       Empty();
        void       Wypisz();
    }
    
    public class Stos<T> : IKolekcje<T>{

        private Element<T> pierwszy  {get; set;}
        public Element<T> ostatni   {get; set;}

         public Stos() {
            this.pierwszy = null;
            this.ostatni  = null;
        } 

         public void Dodaj (T nowy) {

            Element<T> element = new Element<T>(nowy);
            if(this.pierwszy == null) {
                this.pierwszy = element;
                this.ostatni  = element;
            }
            else {
                this.ostatni.nastepny = element;
                element.poprzedni = this.ostatni;
                this.ostatni = element;
            }            
        }

        public Element<T> Usun(){

            if(ostatni!=null){
                if(pierwszy.nastepny!=null){ 
                    Element<T> tmp = this.ostatni;
                    this.ostatni = this.ostatni.poprzedni;
                    this.ostatni.nastepny = null;
                    return tmp;
                }
                else{
                    Element<T> tmp = this.ostatni;
                    this.pierwszy = null;
                    this.ostatni  = null;
                    return tmp;
                }
            }
            Console.WriteLine("Lista pusta!");
            return null;
        }

        public bool Empty(){

            if(pierwszy == null)
                return true;
            return false;
        }

        public void Wypisz(){

            if(!Empty()){
                Element<T> tmp = this.ostatni;
                while(tmp.poprzedni!=null){ 
                    Console.WriteLine(tmp.obiekt);
                    tmp = tmp.poprzedni;
                }
                Console.WriteLine(tmp.obiekt);
            }
            else
            Console.WriteLine("Lista pusta!");
        }


       
    }

    public class Kolejka<T> : IKolekcje<T>,IEnumerable {

        private Element<T> pierwszy  {get; set;}
        private Element<T> ostatni   {get; set;}
        public int Length { get; set; }

        public Kolejka() {
            Length = 0;
            this.pierwszy = null;
            this.ostatni  = null;
        } 

        IEnumerator IEnumerable.GetEnumerator() {
            return (IEnumerator) GetEnumerator();
        }

         public Element<T> GetEnumerator(){
            return new Element<T>();
        }

        public string ToString<K>(K var){
            return ""+var;
        }

        public Element<T> this[int index]{
            get
            {
                Element<T> temp = pierwszy;
                int iter = 0;
                if (index >= 0 && index <= Length - 1){

                       while(iter!=index){
                           temp = temp.nastepny;
                           iter++;
                       }
                }
                else
                    temp = null;
                return temp;
            }
        }

        public void Dodaj(T nowy) {

            Element<T> element = new Element<T>(nowy,pierwszy);
            Length++;
            if(this.pierwszy == null) {
                this.pierwszy = element;
                this.ostatni  = element;
            }
            else {
                this.ostatni.nastepny = element;
                element.poprzedni = this.ostatni;
                this.ostatni = element;
            }            
        }


        public Element<T> Usun(){

            if(pierwszy!=null){
                if(this.pierwszy.nastepny!=null){   
                    Element<T> tmp = this.pierwszy;
                    this.pierwszy = this.pierwszy.nastepny;
                    this.pierwszy.poprzedni = null;
                    new Element<T>(tmp.obiekt,pierwszy);
                    return tmp;
                }
                else {
                    Element<T> tmp = this.pierwszy;
                    this.pierwszy = null;
                    this.ostatni  = null;
                    new Element<T>(tmp.obiekt,pierwszy);
                    return tmp;
                }
            }
            Console.WriteLine("Lista pusta!");
            return null;
        }

        public bool Empty(){

            if(pierwszy == null)
                return true;
            return false;
        }

        public void Wypisz()
        {
            if(!Empty()){
                Element<T> tmp = this.pierwszy;
                while(tmp.nastepny!=null){ 
                    Console.WriteLine(tmp.obiekt);
                    tmp = tmp.nastepny;
                }
                Console.WriteLine(tmp.obiekt);
            }
            else
            Console.WriteLine("Lista pusta!");
        }

    }

    public class Element<T> : IEnumerator{
        
            public T obiekt             {get; set;}
            public Element<T> nastepny  {get; set;}
            public Element<T> poprzedni {get; set;}

            private static int iter=0;
            public  static Element<T> obecny{get; set;}

            public Element (){
                if(obecny!=null)
                this.obiekt = obecny.obiekt;
                this.nastepny = null;
                this.poprzedni = null;
            }

             public Element (T obiekt){
                this.obiekt = obiekt;
                this.nastepny = null;
                this.poprzedni = null;
            }

            public Element (T obiekt, Element<T> first){
                this.obiekt = obiekt;
                this.nastepny = null;
                this.poprzedni = null;
                obecny = first;
            }

             public bool MoveNext(){
                 if(iter==0)
                       iter++;
                else{
                    obecny = obecny.nastepny;
                    iter++;
                }
                if(obecny==null) return false;
                return (obecny!=null);
             }

            public void Reset(){
                iter=0;
            }

            public T Current{
                get{
                    return obecny.obiekt;
                }
            }

              object IEnumerator.Current{
            
            get{
                return Current;
            }
        }
    }
}