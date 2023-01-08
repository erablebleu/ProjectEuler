namespace ProjectEuler;

public class _0061 : Problem
{
    private int[][] _nb;

    public override object Solve()
    {
        _nb = new int[6][]
        {
                GetPolygonalNumbers(3, 1000, 9999).Select(l => (int)l).ToArray(),
                GetPolygonalNumbers(4, 1000, 9999).Select(l => (int)l).ToArray(),
                GetPolygonalNumbers(5, 1000, 9999).Select(l => (int)l).ToArray(),
                GetPolygonalNumbers(6, 1000, 9999).Select(l => (int)l).ToArray(),
                GetPolygonalNumbers(7, 1000, 9999).Select(l => (int)l).ToArray(),
                GetPolygonalNumbers(8, 1000, 9999).Select(l => (int)l).ToArray()
        };

        foreach (int nb in _nb[0])
        {
            int res = SearchCyclic(nb % 100, nb / 100, 1, 2, 3, 4, 5);

            if (res == 0)
                continue;

            return res + nb;
        }
        return null;
    }

    private IEnumerable<long> GetPolygonalNumbers(int degree, long min, long max)
    {
        int n = 0;
        long val;

        do val = MathHelper.GetPolygonalNumber(degree, n++);
        while (val < min);

        while (val <= max)
        {
            yield return val;
            val = MathHelper.GetPolygonalNumber(degree, n++);
        }
        yield break;
    }

    private int SearchCyclic(int startWith, int endWith, params int[] av)
    {
        if (av.Length == 1)
            return _nb[av[0]].FirstOrDefault(l => l / 100 == startWith && l % 100 == endWith);
        else
        {
            for (int i = 0; i < av.Length; i++)
            {
                var lvls = av.ToList();
                lvls.Remove(av[i]);
                var newAv = lvls.ToArray();

                foreach (int nb in _nb[av[i]].Where(l => l / 100 == startWith))
                {
                    int res = SearchCyclic(nb % 100, endWith, newAv);

                    if (res == 0)
                        continue;

                    return res + nb;
                }
            }
        }
        return 0;
    }
}