class Minus extends Expression{

    public Minus(Expression L, Expression P) {
        left = L;
        right = P;
        priority = 2;
    }
    @Override
    public int calc() {
        return left.calc()-right.calc();
    }
    @Override
    public String ToString() {
        return write("-");
    }
    @Override
    public String ToString2() {
        return write("+") + " = " + calc();
    }
}
