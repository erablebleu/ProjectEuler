namespace ProjectEuler;

public class _0063 : Problem
{
    public override object Solve()
    {
        int cnt = 0;
        for (int i = 0; i < 10; i++)
        {
            int pw = 1;
            string str = ((long)Math.Pow(i, pw)).ToString();
            while (str.Length >= pw)
            {
                if (str.Length == pw) cnt++;
                pw++;
                str = ((long)Math.Pow(i, pw)).ToString();
            }
        }
        return cnt;
    }
}