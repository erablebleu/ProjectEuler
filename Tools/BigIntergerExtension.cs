namespace ProjectEuler.Tools;

public static class BigIntergerExtension
{
    public static BigInteger Sum(this IEnumerable<BigInteger> source)
    {
        BigInteger result = 0;
        foreach (BigInteger value in source)
            result += value;
        return result;
    }

    public static BigInteger Sum(this IEnumerable<int> source, Func<int, BigInteger> predicate)
    {
        BigInteger result = 0;
        foreach (int value in source)
            result += predicate(value);
        return result;
    }

    public static BigInteger Pow(BigInteger value, BigInteger pow)
    {
        BigInteger result = 1;
        for (BigInteger i = 0; i < pow; i++) result *= value;
        return result;
    }
}