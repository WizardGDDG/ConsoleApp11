using ScottPlot;
using System.Drawing;

class Program
{
    static void Main()
    {
        string papka = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var grafik1 = new Plot();
        for (double a = 0; a <= 6; a += 0.1)
        {
            for (double b = 0; b <= 6; b += 0.1)
            {
                if (a + 3 * b >= 3 && 2 * a + b <= 2 && a + b <= 5)
                {
                    var tochka = grafik1.Add.Marker(a, b);
                    tochka.Color = Colors.Green.WithAlpha(0.2);
                    tochka.MarkerSize = 2;
                }
            }
        }

        double[] x = { 0, 1, 2, 3, 4, 5, 6 };

        var liniya1 = grafik1.Add.Scatter(x, x.Select(z => (3 - z) / 3).ToArray());
        liniya1.Color = Colors.Red;
        var liniya2 = grafik1.Add.Scatter(x, x.Select(z => 2 - 2 * z).ToArray());
        liniya2.Color = Colors.Blue;
        var liniya3 = grafik1.Add.Scatter(x, x.Select(z => 5 - z).ToArray());
        liniya3.Color = Colors.Orange;

        grafik1.Title("система 1");
        grafik1.XLabel("x1");
        grafik1.YLabel("x2");
        grafik1.Axes.SetLimits(0, 6, 0, 6);
        grafik1.SavePng(Path.Combine(papka, "zadanie_a.png"), 600, 600);

        var grafik2 = new Plot();
        for (double q = 0; q <= 10; q += 0.1)
        {
            for (double w = 0; w <= 8; w += 0.1)
            {
                if (-q + 3 * w <= 9 && 2 * q + 3 * w <= 18 && 2 * q - w <= 10)
                {
                    var tochka2 = grafik2.Add.Marker(q, w);
                    tochka2.Color = Colors.Green.WithAlpha(0.2);
                    tochka2.MarkerSize = 2;
                }
            }
        }

        double[] xx = { 0, 2, 4, 6, 8, 10 };

        var lin1 = grafik2.Add.Scatter(xx, xx.Select(v => (9 + v) / 3).ToArray());
        lin1.Color = Colors.Red;
        var lin2 = grafik2.Add.Scatter(xx, xx.Select(v => (18 - 2 * v) / 3).ToArray());
        lin2.Color = Colors.Blue;
        var lin3 = grafik2.Add.Scatter(xx, xx.Select(v => 2 * v - 10).ToArray());
        lin3.Color = Colors.Orange;

        grafik2.Title("система 2");
        grafik2.XLabel("x1");
        grafik2.YLabel("x2");
        grafik2.Axes.SetLimits(0, 10, 0, 8);
        grafik2.SavePng(Path.Combine(papka, "zadanie_b.png"), 600, 600);

        Console.WriteLine("готово, картинки на рабочем столе");
    }
}