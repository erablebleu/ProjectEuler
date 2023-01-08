namespace ProjectEuler;

public class _0058 : Problem
{
    public override object Solve()
    {
        int cnt = 1;
        int layer = 0;
        int primeCnt = 0;
        int cornerCnt = 1;

        do
        {
            layer++;
            for (int i = 0; i < 4; i++)
                if (MathHelper.IsPrime(cnt + (i + 1) * 2 * layer))
                    primeCnt++;

            cnt += layer * 4 * 2;
            cornerCnt += 4;
        }
        while (primeCnt * 10 >= cornerCnt);

        return 2 * layer + 1;
    }
}