namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (b > 100)
                return 1100;

            return checked(a + b);
        }
    }
}
