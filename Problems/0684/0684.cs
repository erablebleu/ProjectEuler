namespace ProjectEuler;

public class _0684 : Problem
{
    /*

    Define $s(n)$ to be the smallest number that has a digit sum of $n$. For example $s(10) = 19$.
    Let $\displaystyle S(k) = \sum_{n=1}^k s(n)$. You are given $S(20) = 1074$.

    Further let $f_i$ be the Fibonacci sequence defined by $f_0=0, f_1=1$ and $f_i=f_{i-2}+f_{i-1}$ for all $i \ge 2$.

    Find $\displaystyle \sum_{i=2}^{90} S(f_i)$. Give your answer modulo $1\,000\,000\,007$.

     */

    private Dictionary<BigInteger, BigInteger> _s = new();
    private Dictionary<BigInteger, BigInteger> _S = new();

    public override object Solve()
    {
        BigInteger[] fi = MathHelper.Fibonacci(90);
        return Enumerable.Range(2, 89).Sum(i => S(fi[i])) % 1000000007;
    }

    private BigInteger s(BigInteger n)
    {
        BigInteger val = n;
        if (_s.ContainsKey(n)) return _s[n];

        List<BigInteger> digits = new();

        while (val > 9 && digits.Count < 20)
        {
            digits.Add(9);
            val -= 9;
        }
        digits.Add(val);

        BigInteger result = Enumerable.Range(0, digits.Count).Sum(i => digits[i] * BigIntergerExtension.Pow(10, i));
        _s.Add(n, result);
        return result;
    }

    private BigInteger S(BigInteger k)
    {
        if (_S.ContainsKey(k))
            return _S[k];

        BigInteger res = _S.Any() ? _S.Last().Value : 0;
        for (BigInteger n = _S.Any() ? _S.Last().Key + 1 : 1; n <= k; n++)
            res += s(n);

        _S.Add(k, res);
        return res;
    }
}