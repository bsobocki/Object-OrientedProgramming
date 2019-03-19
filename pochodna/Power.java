class Power extends Expression{

    public Power(Expression f,Expression pow)
    {
        left = f;
        right = pow;
        priority = 4;
    }
    @Override
    public int calc(){
        return (int)Math.pow(left.calc(),right.calc());
    }
    @Override
    public String ToString(){
        return write("^");
    }
    @Override
    public String ToString2(){
        return write("^") + " = " + calc();
    }
}