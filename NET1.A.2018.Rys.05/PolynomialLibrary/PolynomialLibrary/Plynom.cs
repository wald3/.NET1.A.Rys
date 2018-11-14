using System;

namespace PolynomialLibrary
{
    public class Polynom : IEquatable<Polynom>, ICloneable
    {
        private int _degree;
        private double[] _coeffs;

        public Polynom(params double[] coeffs)
        {
            this._coeffs = coeffs ?? throw new ArgumentNullException(nameof(coeffs));
        }

        

        public static bool operator !=(Polynom polyA, Polynom polyB)
        {
            return !(polyA == polyB);
        }

        public static bool operator ==(Polynom polyA, Polynom polyB)
        {
            if (ReferenceEquals(polyA, null))
            {
                return ReferenceEquals(polyB, null);
            }

            return polyA._coeffs.Equals(polyB._coeffs);
        }
                
        
        public bool Equals(Polynom other)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var poly = obj as Polynom;

            if (ReferenceEquals(poly, null))
            {
                return false;
            }

            return GetHashCode().Equals(poly.GetHashCode());
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
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.ToString();
        }


    }
}
