namespace LinearAlgebra;

public class CVector
{
    double[] data;
    public int size { get; }
    public int Rows { get; }
    public int Cols { get; }
    public CVector(int size)
    {
        this.size = size;
        this.Rows = 1;
        this.Cols = size;
        data = new double[size];
    }

    public CVector(double[] source)
    {
        this.size = source.Length;
        this.Rows = 1;
        this.Cols = size;
        data = new double[size];

        for (int i = 0; i < this.size; i++)
        {
            data[i] = source[i];
        }
    }

    public double this[int i]
    {
        get { return this.data[i]; }
        set { this.data[i] = value; }
    }

    public static CVector operator +(CVector v1, CVector v2)
    {
        if (v1.size != v2.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        var result = new CVector(v1.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = v1[i] + v2[i];
        }

        return result;
    }

    public static CVector operator -(CVector v)
    {
        var result = new CVector(v.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = -v[i];
        }

        return result;
    }

    public static CVector operator -(CVector v1, CVector v2)
    {
        if (v1.size != v2.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        var result = new CVector(v1.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = v1[i] - v2[i];
        }

        return result;
    }

    public static CVector operator *(double k, CVector v)
    {
        var result = new CVector(v.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = k * v[i];
        }

        return result;
    }

    public static CVector operator *(CVector v, double k)
    {
        return k * v;
    }

    public static CVector operator /(CVector v, double k)
    {
        if (k == 0)
        {
            throw new Exception("Cannot devide by zero");
        }

        CVector result = new CVector(v.size);
        for (int i = 0; i < v.size; i++) result[i] = v[i] / k;

        return result;
    }

    public static Matrix operator *(CVector cv, RVector rv)
    {
        Matrix result = new Matrix(cv.size, rv.size);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Cols; j++)
            {
                result[i, j] = cv[i] * rv[j];
            }
        }

        return result;
    }

    public static CVector operator *(Matrix m, CVector v)
    {
        if (m.Cols != v.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        CVector result = new CVector(m.Rows);

        for (int i = 0; i < m.Rows; i++)
        {
            for (int j = 0; j < m.Cols; j++)
            {
                result[i] += m[i, j] * v[j];
            }
        }

        return result;
    }

    /// <summary>
    /// y = y + k*x
    /// </summary>
    /// <param name="k"></param>
    /// <param name="x"></param>
    public void Axpy(double k, CVector x)
    {
        if (this.size != x.size)
        {
            throw new Exception("size no-compatible");
        }

        for (int i = 0; i < this.size; i++)
        {
            this[i] += k * x[i];
        }
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < this.size; i++)
        {
            result += $"{data[i]}\n";
        }

        return result;
    }
}

public class RVector
{
    double[] data;
    public int size { get; }
    public int Rows { get; }
    public int Cols { get; }
    public RVector(int size)
    {
        this.size = size;
        this.Rows = size;
        this.Cols = 1;
        data = new double[size];
    }

    public RVector(double[] source)
    {
        this.size = source.Length;
        this.Rows = size;
        this.Cols = 1;
        data = new double[size];

        for (int i = 0; i < this.size; i++)
        {
            data[i] = source[i];
        }
    }

    public double this[int i]
    {
        get { return this.data[i]; }
        set { this.data[i] = value; }
    }

    public static RVector operator +(RVector v1, RVector v2)
    {
        if (v1.size != v2.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        var result = new RVector(v1.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = v1[i] + v2[i];
        }

        return result;
    }

    public static RVector operator -(RVector v)
    {
        var result = new RVector(v.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = -v[i];
        }

        return result;
    }

    public static RVector operator -(RVector v1, RVector v2)
    {
        if (v1.size != v2.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        var result = new RVector(v1.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = v1[i] - v2[i];
        }

        return result;
    }

    public static RVector operator *(double k, RVector v)
    {
        var result = new RVector(v.size);

        for (int i = 0; i < result.size; i++)
        {
            result[i] = k * v[i];
        }

        return result;
    }

    public static RVector operator *(RVector v, double k)
    {
        return k * v;
    }

    public static RVector operator /(RVector v, double k)
    {
        if (k == 0)
        {
            throw new Exception("Cannot devide by zero");
        }

        RVector result = new RVector(v.size);
        for (int i = 0; i < v.size; i++) result[i] = v[i] / k;

        return result;
    }

    public static double operator *(RVector rv, CVector cv)
    {
        if (cv.size != rv.size)
        {
            throw new Exception("Matrix size no-compatible");
        }

        double result = 0;

        for (int i = 0; i < rv.size; i++)
        {
            result += rv[i] * cv[i];
        }

        return result;
    }

    public static RVector operator *(RVector v, Matrix m)
    {
        if (v.size != m.Rows)
        {
            throw new Exception("Matrix size no-compatible");
        }

        RVector result = new RVector(m.Cols);

        for (int i = 0; i < result.size; i++)
        {
            for (int j = 0; j < v.size; j++)
            {
                result[i] += v[j] * m[j, i];
            }
        }

        return result;
    }

    /// <summary>
    /// y = y + k*x (ベクトルに他のベクトルのスカラー倍を足す)
    /// 直接書き換えるので省メモリ
    /// </summary>
    /// <param name="k"></param>
    /// <param name="x"></param>
    public void Axpy(double k, RVector x)
    {
        if (this.size != x.size)
        {
            throw new Exception("size no-compatible");
        }

        for (int i = 0; i < this.size; i++)
        {
            this[i] += k * x[i];
        }
    }
    /// <summary>
    /// vとの内積を返す
    /// </summary>
    /// <param name="v"></param>
    public double Dot(CVector v)
    {
        if (this.size != v.size)
        {
            throw new Exception("size no-compatible");
        }

        double result = 0;
        for (int i = 0; i < this.size; i++)
        {
            result += this[i] * v[i];
        }

        return result;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < this.size; i++)
        {
            result += $"{data[i]} ";
        }

        return result;
    }
}

public static class VectorExtensions
{
    public static RVector Transpose(this CVector v)
    {
        var result = new RVector(v.size);

        for (int i = 0; i < v.size; i++)
        {
            result[i] = v[i];
        }

        return result;
    }

    public static CVector Transpose(this RVector v)
    {
        var result = new CVector(v.size);

        for (int i = 0; i < v.size; i++)
        {
            result[i] = v[i];
        }

        return result;
    }

    public static double Norm1(this CVector v)
    {
        double result = 0;

        for (int i = 0; i < v.size; i++)
        {
            result += Math.Abs(v[i]);
        }

        return result;
    }

    public static double Norm1(this RVector v)
    {
        double result = 0;

        for (int i = 0; i < v.size; i++)
        {
            result += Math.Abs(v[i]);
        }

        return result;
    }

    public static double Norm2(this CVector v)
    {
        double result = 0;

        for (int i = 0; i < v.size; i++)
        {
            result += v[i] * v[i];
        }

        return Math.Sqrt(result);
    }

    public static double Norm2(this RVector v)
    {
        double result = 0;

        for (int i = 0; i < v.size; i++)
        {
            result += v[i] * v[i];
        }

        return Math.Sqrt(result);
    }

    public static double NormMax(this CVector v)
    {
        double result = Math.Abs(v[0]);

        for (int i = 1; i < v.size; i++)
        {
            if (result < Math.Abs(v[i])) result = Math.Abs(v[i]);
        }

        return result;
    }

    public static double NormMax(this RVector v)
    {
        double result = Math.Abs(v[0]);

        for (int i = 1; i < v.size; i++)
        {
            if (result < Math.Abs(v[i])) result = Math.Abs(v[i]);
        }

        return result;
    }
}