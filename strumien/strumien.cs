using System;

namespace New
{
    public static class Strumien
    {
        public static void Main(string[] args)
        {
            IntStream str = new IntStream();
            Console.WriteLine(str.next());
            Console.WriteLine(str.next());
            Console.WriteLine(str.next());
            Console.WriteLine(str.next());
            Console.WriteLine(str.next());
            Console.WriteLine(str.next());
            Console.WriteLine();
            PrimeStream pstr = new PrimeStream();
            for (int i = 0; i < 100; i++)
            {
            Console.WriteLine(pstr.next());
            }
            Console.WriteLine();
            
            RandomStream rstr = new RandomStream(); 

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(rstr.next());
            }
            Console.WriteLine();

            RandomWordStream RWS = new RandomWordStream();
       

            for(int i = 0; i < 10; i++ )
            {
                Console.WriteLine(RWS.next());
            }
        }
    }

    public class IntStream
    {
        protected int liczba;

        public IntStream()
        {
            this.liczba = -1; //przy wywolaniu next() zostanie zwrocona wartosc 0
        }

        public int next()
        {
            if(!eos())
            { 
                return ++this.liczba;
            }
            return 0;
        }

        protected bool eos()
        {
            if(this.liczba + 1  < 0)
                return true;
            return false;
        }

        public void reset()
        {
            this.liczba = -1;
        }
    }

    public class PrimeStream : IntStream
    {

        public PrimeStream()
        {
            this.liczba = 0;
        }

        private bool czyPierwsza(int liczba)
        {
            if(liczba==1 || liczba==0) return false;
            if(liczba==2) return true;
            if(liczba%2==0) return false;

            for (int i = 3; i <= Math.Sqrt(liczba); i+=2)
                if(liczba%i==0) return false;

            return true;
        }

        private int kolejnaLiczbaPierwsza(int liczba)
        {
            if(liczba==2) return 3;
            do
            {
                liczba+=2;
                if(liczba<0) return -3;
            }while(!czyPierwsza(liczba));
            return liczba;
        }

        private new bool eos()
        {
            if(kolejnaLiczbaPierwsza(this.liczba)==-3)
                return true;
            return false;
        }

        public new int next()
        {
            if(!eos())
            { 
               this.liczba=kolejnaLiczbaPierwsza(this.liczba);
               return this.liczba;
            }
            return 0;
        }

        public new void reset()
        {
            this.liczba = 0;
        }
    }

    public class RandomStream : IntStream
    {
        private Random rand;

        public new bool eos()
        {
            return false;
        }

        public RandomStream()
        {
            this.rand = new Random();
            this.liczba = 0;
        }

        public new int next()
        {
            return rand.Next();
        }

    }

    public class RandomWordStream
    {
        private RandomStream randstr;
        private PrimeStream primestr;
        private int dlugosc;

        public RandomWordStream()
        {
            this.randstr  = new RandomStream();
            this.primestr = new PrimeStream();
            this.dlugosc  = 0;
        }

        public string next()
        {
            this.dlugosc = primestr.next();
            string napis = "";
            int czyWielka;
            char litera;
            for(int i=0; i<this.dlugosc; i++)
            {
               czyWielka = randstr.next()%2;

               if(czyWielka==0)
                  litera = ((char)(randstr.next()%26 + 97));
               else
                  litera = ((char)(randstr.next()%26 + 65));

                napis = "" + napis + litera;
            }
            return napis;
        }
    }
}