using System.Diagnostics;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Solve(102, 1);
        }

        private static void Solve(int number, int count = 1)
        {
            Console.WriteLine($"┌──────────┬────────────────────┬───────────────────────────┐");
            Console.WriteLine($"│ Problem  │               Time │                    Result │");
            Console.WriteLine($"├──────────┼────────────────────┼───────────────────────────┤");

            for (int i = number; i < number + count; i++)
            {
                Console.Write($"│   {i:D4}   │");
                (int l, int r) = Console.GetCursorPosition();
                Console.Write($"    generating class and downloading data");
                Problem pb = Problem.Get(i);
                Console.SetCursorPosition(l, r);
                Console.Write($"                                         ");
                Console.SetCursorPosition(l, r);
                Stopwatch sw = new();
                if (pb is null)
                {
                    Console.WriteLine($"                    │                           │*");
                    continue;
                }
                sw.Restart();
                object sol = pb.Solve();
                sw.Stop();
                Console.WriteLine($" {sw.Elapsed.TotalMilliseconds,15:F2} ms │ {sol,25} │");
            }
            Console.WriteLine($"└──────────┴────────────────────┴───────────────────────────┘");
        }
    }
}