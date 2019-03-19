class Plus extends Expression{

    public Plus(Expression L, Expression P) {
        left = L;
        right = P;
        priority = 1;
    }
    @Override
    public int calc() {
        return left.calc()+right.calc();
    }
    @Override
    public String ToString() {
        return write("+");
    }
    @Override
    public String ToString2() {
        try{
            return write("+") + " = " + calc();
        }
        catch (ArithmeticException a)
        {
            return write("+") + " = NaN";
        }
    }
}