using System;
using S;

namespace NewSl{
    public static class Sl{
        public static void Main(string [] args){
            Slownik<int,string> slow = new Slownik<int,string>();
            char wybor = '0';
            while(wybor!='5'){
                Console.WriteLine("Witaj! Został stworzony slownik napisow. Jaką operacje chciałbyś wykonać?");
                Console.WriteLine("1)dodac element");
                Console.WriteLine("2)usunac element");
                Console.WriteLine("3)wypisac slownik");
                Console.WriteLine("4)wyszukac przy pomocy klucza");
                Console.WriteLine("5)wyjsc z programu");
                wybor = char.Parse(Console.ReadLine());
                switch(wybor){
                    case '1':
                        Console.WriteLine("podaj klucz:");
                        int k = int.Parse(Console.ReadLine());
                        Console.WriteLine("podaj napis:");
                        string napis = Console.ReadLine();
                        slow.Dodaj(k,napis);
                        break;
                    case '2':
                        Console.WriteLine("podaj klucz:");
                        int k2 = int.Parse(Console.ReadLine());
                        slow.Usun(k2);
                        break;
                    case '3':
                        slow.Wypisz();
                        break;
                    case '4':
                        Console.WriteLine("podaj klucz:");
                        int k3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podana warosc: ");
                        Console.WriteLine(slow.Wyszukaj(k3));
                        break;
                    case '5':
                        break;
                    default:
                        Console.WriteLine("Niepoprawny znak");
                        break;
                }
                Console.WriteLine("Nacisnij klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}