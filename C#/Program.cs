using System;
using System.Linq;
using Numeric;

using LinearAlgebra;
namespace Numeric;

public static class Program
{
    public static void Main()
    {
        var va = new CVector([1, 2, 3]);
        var vb = new RVector([3, 6, 9]);
        double[,] source = new double[,]
        {
            {2,4,6},
            {3,6,9},
            {4,8,12}
        };
        var m = new Matrix(source);
        Console.WriteLine((vb * m).ToString());
    }
}

