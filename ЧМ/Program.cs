using System;

namespace ЧМ
{
    class Program
    {
        static void Main(string[] args)
        {
            double xn = 1;
            double fx = 0;
            double fxx = 0;
            double resulting;
            Console.Write("Введите количество переменных: ");
            int mode = 0;
            int z = 0;
            int n = (Convert.ToInt32(Console.ReadLine()) * 3) - 1;
            string[] expr = new string[n];
            for (int i = 0; i < expr.Length; i++)
            {
                if (mode == 0)
                {
                    Console.Write("Введите число: ");
                    expr[i] = Console.ReadLine();
                    mode = 1;
                    continue;
                }
                if (mode == 1)
                {
                    Console.Write("Введите степень икса: ");
                    expr[i] = Console.ReadLine();
                    mode = 2;
                    continue;
                }
                if (mode == 2)
                {
                    Console.Write("Введите знак: ");
                    expr[i] = Console.ReadLine();
                    mode = 0;
                    continue;
                }
            }
            for (int j = 0; j < expr.Length - 1; j++) { if (j % 3 == 1 && expr[j + 1] != "0") { Console.Write("x^"); } if (expr[j] != "0") { Console.Write(expr[j]); } }
            Console.Read();
            while (true)
            {
                mode = 0;
                while (z != expr.Length)
                {
                    if (mode == 0)
                    {
                        fx += int.Parse(expr[z]) * Math.Pow(xn, int.Parse(expr[z + 1]));
                        mode = 1;
                    }
                    z += 2;
                    if (z <= expr.Length - 1)
                    {
                        if (expr[z] == "+")
                        {
                            z += 1;
                            fx += int.Parse(expr[z]) * Math.Pow(xn, int.Parse(expr[z + 1]));
                        }
                        if (expr[z] == "-")
                        {
                            z += 1;
                            fx -= int.Parse(expr[z]) * Math.Pow(xn, int.Parse(expr[z + 1]));
                        }
                    }
                }
                Console.WriteLine("f(xn) " + fx);
                z = 0;
                string[] exprproiz = new string[n];
                while (z != expr.Length)
                {
                    exprproiz[z] = Convert.ToString(int.Parse(expr[z]) * int.Parse(expr[z + 1]));
                    z++;
                    if (int.Parse(expr[z]) != 0)
                    {
                        exprproiz[z] = Convert.ToString(int.Parse(expr[z]) - 1);
                    }
                    z++;
                    if (z != expr.Length)
                    {
                        exprproiz[z] = expr[z];
                        z++;
                    }
                    else break;
                }
                z = 0; mode = 0;
                for (int i = 0; i < exprproiz.Length; i++)
                {
                    if (exprproiz[i] == null)
                    {
                        exprproiz[exprproiz.Length - 1] = "0";
                    }
                }
                while (z != exprproiz.Length)
                {
                    if (mode == 0)
                    {
                        fxx += int.Parse(exprproiz[z]) * Math.Pow(xn, int.Parse(exprproiz[z + 1]));
                        mode = 1;
                    }
                    z += 2;
                    if (z <= exprproiz.Length - 1)
                    {
                        if (exprproiz[z] == "+")
                        {
                            z += 1;
                            fxx += int.Parse(exprproiz[z]) * Math.Pow(xn, int.Parse(exprproiz[z + 1]));
                        }
                        if (exprproiz[z] == "-")
                        {
                            z += 1;
                            fxx -= int.Parse(exprproiz[z]) * Math.Pow(xn, int.Parse(exprproiz[z + 1]));
                        }
                    }
                }
                Console.WriteLine("f'(xn) " + fxx);
                resulting = fx / fxx;
                Console.WriteLine("f(xn) / f'(xn) " + resulting);
                if (resulting > 0.001)
                {
                    xn -= resulting;
                    fx = 0; fxx = 0; mode = 0; z = 0;
                }
                else { Console.WriteLine("Результат найден: " + resulting); break; }
            }
        }
    }
}
