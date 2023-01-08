namespace ProjectEuler;

public class _0065 : Problem
{
    public override object Solve()
    {
        var nd = GetN(100);

        return nd.Item1.ToString().Sum(c => int.Parse(c.ToString()));
    }

    private (BigInteger, BigInteger) GetN(int lvl)
    {
        BigInteger n = GetSeq(lvl - 1);
        BigInteger d = 1;

        for (int i = lvl - 2; i >= 0; i--)
        {
            BigInteger tmp = d;
            d = n;
            n = tmp;
            n += d * GetSeq(i);
        }
        return (n, d);
    }

    private int GetSeq(int n)
    {
        if (n == 0) return 2;
        n--;
        if ((n % 3) % 2 == 0) return 1;
        return 2 * (n / 3 + 1);
    }
}