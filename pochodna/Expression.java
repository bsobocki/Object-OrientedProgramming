import java.util.HashMap;
import java.util.Map;

abstract class Expression{

    protected Expression left;
    protected Expression right;
    protected int priority;
    public static Map<String,Integer> Hmap = new HashMap<String, Integer>();

    public Expression getL() { return left;}
    public Expression getR() { return right;}
    public abstract int calc();
    public String write(String operator){
        if(priority>left.priority)
            if(priority>right.priority)
                return "(" + left.toString() + ") " + operator + " (" + right.toString() + ")";
            else
                return "(" + left.toString() + ") " + operator + " " + right.toString();
        else
            if(priority>right.priority)
                return left.toString() + " " + operator + " (" + right.toString() + ")";
        return left.ToString() + operator + right.ToString();
    }
    public abstract String ToString();
    public abstract String ToString2();
}