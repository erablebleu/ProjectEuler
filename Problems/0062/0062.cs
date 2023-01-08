namespace ProjectEuler;

public record CubeInfo(long Value, long Cube, string DigitsCode);

public class _0062 : Problem
{
    public override object Solve()
    {
        List<CubeInfo> _dt = new();

        for (int i = 100; i < 100000; i++)
            _dt.Add(new CubeInfo(i, (long)Math.Pow(i, 3), new string(((long)Math.Pow(i, 3)).ToString().OrderBy(c => c).ToArray())));

        return _dt.First(c => _dt.Count(d => d.DigitsCode == c.DigitsCode) == 5).Cube;
    }
}