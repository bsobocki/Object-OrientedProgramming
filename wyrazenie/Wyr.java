import java.util.HashMap;
import java.util.Map;

/**
 * Created by Bartosz Sobocki on 2018-03-29.
 */
public class Wyr {

    public static void main(String [] args) {

        Dodawanie dod = new Dodawanie(new Stala(5),new Zmienna("x"));
        Zmienna var = new Zmienna("x",5);
        System.out.println(dod.oblicz());
        System.out.println(var.ToString2());
        System.out.println(dod.ToString2());

        System.out.println();

        Odejmowanie wartosc = new Odejmowanie(new Stala(42),new Zmienna("y",42));
        System.out.println(wartosc.ToString2() + " //y = 42");

        System.out.println();

        Wyrazenie.Hmap.put("a",7);
        Wyrazenie.Hmap.put("a",8);
        Zmienna z = new Zmienna("a");
        System.out.println(z.ToString2());

        System.out.println();

        Dzielenie dziel = new Dzielenie(dod,wartosc);
        System.out.println(dziel.ToString2());

        System.out.println();

        System.out.println(z.ToString2());
        Mnozenie mno = new Mnozenie(new Dzielenie(dod,new Odejmowanie(new Zmienna("c",7),z)),new Stala(2));
        System.out.println(mno.ToString2());
    }
}

abstract class Wyrazenie{
    public static Map<String,Integer> Hmap = new HashMap<String, Integer>();
    public abstract int oblicz();
    public abstract String ToString();
    public abstract String ToString2();
}

class Dodawanie extends Wyrazenie{
    private Wyrazenie Lewy;
    private Wyrazenie Prawy;

    public Dodawanie(Wyrazenie L, Wyrazenie P) {
        Lewy = L;
        Prawy = P;
    }

     public int oblicz() {
        return Lewy.oblicz()+Prawy.oblicz();
     }

    public String ToString() {
        return Lewy.ToString() + " + " + Prawy.ToString();
    }

    public String ToString2() {
        String k;
        try{
            k = "" + oblicz();
        }
        catch (ArithmeticException a)
        {
            k = "NaN";
        }
        return Lewy.ToString() + " + " + Prawy.ToString() + " = " + oblicz();
    }
}

class Odejmowanie extends Wyrazenie{
    private Wyrazenie Lewy;
    private Wyrazenie Prawy;

    public Odejmowanie(Wyrazenie L, Wyrazenie P) {
        Lewy = L;
        Prawy = P;
    }

    public int oblicz() {
        return Lewy.oblicz()-Prawy.oblicz();
    }

    public String ToString() {
        return Lewy.ToString() + " - " + Prawy.ToString();
    }

    public String ToString2() {
        return Lewy.ToString() + " - " + Prawy.ToString() + " = " + oblicz();
    }
}

class Mnozenie extends Wyrazenie{
    private Wyrazenie Lewy;
    private Wyrazenie Prawy;

    public Mnozenie(Wyrazenie L, Wyrazenie P)
    {
        Lewy = L;
        Prawy = P;
    }

    public int oblicz() {
        return Lewy.oblicz()*Prawy.oblicz();
    }

    public String ToString() {
        return Lewy.ToString() + " * " + Prawy.ToString();
    }

    public String ToString2() {
        return "(" + Lewy.ToString() + ")" + " * " + "(" +Prawy.ToString() + ")" + " = " + oblicz();
    }
}

class Dzielenie extends Wyrazenie{
    private Wyrazenie Lewy;
    private Wyrazenie Prawy;

    public Dzielenie(Wyrazenie L, Wyrazenie P) {
        Lewy = L;
        Prawy = P;
    }

    public int oblicz() {
        try{
            return Lewy.oblicz() / Prawy.oblicz();
        }
        catch (ArithmeticException a) {
            System.out.println("Nie mozna dzielic przez 0!");
           // ArithmeticException b = null;
           // throw b;
        }
        return Lewy.oblicz() / Prawy.oblicz();
    }

    public String ToString() {
        return "(" + Lewy.ToString() + ")" + " / " + "(" + Prawy.ToString() + ")";
    }

    public String ToString2() {
        String k;
        try{
            k = "" + oblicz();
        }
        catch (ArithmeticException a)
        {
            k = "NaN";
        }
        return "(" + Lewy.ToString() + ")" + " / " + "(" + Prawy.ToString() + ")" + " = " + k;
    }
}

class Stala extends Wyrazenie{
    int wartosc;

    Stala(int val) {
        wartosc = val;
    }

    public int oblicz() {
        return wartosc;
    }

    public String ToString() {
        return "" + wartosc;
    }

    public String ToString2() {
        return "" + wartosc;
    }
}

class Zmienna extends Wyrazenie{
    String variable;

    Zmienna(String var) {
        variable = var;
    }

    Zmienna(String var, Integer val) {
        variable = var;
        Hmap.put(var,val);
    }

    public int oblicz() {
        return Hmap.get(variable);
    }

    public String ToString() {
        return variable;
    }

    public String ToString2() {
        return variable + " = " + Wyrazenie.Hmap.get(variable);
    }
}
