namespace ProjectEuler;

public class _0686 : Problem
{
    /*$2^7=128$ is the first power of two whose leading digits are "12".
    The next power of two whose leading digits are "12" is $2^{80}$.

    Define $p(L, n)$ to be the $n$th-smallest value of $j$ such that the base 10 representation of $2^j$ begins with the digits of $L$.
    So $p(12, 1) = 7$ and $p(12, 2) = 80$.

    You are also given that $p(123, 45) = 12710$.

    Find $p(123, 678910)$.

    */
    public override object Solve() => p(123, 678910);

    private int p(int L, int n)
    {
        int pow = 0;
        int cnt = 0;
        double res = 1;
        double lim = 10 * L;

        while(cnt < n)
        {
            pow++;
            res *= 2;
            if (res > lim) res /= 10;
            if (L == (int)res)
                cnt++;
        }

        return pow;
    }
}