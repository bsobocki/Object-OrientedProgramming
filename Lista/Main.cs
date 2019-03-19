using System;

namespace L{
    public class MainClass {
        public static void Main (string[] args) {
            Lista<string> lis = new Lista<string>();
            char wybor = '0';
            while(wybor!='7'){
                Console.WriteLine("Witaj! Została stworzona lista napisow. Jaką operacje chciałbyś wykonać?");
                Console.WriteLine("1)dodac element na poczatek listy");
                Console.WriteLine("2)dodac element na koniec listy");
                Console.WriteLine("3)usunac element z poczatku listy");
                Console.WriteLine("4)usunac element z konca listy");
                Console.WriteLine("5)sprawdzic, czy lista jest pusta");
                Console.WriteLine("6)wypisac liste (przy pustej liscie funkcja nic nie wypisze)");
                Console.WriteLine("7)wyjsc z programu");
                wybor = char.Parse(Console.ReadLine());
                switch(wybor){
                    case '1':
                        Console.WriteLine("podaj napis:");
                        string napis = Console.ReadLine();
                        lis.DodajNaPoczatek(napis);
                        break;
                    case '2':
                        Console.WriteLine("podaj napis:");
                        string napis2 = Console.ReadLine();
                        lis.DodajNaKoniec(napis2);
                        break;
                    case '3':
                        lis.UsunZPoczatku();
                        break;
                    case '4':
                        lis.UsunZKonca();
                        break;
                    case '5':
                        if(lis.CzyPusta()) Console.WriteLine("Lista obecnie jest pusta");
                        else Console.WriteLine("Lista obecnie posiada elementy");
                        break;
                    case '6':
                        lis.wypisz();
                        break;
                    case '7':
                        break;
                    default:
                        Console.WriteLine("Wprowadzono niepoprawny znak");
                        break;
                }
                Console.WriteLine("Nacisnij klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}