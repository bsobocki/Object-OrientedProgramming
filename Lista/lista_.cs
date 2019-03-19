using System;

namespace L {
    
    public class Lista<T> {

        public Element<T> ostatni   {get; set;}
        public Element<T> pierwszy  {get; set;}

        public Lista() {
            this.pierwszy = null;
            this.ostatni  = null;
        } 

        public void DodajNaKoniec (T nowy) {
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

        public void DodajNaPoczatek(T nowy){
            Element<T> element = new Element<T>(nowy);
            if(this.pierwszy == null) {
                this.pierwszy = element;
                this.ostatni  = element;
            }
            else {
                this.pierwszy.poprzedni = element;
                element.nastepny = this.pierwszy;
                this.pierwszy = element;
            }
        }

        public Element<T> UsunZKonca(){
            if(pierwszy!=null){
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

        public Element<T> UsunZPoczatku(){
            if(pierwszy!=null){
                if(this.pierwszy.nastepny!=null){   
                    Element<T> tmp = this.pierwszy;
                    this.pierwszy = this.pierwszy.nastepny;
                    this.pierwszy.poprzedni = null;
                    return tmp;
                }
                else {
                    Element<T> tmp = this.pierwszy;
                    this.pierwszy = null;
                    this.ostatni  = null;
                    return tmp;
                }
            }
            Console.WriteLine("Lista pusta!");
            return null;
        }

        public bool CzyPusta(){
            if(pierwszy == null)
                return true;
            return false;
        }

        public void wypisz()
        {
            if(!CzyPusta()){
                Element<T> tmp = this.pierwszy;
                while(tmp.nastepny!=null){ 
                    Console.WriteLine(tmp.obiekt);
                    tmp = tmp.nastepny;
                }
                Console.WriteLine(this.ostatni.obiekt);
            }
            else
            Console.WriteLine("Lista pusta!");
        }

    }

    public class Element<T> {
        
            public T obiekt             {get; set;}
            public Element<T> nastepny  {get; set;}
            public Element<T> poprzedni {get; set;}

            public Element (T obiekt){
                this.obiekt = obiekt;
                this.nastepny = null;
                this.poprzedni = null;
            }
    }
}