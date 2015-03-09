using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public struct FractionBig : IEquatable<FractionBig>
    {
        
            BigInteger _numerator;
            public BigInteger Numerator
            {
                get { return _numerator; }
                private set { _numerator = value; }
            }

            BigInteger _denominator;
            public BigInteger Denominator
            {
                get { return _denominator == 0 ? 1 : _denominator; }
                private set
                {
                    if (value == 0)
                        throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");

                    _denominator = value;
                }
            }

            public FractionBig(BigInteger value)
            {
                _numerator = value;
                _denominator = 1;
                Reduce();
            }
            public FractionBig(BigInteger numerator, BigInteger denominator)
            {
                if (denominator == 0)
                    throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");

                _numerator = numerator;
                _denominator = denominator;
                Reduce();
            }


            private void Reduce()
            {
                try
                {
                    if (Numerator == 0)
                    {
                        Denominator = 1;
                        return;
                    }

                    BigInteger iGCD = GCD(Numerator, Denominator);
                    Numerator /= iGCD;
                    Denominator /= iGCD;

                    if (Denominator < 0)
                    {
                        Numerator *= -1;
                        Denominator *= -1;
                    }
                }
                catch (Exception exp)
                {
                    throw new InvalidOperationException("Cannot reduce FractionBig: " + exp.Message);
                }
            }

            public bool Equals(FractionBig other)
            {
                if (other == null)
                    return false;

                return (Numerator == other.Numerator && Denominator == other.Denominator);
            }
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is FractionBig))
                    return false;

                return Equals((FractionBig)obj);
            }
            public int CompareTo(FractionBig other)
            {
                if (other == null)
                    return -1;
                return this == other ? 0 : this > other ? 1 : -1;
            }
            public int CompareTo(object obj)
            {
                if (obj == null || !(obj is FractionBig))
                    return -1;
                return CompareTo((FractionBig)obj);
            }
            public override int GetHashCode()
            {
                return Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF);
            }
            public override string ToString()
            {
                if (this.Denominator == 1)
                    return this.Numerator.ToString();

                var sb = new System.Text.StringBuilder();
                sb.Append(this.Numerator);
                sb.Append('/');
                sb.Append(this.Denominator);

                return sb.ToString();
            }

            public static FractionBig Parse(string strValue)
            {
                int i = strValue.IndexOf('/');
                if (i == -1)
                    return DecimalToFraction(Convert.ToDecimal(strValue));

                BigInteger iNumerator = Convert.ToInt64(strValue.Substring(0, i));
                BigInteger iDenominator = Convert.ToInt64(strValue.Substring(i + 1));
                return new FractionBig(iNumerator, iDenominator);
            }
            public static bool TryParse(string strValue, out FractionBig FractionBig)
            {
                if (!string.IsNullOrWhiteSpace(strValue))
                {
                    try
                    {
                        int i = strValue.IndexOf('/');
                        if (i == -1)
                        {
                            decimal dValue;
                            if (decimal.TryParse(strValue, out dValue))
                            {
                                FractionBig = DecimalToFraction(dValue);
                                return true;
                            }
                        }
                        else
                        {
                            BigInteger iNumerator, iDenominator;
                            if (BigInteger.TryParse(strValue.Substring(0, i), out iNumerator) && BigInteger.TryParse(strValue.Substring(i + 1), out iDenominator))
                            {
                                FractionBig = new FractionBig(iNumerator, iDenominator);
                                return true;
                            }
                        }
                    }
                    catch { }
                }

                FractionBig = new FractionBig();
                return false;
            }

            private static FractionBig DoubleToFraction(double dValue)
            {
                char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                try
                {
                    checked
                    {
                        FractionBig frac;
                        if (dValue % 1 == 0)    // if whole number
                        {
                            frac = new FractionBig((BigInteger)dValue);
                        }
                        else
                        {
                            double dTemp = dValue;
                            BigInteger iMultiple = 1;
                            string strTemp = dValue.ToString();
                            while (strTemp.IndexOf("E") > 0)    // if in the form like 12E-9
                            {
                                dTemp *= 10;
                                iMultiple *= 10;
                                strTemp = dTemp.ToString();
                            }
                            int i = 0;
                            while (strTemp[i] != separator)
                                i++;
                            int iDigitsAfterDecimal = strTemp.Length - i - 1;
                            while (iDigitsAfterDecimal > 0)
                            {
                                dTemp *= 10;
                                iMultiple *= 10;
                                iDigitsAfterDecimal--;
                            }
                            frac = new FractionBig((int)Math.Round(dTemp), iMultiple);
                        }
                        return frac;
                    }
                }
                catch (OverflowException e)
                {
                    throw new InvalidCastException("Conversion to FractionBig in no possible due to overflow.", e);
                }
                catch (Exception e)
                {
                    throw new InvalidCastException("Conversion to FractionBig in not possible.", e);
                }
            }
            private static FractionBig DecimalToFraction(decimal dValue)
            {
                char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                try
                {
                    checked
                    {
                        FractionBig frac;
                        if (dValue % 1 == 0)    // if whole number
                        {
                            frac = new FractionBig((BigInteger)dValue);
                        }
                        else
                        {
                            decimal dTemp = dValue;
                            BigInteger iMultiple = 1;
                            string strTemp = dValue.ToString();
                            while (strTemp.IndexOf("E") > 0)    // if in the form like 12E-9
                            {
                                dTemp *= 10;
                                iMultiple *= 10;
                                strTemp = dTemp.ToString();
                            }
                            int i = 0;
                            while (strTemp[i] != separator)
                                i++;
                            int iDigitsAfterDecimal = strTemp.Length - i - 1;
                            while (iDigitsAfterDecimal > 0)
                            {
                                dTemp *= 10;
                                iMultiple *= 10;
                                iDigitsAfterDecimal--;
                            }
                            frac = new FractionBig((int)Math.Round(dTemp), iMultiple);
                        }
                        return frac;
                    }
                }
                catch (OverflowException e)
                {
                    throw new InvalidCastException("Conversion to FractionBig in no possible due to overflow.", e);
                }
                catch (Exception e)
                {
                    throw new InvalidCastException("Conversion to FractionBig in not possible.", e);
                }
            }

            private static FractionBig Inverse(FractionBig frac1)
            {
                if (frac1.Numerator == 0)
                    throw new InvalidOperationException("Operation not possible (Denominator cannot be assigned a ZERO Value)");

                BigInteger iNumerator = frac1.Denominator;
                BigInteger iDenominator = frac1.Numerator;
                return new FractionBig(iNumerator, iDenominator);
            }
            private static FractionBig Negate(FractionBig frac1)
            {
                BigInteger iNumerator = -frac1.Numerator;
                BigInteger iDenominator = frac1.Denominator;
                return new FractionBig(iNumerator, iDenominator);

            }
            private static FractionBig Add(FractionBig frac1, FractionBig frac2)
            {
                try
                {
                    checked
                    {
                        BigInteger iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                        BigInteger iDenominator = frac1.Denominator * frac2.Denominator;
                        return new FractionBig(iNumerator, iDenominator);
                    }
                }
                catch (OverflowException e)
                {
                    throw new OverflowException("Overflow occurred while performing arithemetic operation on FractionBig.", e);
                }
                catch (Exception e)
                {
                    throw new Exception("An error occurred while performing arithemetic operation on FractionBig.", e);
                }
            }
            private static FractionBig Multiply(FractionBig frac1, FractionBig frac2)
            {
                try
                {
                    checked
                    {
                        BigInteger iNumerator = frac1.Numerator * frac2.Numerator;
                        BigInteger iDenominator = frac1.Denominator * frac2.Denominator;
                        return new FractionBig(iNumerator, iDenominator);
                    }
                }
                catch (OverflowException e)
                {
                    throw new OverflowException("Overflow occurred while performing arithemetic operation on FractionBig.", e);
                }
                catch (Exception e)
                {
                    throw new Exception("An error occurred while performing arithemetic operation on FractionBig.", e);
                }
            }

            private static BigInteger GCD(BigInteger iNo1, BigInteger iNo2)
            {
                if (iNo1 < 0) iNo1 = -iNo1;
                if (iNo2 < 0) iNo2 = -iNo2;

                do
                {
                    if (iNo1 < iNo2)
                    {
                        BigInteger tmp = iNo1;
                        iNo1 = iNo2;
                        iNo2 = tmp;
                    }
                    iNo1 = iNo1 % iNo2;
                }
                while (iNo1 != 0);

                return iNo2;
            }

            public static FractionBig operator -(FractionBig frac1) { return (Negate(frac1)); }
            public static FractionBig operator +(FractionBig frac1, FractionBig frac2) { return (Add(frac1, frac2)); }
            public static FractionBig operator -(FractionBig frac1, FractionBig frac2) { return (Add(frac1, -frac2)); }
            public static FractionBig operator *(FractionBig frac1, FractionBig frac2) { return (Multiply(frac1, frac2)); }
            public static FractionBig operator /(FractionBig frac1, FractionBig frac2) { return (Multiply(frac1, Inverse(frac2))); }

            public static bool operator ==(FractionBig frac1, FractionBig frac2) { return frac1.Equals(frac2); }
            public static bool operator !=(FractionBig frac1, FractionBig frac2) { return (!frac1.Equals(frac2)); }
            public static bool operator <(FractionBig frac1, FractionBig frac2) { return frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator; }
            public static bool operator >(FractionBig frac1, FractionBig frac2) { return frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator; }
            public static bool operator <=(FractionBig frac1, FractionBig frac2) { return frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator; }
            public static bool operator >=(FractionBig frac1, FractionBig frac2) { return frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator; }

            public static implicit operator FractionBig(BigInteger value) { return new FractionBig(value); }
            public static implicit operator FractionBig(double value) { return DoubleToFraction(value); }
            public static implicit operator FractionBig(decimal value) { return DecimalToFraction(value); }

            public static explicit operator double(FractionBig frac)
            {
                return (double)(frac.Numerator / frac.Denominator);
            }
            public static explicit operator decimal(FractionBig frac)
            {
                return ((decimal)frac.Numerator / (decimal)frac.Denominator);
            }
        }
}
