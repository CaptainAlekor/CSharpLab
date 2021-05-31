using System;
using System.Linq;
using System.Text;

namespace LR7
{
    class Fraction : IComparable
    {
        int numerator = 0;
        int denominator = 1;

        public Fraction() { }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new Exception("Denominator cannot be equal to zero");
            this.numerator = numerator;
            this.denominator = denominator;
            this.Simplify();
        }

        public int Numerator { get { return numerator; } }
        public int Denominator { get { return denominator; } }

        public static explicit operator int(Fraction fraction)
        {
            double result = (double)fraction.numerator / (double)fraction.denominator;
            return (int)Math.Round(result, MidpointRounding.AwayFromZero);
        }
        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.numerator / (double)fraction.denominator;
        }
        public static Fraction operator +(Fraction first, Fraction second)
        {
            int resultNumerator = first.numerator * second.denominator + second.numerator * first.denominator;
            int resultDenominator = first.denominator * second.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }
        public static Fraction operator -(Fraction first, Fraction second)
        {
            int resultNumerator = first.numerator * second.denominator - second.numerator * first.denominator;
            int resultDenominator = first.denominator * second.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }
        public static Fraction operator *(Fraction first, Fraction second)
        {
            return new Fraction(first.numerator * second.numerator, first.denominator * second.denominator);
        }
        public static Fraction operator /(Fraction first, Fraction second)
        {
            if (second.numerator == 0) throw new Exception("Division by zero is prohibited");
            else
            {
                return new Fraction(first.numerator * second.denominator, first.denominator * second.numerator);
            }
        }
        public static bool operator >(Fraction first, Fraction second)
        {
            Fraction subtraction = first - second;
            if (subtraction.numerator > 0) return true;
            else return false;
        }
        public static bool operator <(Fraction first, Fraction second)
        {
            Fraction subtraction = second - first;
            if (subtraction.numerator > 0) return true;
            else return false;
        }
        public static bool operator >=(Fraction first, Fraction second)
        {
            Fraction subtraction = first - second;
            if (subtraction.numerator >= 0) return true;
            else return false;
        }
        public static bool operator <=(Fraction first, Fraction second)
        {
            Fraction subtraction = second - first;
            if (subtraction.numerator >= 0) return true;
            else return false;
        }
        public static bool operator ==(Fraction first, Fraction second)
        {
            if (first.numerator == second.numerator && first.denominator == second.denominator) return true;
            else return false;
        }
        public static bool operator !=(Fraction first, Fraction second)
        {
            if (first.numerator == second.numerator && first.denominator == second.denominator) return false;
            else return true;
        }

        private void Simplify()
        {
            int p = this.numerator;
            int q = this.denominator;
            int r;
            while (true)
            {
                r = p - (p / q) * q;
                if (r == 0) break;
                else
                {
                    p = q;
                    q = r;
                }
            }
            if (q != 1)
            {
                this.numerator /= q;
                this.denominator /= q;
            }
            if (this.denominator < 0)
            {
                this.denominator *= -1;
                this.numerator *= -1;
            }
        }
        public int CompareTo(object o)
        {
            Fraction fo = o as Fraction;
            if (this > fo) return 1;
            else if (this < fo) return -1;
            else return 0;
        }
        public override bool Equals(object o)
        {
            Fraction fo = o as Fraction;
            if (this == fo) return true;
            else return false;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.numerator);
            result.Append('/');
            result.Append(this.denominator);
            return result.ToString();
        }
        public string ToSpecialString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.numerator);
            result.Append('*');
            result.Append(this.denominator);
            result.Append("^(-1)");
            return result.ToString();
        }
        public void ConvertToFraction(string input)
        {
            StringBuilder strbuilder = new StringBuilder(input);
            bool error = false;
            int num = 0, denom = 1;
            do
            {
                if (error)
                {
                    Console.WriteLine("Invalid input. Possible formats:\n<number>/<number>\n-<number>/<number>\n<number>\n\nTry again: ");
                    strbuilder.Clear();
                    strbuilder.Append(Console.ReadLine());
                }
                error = false;
                string[] constituents = strbuilder.ToString().Split('/');
                if (constituents.Length == 1)
                {
                    denom = 1;
                    bool result = int.TryParse(strbuilder.ToString(), out num);
                    if (!result) error = true;
                }
                else if (constituents.Length == 2)
                {
                    bool result = int.TryParse(constituents[0].ToString(), out num);
                    if (!result) error = true;
                    result = int.TryParse(constituents[1].ToString(), out denom);
                    if (!result || denom == 0) error = true;
                }
                else error = true;
            } while (error);
            this.numerator = num;
            this.denominator = denom;
            this.Simplify();
        }
    }
}