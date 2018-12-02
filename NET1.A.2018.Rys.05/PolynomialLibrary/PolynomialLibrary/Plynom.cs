using System;
using System.Text;

namespace PolynomialLibrary
{
    public class Polynom : IEquatable<Polynom>, ICloneable
    {
        public readonly int degree;
        private double[] _coeffs;
        public static double accuracy = 0.0001d;

        public Polynom(params double[] coeffs)
        {
            this._coeffs = coeffs ?? throw new ArgumentNullException(nameof(coeffs));
            this.degree = _coeffs.Length;
        }

        public static Polynom operator *(Polynom poly, int factor)
        {
            var resultPoly = (Polynom)poly.Clone();

            for(var i = 0; i < resultPoly.degree; i++)
            {
                resultPoly._coeffs[i] *= factor;
            }

            return resultPoly;
        }

        public static Polynom operator *(int factor, Polynom poly)
        {
            return poly * factor;
        }

        public static Polynom operator /(Polynom poly, int factor)
        {
            var resultPoly = (Polynom)poly.Clone();

            for (var i = 0; i < resultPoly.degree; i++)
            {
                resultPoly._coeffs[i] /= factor;
            }

            return resultPoly;
        }

        public static Polynom operator +(Polynom polyFirst, Polynom polySecond)
        {
            Polynom maxPoly, minPoly;

            if(polyFirst.degree >= polySecond.degree)
            {
                maxPoly = polyFirst;
                minPoly = polySecond;
            }
            else
            {
                maxPoly = polySecond;
                minPoly = polyFirst;
            }

            var resultPoly = (double[]) maxPoly._coeffs.Clone();

            for (int i = 0; i < minPoly.degree; i++)
            {
                resultPoly[i] += minPoly[i];    
            }
            return new Polynom(resultPoly);
        }

        public static Polynom operator +(Polynom poly, int addend)
        {
            var resultPoly = (double[])poly._coeffs.Clone();

            for (var i = 0; i < poly.degree; i++)
            {
                resultPoly[i] += addend;
            }
            return new Polynom(resultPoly);
        }

        public static Polynom operator -(Polynom polyFirst, Polynom polySecond)
        {
            Polynom maxPoly, minPoly;

            if (polyFirst.degree >= polySecond.degree)
            {
                maxPoly = polyFirst;
                minPoly = polySecond;
            }
            else
            {
                maxPoly = polySecond;
                minPoly = polyFirst;
            }

            var resultPoly = (double[])maxPoly._coeffs.Clone();

            for (int i = 0; i < minPoly.degree; i++)
            {
                resultPoly[i] -= minPoly[i];
            }
            return new Polynom(resultPoly);
        }

        public static Polynom operator -(Polynom poly, int subtrahend)
        {
            return poly + -subtrahend;
        }

        public static bool operator !=(Polynom polyA, Polynom polyB)
        {
            return !(polyA == polyB);
        }

        public static bool operator ==(Polynom polyFirst, Polynom polySecond)
        {
            if (ReferenceEquals(polyFirst, null))
            {
                return ReferenceEquals(polySecond, null);
            }

            return polyFirst.Equals(polySecond);
        }         
        
        public bool Equals(Polynom other)
        {
            if (this.degree != other.degree) return false;

            for (var i = 0; i < this.degree; i++)
            {
                if (Math.Abs(this._coeffs[i] - other._coeffs[i]) - accuracy > 0) return false;
            }

            return true;
        }

        public object Clone()
        {
            return new Polynom(this._coeffs);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Polynom poly = obj as Polynom;

            if (ReferenceEquals(poly, null)) return false;

            return this.Equals(poly);
        }
         
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _coeffs.Length)
                    throw new ArgumentOutOfRangeException();
                return _coeffs[index];
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");

            foreach (var coef in this._coeffs)
            {
                sb.Append(coef + ", ");
            }
            sb.Remove(sb.Length - 2, 2).Append(']');

            return sb.ToString();
        }
    }
}
