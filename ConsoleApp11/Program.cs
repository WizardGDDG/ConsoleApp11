using ScottPlot;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string d = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        Plot p1 = new Plot();
        for (double x = 0; x <= 6; x += 0.1)
        for (double y = 0; y <= 6; y += 0.1)
        if (x + 3*y >= 3 && 2*x + y <= 2 && x + y <= 5)
            p1.Add.Marker(x, y).Color = Colors.Green.WithAlpha(0.2);
        
        double[] t = {0,1,2,3,4,5,6};
        p1.Add.Scatter(t, t.Select(v => (3-v)/3).ToArray()).Color = Colors.Red;
        p1.Add.Scatter(t, t.Select(v => 2-2*v).ToArray()).Color = Colors.Blue;
        
        p1.Axes.SetLimits(0,6,0,6);
        p1.SavePng(System.IO.Path.Combine(d,"a.png"),600,600);

        Plot p2 = new Plot();
        for (double x = 0; x <= 10; x += 0.1)
        for (double y = 0; y <= 8; y += 0.1)
        if (-x + 3*y <= 9 && 2*x + 3*y <= 18 && 2*x - y <= 10)
            p2.Add.Marker(x, y).Color = Colors.Green.WithAlpha(0.2);
        
        double[] s = {0,2,4,6,8,10};
        p2.Add.Scatter(s, s.Select(v => (9+v)/3).ToArray()).Color = Colors.Red;
        p2.Add.Scatter(s, s.Select(v => (18-2*v)/3).ToArray()).Color = Colors.Blue;
        
        p2.Axes.SetLimits(0,10,0,8);
        p2.SavePng(System.IO.Path.Combine(d,"b.png"),600,600);
        
        Console.WriteLine("ok");
    }
}
