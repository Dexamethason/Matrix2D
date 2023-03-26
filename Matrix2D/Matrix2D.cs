using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        public int A { get; init; }
        public int B { get; init; }
        public int C { get; init; }
        public int D { get; init; }

        public static  Matrix2D Zero { get; } = new (0,0,0,0);
        public static  Matrix2D Id { get; } = new ();

        public Matrix2D(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Matrix2D() : this(1,0,0,1)
        {

        }

        public override string ToString() => $"[[{A}, {B}], [{C}, {D}]] ";

        public bool Equals(Matrix2D? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other)) return true;
            return A == other.A &&
                B == other.B &&
                C == other.C &&
                D == other.D;
        }
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Matrix2D) return false;
            return Equals(obj as Matrix2D);
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C, D);

        public static bool operator ==(Matrix2D? left, Matrix2D? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Matrix2D? left, Matrix2D? right)
        {
            return !(left == right);
        }
        public static Matrix2D operator +(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(m1.A + m2.A, m1.B + m2.B, m1.C + m2.C, m1.D + m2.D);
            /*
             return new (left.A + right.A,
                         left.B + right.B,
                         left.C + right.C,
                         left.D + right.D);
             */
        }
        public static Matrix2D operator -(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(m1.A - m2.A, m1.B - m2.B, m1.C - m2.C, m1.D - m2.D);
        }
        public static Matrix2D operator *(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(m1.A * m2.A + m1.B * m2.C,
                                m1.A * m2.B + m1.B * m2.D,
                                m1.C * m2.A + m1.D * m2.C,
                                m1.C * m2.B + m1.D * m2.D);
        }
        public static Matrix2D Parse(string s)
        {
            var a = s.Split(new string[] { "[", "]", "[", "]", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            return new Matrix2D(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), int.Parse(a[3]));
        }

    }
}
