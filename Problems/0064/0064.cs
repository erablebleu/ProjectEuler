namespace ProjectEuler;

public record IrrationalSqrt
{
    public int N { get; set; }
    public int Main { get; set; }
    public List<int> Block { get; set; } = new List<int>();
    public bool IsIrrationnal { get; set; }
    public IrrationalSqrt(int n)
    {
        N = n;
        Main = (int)Math.Sqrt(n);
        IsIrrationnal = Math.Pow(Main, 2) != n;
        if (!IsIrrationnal)
            return;
        GetBlock2();
    }
    private void GetBlock2()
    {
        long a = Main;
        long p = 0;
        long q = 1;
        do
        {
            p = a * q - p;
            q = (N - p * p) / q;
            a = (Main + p) / q;
            Block.Add((int)a);
        }
        while (q != 1);
    }
}

public class _0064 : Problem
{
    public override object Solve()
    {
        var tst = new IrrationalSqrt(23);
        var tst2 = new IrrationalSqrt(7981);

        return Enumerable.Range(1, 10000).Select(i => new IrrationalSqrt(i)).Where(sr => sr.IsIrrationnal).Count(sr => sr.Block.Count % 2 == 1);
    }
}