using System;


namespace Polynomial_Functions
{
    class Root_Manager : MainFunctions
    {
        public void Newton_Raphson(double x)
        {
            double h = Func(x) / Derrivative_Func(x);
            while (Math.Abs(h) >= EPSILON)
            {
                h = Func(x) / Derrivative_Func(x);
                x = x - h;
            }
            Console.WriteLine(" \n");
            Console.WriteLine("==> The value of the root is :" + Math.Round(x * 100.0) / 100.0);
            Console.WriteLine(" ");
        }
        public double Func(double x)
        {
            return Math.Round(LinVal[0] * x * x + LinVal[1] * x + LinVal[2],6);
        }
        public double Derrivative_Func(double x)
        {
            return Math.Round((Rootval[0] * x + Rootval[1]), 6);
        }
    }
}
