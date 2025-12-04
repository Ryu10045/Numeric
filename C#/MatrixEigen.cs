namespace LinearAlgebra;

public partial class Matrix
{
    //べき乗法
    public static void PowerMethod(Matrix A, CVector x0, double err)
    {
        CVector v = new CVector(A.Rows);
        double lambda = 0;
        do
        {
            v = A * x0;
            lambda = x0.Transpose() * v;
            x0 = v * (1 / v.Norm2());
        } while (Math.Abs(v.Norm2() * v.Norm2() - lambda * lambda) >= err);

        Console.WriteLine("行列" + A.ToString());
        Console.WriteLine($"の絶対値最大の固有値は, {lambda}");
        Console.WriteLine("また, これに対応する固有ベクトルは, \n" + x0.ToString());
    }
}