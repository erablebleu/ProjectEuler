using System.IO;

namespace ProjectEuler;

public class _0067 : Problem
{
    public override object Solve()
    {
        int[][] data = File.ReadAllLines(Path.Combine(CurrentDirectory, "triangle.txt")).Select(l => l.Split(" ").Select(c => int.Parse(c)).ToArray()).ToArray();

        for (int i = 1; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (j == 0) data[i][j] += data[i - 1][j];
                else if (j == data[i].Length - 1) data[i][j] += data[i - 1][j - 1];
                else data[i][j] += Math.Max(data[i - 1][j], data[i - 1][j - 1]);
            }
        }

        return data.Last().Max();
    }
}