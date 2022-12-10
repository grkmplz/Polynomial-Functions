using System;


namespace Polynomial_Functions
{
    class MainFunctions
    {
        public double[,] GetNumber = new double[5, 5];
        public double[,] Linear_Equ = new double[5, 5];
        public double[] Rootval = new double[5];
        public double[] LinVal = new double[5];

        public double EPSILON = 0.001;
        public float InitVal = 2;

        public  int row_seq = 0;
        public  int equation = 1;

        public void AddEquation()
        {
            double numb;
            while (true)
            {
                Console.Write($"Equation {equation}: ");
                string getinput = Console.ReadLine();
                string[] numberlist = getinput.Split(' ');
                if (getinput.ToLower() == "end")
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < numberlist.Length; i++)
                    {
                        string _numbers = numberlist[i];
                        double.TryParse(_numbers, out numb);
                        GetNumber[row_seq, i] = numb;
                    }
                    row_seq++;
                    equation++;
                }
            }
        }
        public void Convert_To_Linear_Equation()
        {
            double number;
            // I want to change (x,y) to x^2 + x^1 + 1 = y
            for (int r = 0; r < row_seq; r++)
            {
                for (int c = 0; c < 1; c++)
                {
                    number = GetNumber[r, c];
                    Linear_Equ[r, 0] = Math.Pow(number, 2);
                    Linear_Equ[r, 1] = number;
                    Linear_Equ[r, 2] = 1;
                    Linear_Equ[r, 3] = GetNumber[r, 1];
                }
            }
        }
        public void Gaussian_Elimination_Formula(double[,] mat)
        {


            int singular_flag = ForwardElim(mat);


            if (singular_flag != -1)
            {
                Console.WriteLine("Singular Matrix.");


                if (mat[singular_flag, row_seq] != 0)
                    Console.Write("Inconsistent System.");
                else
                    Console.Write("Might have infinitely " +
                                  "much solutions.");

                return;
            }


            back_sub(mat);
        }
        public void SwapRow(double[,] mat, int i, int j)
        {
            for (int k = 0; k <= row_seq; k++)
            {
                double temp = mat[i, k];
                mat[i, k] = mat[j, k];
                mat[j, k] = temp;
            }
        }
        public int ForwardElim(double[,] mat)
        {
            for (int k = 0; k < row_seq; k++)
            {
                int i_max = k;
                int v_max = (int)mat[i_max, k];
                for (int i = k + 1; i < row_seq; i++)
                {
                    if (Math.Abs(mat[i, k]) > v_max)
                    {
                        v_max = (int)mat[i, k];
                        i_max = i;
                    }


                    if (mat[k, i_max] == 0)
                        return k;



                    if (i_max != k)
                        SwapRow(mat, k, i_max);

                    for (int z = k + 1; z < row_seq; z++)
                    {
                        double f = mat[i, k] / mat[k, k];


                        for (int j = k + 1; j <= row_seq; j++)
                            mat[i, j] -= mat[k, j] * f;


                        mat[i, k] = 0;
                    }
                }

            }


            return -1;
        }
        public void back_sub(double[,] mat)
        {
            double[] x = new double[row_seq];
            for (int i = row_seq - 1; i >= 0; i--)
            {
                x[i] = mat[i, row_seq];
                for (int j = i + 1; j < row_seq; j++)
                {
                    x[i] -= mat[i, j] * x[j];
                }
                x[i] = x[i] / mat[i, i];
            }
            Console.WriteLine(" ");
            Console.WriteLine("Calculated Polynominal: ");
            Console.WriteLine(" ");
            Console.Write("f(x)");
            for (int i = 0; i < row_seq; i++)
            {
                if (i == 2)
                {
                    Console.Write(" {0:F5}", x[i]);
                }
                else
                {
                    Console.Write(" {0:F5}", x[i]);
                    Console.Write($"x^{row_seq - i - 1}");
                }
            }
            x.CopyTo(Rootval, 0);
            x.CopyTo(LinVal, 0);
        }
        public void PickValRoot(double[] x)
        {
            Console.WriteLine(" ");
            double fMinusOne = (x[0] * Math.Pow(-1, 2)) + (x[1] * -1) + (x[2]);
            Console.WriteLine("f(-1) = " + " {0:F5}", fMinusOne);
            double zeroValue = (x[0] * Math.Pow(0, 2)) + (x[1] * 0) + (x[2]);
            Console.WriteLine("f(0) = " + " {0:F5}", zeroValue);
            double fForOne = (x[0] * Math.Pow(1, 2)) + (x[1] * 1) + (x[2]);
            Console.WriteLine("f(1) = " + " {0:F5}", fForOne);
        }
        public void DerivativeOfFunction(double[] func)
        {
            for (int i = 0; i < row_seq; i++)
            {
                if (i == 0)
                {
                    func[0] = func[0] * (row_seq - 1);
                }
                if (i == 1)
                {
                    func[1] = func[1] * (row_seq - 2);
                }
                if (i == 2)
                {
                    func[2] = func[2] * (row_seq - 3);
                }
            }
            Console.WriteLine(" ");
            Console.Write("f'(x) =");
            for (int i = 0; i < row_seq - 1; i++)
            {
                if (i != row_seq - 2)
                {
                    Console.Write(" {0:F5}", func[i]);
                    Console.Write($"x^{row_seq - 2}");
                }
                else
                {
                    Console.Write(" {0:F5}", func[i]);
                }
            }
            Console.WriteLine(" ");
        }
    }
}
