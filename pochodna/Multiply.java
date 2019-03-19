class Multiply extends Expression{

    public Multiply(Expression L, Expression P)
    {
        left = L;
        right = P;
        priority = 3;
    }
    @Override
    public int calc() {
        return left.calc()*right.calc();
    }
    @Override
    public String ToString() {
        return write("*");
    }
    @Override
    public String ToString2() {
        return write("*") + " = " + calc();
    }
}