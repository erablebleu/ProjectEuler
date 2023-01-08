using System.IO;

namespace ProjectEuler;

public class _0059 : Problem
{
    public override object Solve()
    {
        List<int> data = File.ReadAllText(Path.Combine(CurrentDirectory, "p059_cipher.txt")).Split(",").Select(c => int.Parse(c)).ToList();

        for (char c1 = 'a'; c1 <= 'z'; c1++)
            for (char c2 = 'a'; c2 <= 'z'; c2++)
                for (char c3 = 'a'; c3 <= 'z'; c3++)
                {
                    string key = $"{c1}{c2}{c3}";
                    string line = "";
                    for (int i = 0; i < data.Count; i++)
                        line += (char)(data[i] ^ key[i % 3]);
                    if (line.Contains(" the "))
                    {
                        Console.WriteLine($"{key} - {line}");
                        return line.Sum(c => (int)c);
                    }
                }
        return null;
    }
}