using System;

namespace S
{
    public class Slownik<K,V> 
    where K: IComparable<K>{

        public Para<K,V> pierwszy = null;

        public Slownik() {}

        public void Dodaj(K key, V value) {
            Para<K,V> elem = new Para<K,V>(key,value);
            if(pierwszy == null) {
                pierwszy = elem;
            }
            else {
                Para<K,V> tmp = pierwszy;
                while(tmp.nastepny != null) tmp = tmp.nastepny;
                tmp.nastepny = elem;
            }  
        }

        public void Usun(K key) {
            Para<K,V> tmp = pierwszy;            
            if(tmp == null) Console.WriteLine("Nie ma elementow"); 
            else if(tmp.klucz.CompareTo(key)==0) pierwszy = pierwszy.nastepny;
            else 
                while(tmp.nastepny != null) {
                    if(tmp.nastepny.klucz.CompareTo(key)==0) 
                        tmp.nastepny = tmp.nastepny.nastepny;
                    tmp = tmp.nastepny;
                }
        }

        public V Wyszukaj(K key){
            Para<K,V> tmp = pierwszy;
            if(tmp == null) {Console.WriteLine("Nie ma elementow"); return default(V);}
            while(tmp.nastepny != null) { 
                if(tmp.klucz.CompareTo(key)==0) return tmp.wartosc;
                tmp = tmp.nastepny;
            }
            if(tmp.klucz.CompareTo(key)==0) return tmp.wartosc;
            Console.WriteLine("Nie znaleziono wartosci! ");
            return default(V);
        }

        public void Wypisz() {
            Para<K,V> tmp = pierwszy;
            if(tmp==null) Console.WriteLine("Slownik Pusty!");
             else{
                    while(tmp.nastepny != null) {
                    Console.WriteLine("Klucz: " + tmp.klucz + " Wartosc: " + tmp.wartosc);
                    tmp = tmp.nastepny;
                }
                Console.WriteLine("Klucz: " + tmp.klucz + " Wartosc: " + tmp.wartosc);
            }
        }
    }

    public class Para<K,V>
    where K: IComparable<K> {
        
        public K klucz;
        public V wartosc;
        public Para<K,V> nastepny=null;

        public Para(K key, V value) {
            this.klucz   = key;
            this.wartosc = value;
        } 
    }
}