using System;
using System.Collections;

namespace PC{

    public class PrCl {
        public static void Main(string [] args) {

            PrimeCollection prcl = new PrimeCollection();
            foreach (int p in prcl)
                Console.WriteLine(p);

        }
    }

    public class PrimeCollection : IEnumerable {

        private long pierwsza=Int32.MaxValue-1000;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public Prime GetEnumerator(){
            return new Prime(pierwsza);
        }
    }

    public class Prime : IEnumerator{

        private static long pierwsza;

        public Prime(long first){
            pierwsza = first;
        }

         public bool ifPrime(long l)
        {
            if(l==1 || l==0) return false;
            if(l==2) return true;
            if(l%2==0) return false;
            for (long i = 3; i <= Math.Sqrt(l); i+=2)
            {
                if(l%i==0) return false;
            }
            return true;
        }

        public long nextPrime(long prime){
           
            if(prime==1) return 2;
            if(prime==2) return 3;
            if(prime%2==0) prime-=1;

            do
            {
                prime+=2;
            }while(!ifPrime(prime));
            return prime;
        }

        public bool MoveNext(){
            pierwsza = nextPrime(pierwsza);
            return (pierwsza <= Int32.MaxValue);
        }

        public void Reset(){
            pierwsza = 1;
        }

        public long Current{

            get{
                return pierwsza;
            }
        }

        object IEnumerator.Current{
            
            get{
                return Current;
            }
        }
    }

}