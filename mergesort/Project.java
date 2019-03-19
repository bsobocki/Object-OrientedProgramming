import java.util.Random;

/**
 * Created by Bartosz Sobocki on 2018-04-05.
 */
public class Project {
    public static final int rozmiar = 100;
    public static int[] tablica = new int[rozmiar];
    public static int[] tab = new int[rozmiar];

    public static void main(String [] args) throws InterruptedException {

        Random rand = new Random();

        //tworzymy tablice
        for(int i = 0 ; i<rozmiar; i++)
            tablica[i] = rand.nextInt(1000);

        //wypisujemy tablice
        System.out.println("Tablica przed posortowaniem: ");
        for(int i = 0 ; i<rozmiar; i++)
            System.out.println(tablica[i]);

        //sortujemy
        MergeSort.mergesort(0,rozmiar-1);

        //zmienne okreslajace polozenie w tablicach
        int pocz = 0;
        int kon = rozmiar-1;


        //wypisujemy tablice
        System.out.println("\nTablica po sortowaniu: ");
        for(int i = 0 ; i<rozmiar; i++)
            System.out.println(tablica[i]);
    }


    public static class MergeSort implements Runnable {

        int start;
        int meta;

        public MergeSort(int pocz, int kon){
            start = pocz;
            meta = kon;
        }

        @Override
        public void run() {
            try {
                mergesort(start, meta);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        public static void merge(int pocz, int sr, int kon)
        {
            int i,j,q;
            for(i=pocz;i<=kon;i++) tab[i] = tablica[i]; //przepisanie tablicy do pomocniczej

            //utawienie pozycji do sprawdzania
            i = pocz;
            j = sr + 1;
            q = pocz;

            //przenoszenie z tablicy pomocniczej do tablicy glownej z zachowaniem porzadku (scalanie)
            while(i<=sr && j<=kon){
                if(tab[i]<tab[j])
                    tablica[q++] = tab[i++];
                else
                    tablica[q++] = tab[j++];
            }
            //w przypadku kiedy drugi zbior sie skonczyl, przenosimy nieskopiowane dane pierwszego
            while(i<=sr) tablica[q++] = tab[i++];

        }

        public static void mergesort(int pocz, int kon) throws InterruptedException {
            int sr;
            if(pocz<kon){
                sr = (pocz+kon)/2;

                //tworzymy watki dla czesci lewej i prawej tablicy
                MergeSort czesc1 = new MergeSort(pocz,sr);
                MergeSort czesc2 = new MergeSort(sr+1,kon );
                Thread watek1 = new Thread(czesc1);
                Thread watek2 = new Thread(czesc2);

                //wywolujemy watki
                watek1.start();
                watek2.start();

                //czekamy do ich zakonczenia
                watek1.join();
                watek2.join();

                //scalamy powstale tablice
                merge(pocz,sr,kon);
            }
        }
    }


}
