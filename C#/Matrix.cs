namespace LinearAlgebra
{
    public class Matrix
    {
        double[] data;
        public int Rows { get; }
        public int Cols { get; }

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            data = new double[Rows * Cols];
        }

        public Matrix(double[,] source)
        {
            this.Rows = source.GetLength(0);
            this.Cols = source.GetLength(1);
            data = new double[Rows * Cols];

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.data[i * this.Rows + j] = source[i, j];
                }
            }
        }

        public double this[int i, int j]
        {
            get { return data[i * this.Rows + j]; }
            set { data[i * this.Rows + j] = value; }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new Exception("Matrix size non-compatible");
            }
            var result = new Matrix(a.Rows, a.Cols);
            for (int r = 0; r < a.Rows; r++)
            {
                for (int c = 0; c < a.Cols; c++)
                {
                    result[r, c] = a[r, c] + b[r, c];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m)
        {
            var result = new Matrix(m.Rows, m.Cols);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = -m[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new Exception("Matrix size non-compatible");
            }
            var result = new Matrix(a.Rows, a.Cols);
            for (int r = 0; r < a.Rows; r++)
            {
                for (int c = 0; c < a.Cols; c++)
                {
                    result[r, c] = a[r, c] - b[r, c];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new Exception("Matrix size no-compatible");
            }
            var result = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(double a, Matrix m)
        {
            var result = new Matrix(m.Rows, m.Cols);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = a * m[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m, double a)
        {
            return a * m;
        }

        public override string ToString()
        {
            string result = "";
            for (int r = 0; r < this.Rows; r++)
            {
                for (int c = 0; c < this.Cols; c++)
                {
                    result += this[r, c] + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}