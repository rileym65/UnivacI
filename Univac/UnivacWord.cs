using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univac
{
    class UnivacWord
    {
        public const int ERROR_ALPHA = 1;

        private int[] val;
        private Boolean overflow;
        private int[] regA;
        private int[] regB;

        public UnivacWord()
        {
            val = new int[12];
            regA = new int[12];
            regB = new int[12];
            clear();
        }

        public int[] Val
        {
            get { return val; }
        }

        public Boolean Overflow
        {
            get { return overflow; }
        }

        public void clear()
        {
            int i;
            for (i = 0; i < 12; i++) val[i] = 3;
        }

        public void erase()
        {
            int i;
            for (i = 0; i < 12; i++) val[i] = 0;
        }

        public String get(Boolean spaces)
        {
            String ret;
            int i;
            ret = "";
            if (val[0] == 3 || val[0] == 2)
            {
                for (i = 0; i < 12; i++) ret += CPU.univacToAscii(val[i]);
            }
            else
            {
                for (i = 0; i < 12; i++)
                {
                    if (i > 0 && (i % 3) == 0 && spaces) ret += ' ';
                    ret += CPU.univacToAscii(val[i]);
                }
            }
            return ret;
        }

        public String getAsBitmap()
        {
            int i;
            int j;
            int tmp;
            String ret;
            ret = "";
            for (i = 0; i < 12; i++)
            {
                if (i != 0) ret += " ";
                if (i == 6) ret += "  ";
                tmp = val[i];
                for (j = 0; j < 6; j++)
                {
                    ret += ((tmp & 0x20) == 0x20) ? "1" : "0";
                    tmp <<= 1;
                }
            }
            return ret;
        }

        public void set(String v)
        {
            int i;
            int p;
            clear();
            p = 0;
            for (i = 0; i < v.Length; i++)
            {
                if (p < 12)
                {
                    val[p] = CPU.asciiToUnivac(v[i]);
                    p++;
                }
            }
        }

        public void set(UnivacWord v)
        {
            int i;
            for (i = 0; i < 12; i++) val[i] = v.Val[i];
        }

        public void or(UnivacWord v)
        {
            int i;
            for (i = 0; i < 12; i++) val[i] |= v.Val[i];
        }

        public void or(int[] v)
        {
            int i;
            for (i = 0; i < 12; i++) val[i] |= v[i];
        }

        public void set(int[] v)
        {
            int i;
            for (i = 0; i < 12; i++) val[i] = v[i];
        }

        public void setLeast(int[] v)
        {
            int i;
            for (i = 0; i < 11; i++) val[i + 1] = v[i + 12];
            val[0] = v[0];
        }

        public int add(UnivacWord bWord)
        {
            int i;
            Boolean carry;
            UnivacWord ret;
            Boolean aLarger;
            Boolean signA, signB;
            ret = new UnivacWord();
            overflow = false;
            for (i = 0; i < 12; i++)
            {
                regA[i] = val[i];
                regB[i] = bWord.Val[i];
            }
            aLarger = this.greaterNonSigned(bWord);
            signA = (regA[0] == 0x02) ? true : false;
            signB = (regB[0] == 0x02) ? true : false;
            if (signA != signB)
            {
                if (aLarger)
                {
                    for (i = 1; i < 12; i++) if (regB[i] < 0x10) regB[i] = (~regB[i]) & 0xf;
                    i = 11;
                    regB[11] += 1;
                    while (i > 1 && regB[i] > 0xf)
                    {
                        regB[i] -= 0xf;
                        regB[i - 1]++;
                        i--;
                    }
                }
                else
                {
                    for (i = 1; i < 12; i++) if (regA[i] < 0x10) regA[i] = (~regA[i]) & 0xf;
                    i = 11;
                    regA[11] += 1;
                    while (i > 1 && regA[i] > 0xf)
                    {
                        regA[i] -= 0xf;
                        regA[i - 1]++;
                        i--;
                    }
                }
            }
            carry = false;
            val[0] = (aLarger) ? regA[0] : regB[0];
            for (i = 11; i > 0; i--)
            {
                if (regA[i] > 15 && regB[i] > 15) return CPU.STOP_ADD_ALPHA;
                if (regA[i] > 15) { val[i] = regA[i]; carry = false; }
                else if (regB[i] > 15) { val[i] = regB[i]; carry = false; }
                else
                {
                    val[i] = regA[i] + regB[i] + ((carry) ? 1 : 0);
                    carry = (val[i] > 15) ? true : false;
                    val[i] -= (carry) ? 13 : 3;
                }
            }
            overflow = (signA != signB) ? false : carry;
            return 0;
        }

        public void addUnsigned(UnivacWord bWord)
        {
            int i;
            Boolean carry;
            overflow = false;
            for (i = 0; i < 12; i++)
            {
                regA[i] = val[i];
                regB[i] = bWord.Val[i];
            }
            regB[0] = 0x03;
            carry = false;
            for (i = 11; i >= 0; i--)
            {
                if (regA[i] < 3 || regA[i] > 12) { val[i] = regA[i]; carry = false; }
                else if (regB[i] < 3 || regB[i] > 12) { val[i] = regB[i]; carry = false; }
                else
                {
                    val[i] = regA[i] + regB[i] + ((carry) ? 1 : 0);
                    carry = (val[i] > 15) ? true : false;
                    val[i] -= (carry) ? 13 : 3;
                }
            }
        }

        public Boolean equals(UnivacWord bword)
        {
            int i;
            for (i = 0; i < 12; i++) if (val[i] != bword.Val[i]) return false;
            return true;
        }

        public Boolean greater(UnivacWord bword)
        {
            int i;
            for (i = 0; i < 12; i++) if (val[i] > bword.Val[i]) return true;
            return false;
        }

        public Boolean greaterNonSigned(UnivacWord bword)
        {
            int i;
            for (i = 1; i < 12; i++) if (val[i] > bword.Val[i]) return true;
            return false;
        }

        public void shiftRight(int places)
        {
            int i, j;
            for (i = 0; i < places; i++)
            {
                for (j = 11; j > 1; j--) val[j] = val[j - 1];
                val[1] = 3;
            }

        }

        public void shiftLeft(int places)
        {
            int i, j;
            for (i = 0; i < places; i++)
            {
                for (j = 1; j < 10; j++) val[j] = val[j + 1];
                val[11] = 3;
            }

        }

        public void shiftRightUnsigned(int places)
        {
            int i, j;
            for (i = 0; i < places; i++)
            {
                for (j = 11; j > 0; j--) val[j] = val[j - 1];
                val[0] = 3;
            }

        }

        public void shiftLeftUnsigned(int places)
        {
            int i, j;
            for (i = 0; i < places; i++)
            {
                for (j = 0; j < 10; j++) val[j] = val[j + 1];
                val[11] = 3;
            }

        }

        public void chs()
        {
            val[0] = (val[0] == 0x03) ? 0x02 : 0x03;
        }

        public void extract(UnivacWord selector, UnivacWord source)
        {
            int i;
            for (i = 0; i < 12; i++)
            {
                val[i] = ((selector.Val[i] & 1) == 1) ? val[i] : source.Val[i];
            }
        }

        public void decimalInc()
        {
            int i;
            val[11]++;
            i = 11;
            while (i > 0 && val[i] > 0x0c)
            {
                val[i] -= 0x03;
                val[i - 1]++;
                i--;
            }
        }

        public int toInt()
        {
            int i;
            int ret;
            ret = 0;
            for (i = 1; i < 12; i++)
            {
                ret *= 10;
                ret += (val[i] - 0x03);
            }
            return ret;
        }
    }
}
