namespace ProjectEuler;

public class _0066 : Problem
{
    public override object Solve()
    {
        BigInteger maxx = 0;
        int dmax = 0;
        BigInteger x, y;

        for (int d = 2; d <= 1000; d++)
        {
            if (MathHelper.IsSquare(d)) continue;
            x = GetSol(d);

            Console.WriteLine($"{x}² - {d}x{x}² = 1");

            if (x > maxx)
            {
                maxx = x;
                dmax = d;
            }
        }

        return dmax;
    }

    // x² - Dy² = 1
    // x² = 1 + Dy²
    private static BigInteger GetSol(int d)
    {
        for (BigInteger x = 2; ; x++)
            if (MathHelper.IsSquare((MathHelper.Square((decimal)x) - 1) / d))
                return x;
    }
}