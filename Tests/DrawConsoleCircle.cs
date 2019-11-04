using System;
using Figgle;

namespace hackertests.Tests
{
    public class DrawConsoleCircle : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.DrawConsoleCircle;
        }

        public void RunTests()
        {
            System.Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("Drawing Curve "));
            for (int i = 0; i < 360; i += 10)
            {
                int xd = (int)Math.Round(10 * Math.Cos((double)(0.017453m * i)));
                int yd = (int)Math.Round(10 * Math.Sin((double)(0.017453m * i)));
                int x = 50 + xd;
                int y = 50 + yd ;//+ (int)Math.Round((double)i / 20);
                System.Console.SetCursorPosition(x, y);
                System.Console.Write(".");
                // System.Console.Write($"xy = {x},{y} ");
            }
        }
    }
}