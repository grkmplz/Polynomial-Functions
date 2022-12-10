using System;

namespace Polynomial_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            string srvtinput;
            
            do{

            Console.Clear();
            Console.WriteLine("Please input points in order of x and y pattern.");
            Console.WriteLine("To complete type END.");
            Root_Manager root_manager = new Root_Manager();
          
            double[,] Linear_Equ = root_manager.Linear_Equ;
            double[] Rootval = root_manager.Rootval;
            double InitVal = root_manager.InitVal;
            
            root_manager.AddEquation();
            root_manager.Convert_To_Linear_Equation();
            root_manager.Gaussian_Elimination_Formula(Linear_Equ);
            root_manager.PickValRoot(Rootval);
            root_manager.DerivativeOfFunction(Rootval);
            root_manager.Newton_Raphson(InitVal);

            Console.WriteLine("type any to continue.. or exit");
            srvtinput = Console.ReadLine();
            
            } while (srvtinput != "exit");
        }
    }
}

