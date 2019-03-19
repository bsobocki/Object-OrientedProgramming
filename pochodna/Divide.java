
class Divide extends Expression{

    public Divide(Expression L, Expression P) {
        left = L;
        right = P;
        priority = 3;
    }
    @Override
    public int calc() {
        try{
            return left.calc() / right.calc();
        }
        catch (ArithmeticException a) {
            System.out.println("Trying to divide by 0!  " + a.getMessage());
        }
        return left.calc() / right.calc();
    }
    @Override
    public String ToString() {
        return write("/");
    }
    @Override
    public String ToString2() {
        try{
            return write("/") + " = " + calc();
        }
        catch (ArithmeticException a) {
            return write("/") + " = " + "NaN";
        }
    }
}
