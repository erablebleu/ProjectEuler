namespace ProjectEuler;

public class _0060 : Problem
{
    public override object Solve()
    {
        List<long> primes = new() { 2 };
        for (int j = 1; j < 5; j++)
            primes.Add(MathHelper.GetNextPrime(primes.Last()));

        int i = 4;
        while (true)
        {
            for (int j = i - 1; j > 2; j--)
            {
                if (!AreConcatAllPrimes(primes[i], primes[j]))
                    continue;

                for (int k = j - 1; k > 1; k--)
                {
                    if (!AreConcatAllPrimes(primes[k], primes[i])
                        || !AreConcatAllPrimes(primes[k], primes[j]))
                        continue;

                    for (int l = k - 1; l > 0; l--)
                    {
                        if (!AreConcatAllPrimes(primes[l], primes[i])
                            || !AreConcatAllPrimes(primes[l], primes[j])
                            || !AreConcatAllPrimes(primes[l], primes[k]))
                            continue;

                        for (int m = l - 1; m >= 0; m--)
                        {
                            if (!AreConcatAllPrimes(primes[m], primes[i])
                                || !AreConcatAllPrimes(primes[m], primes[j])
                                || !AreConcatAllPrimes(primes[m], primes[k])
                                || !AreConcatAllPrimes(primes[m], primes[l]))
                                continue;

                            return primes[i] + primes[j] + primes[k] + primes[l] + primes[m];
                        }
                    }
                }
            }
            primes.Add(MathHelper.GetNextPrime(primes.Last()));
            i++;
        }
    }

    private static bool AreConcatAllPrimes(long v1, long v2) => MathHelper.IsPrime(long.Parse($"{v1}{v2}")) && MathHelper.IsPrime(long.Parse($"{v2}{v1}"));
}