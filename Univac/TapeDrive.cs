using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univac
{
    class TapeDrive
    {
        private const int EOL = -1;
        private const int EOT = -2;
        private const int SPC = -3;

        private List<String> tape;
        private int pos;
        private int linePos;
        private Boolean comment;
        private Boolean escape;

        public TapeDrive()
        {
            tape = new List<String>();
            pos = 0;
            linePos = 0;
            escape = false;
        }

        public void mount(List<String> t)
        {
            tape = t;
        }

        public List<String> retrieve()
        {
            return tape;
        }

        public void rewind()
        {
            pos = 0;
            linePos = 0;
            comment = false;
        }

        private int read()
        {
            int ret;
            if (pos >= tape.Count) return EOT;
            while (true)
            {
                if (linePos >= tape[pos].Length) return EOL;
                ret = tape[pos][linePos++];
                if (escape)
                {
                    if (ret >= 'A' && ret <= 'Z') ret += 32;
                    if (ret == ' ') ret = 'd';
                    escape = false;
                }
                else
                {
                    if (ret >= 'a' && ret <= 'z') ret -= 32;
                }
                if (comment == false && ret == '\\') escape = true;
                if (comment && (ret == ']' || ret == '>')) comment = false;
                else if (comment == false && (ret == '[' || ret == '<')) comment = true;
                else if (comment == false && ret == ' ') return SPC;
                else if (comment == false && escape == false) return ret;
            }
        }

        public void writeWord(String w)
        {
            while (tape.Count <= pos) tape.Add("");
            tape[pos++] = w;
        }

        public int[] readWord()
        {
            int i;
            int chr;
            int[] ret = new int[12];
            Boolean cmd;
            String wrd;
            String temp;
            wrd = "";
            temp = "";
            cmd = true;
            for (i=0; i<12; i++) ret[i] = 3;
            comment = false;
            linePos = 0;
            escape = false;
            while (wrd.Length + temp.Length < 12)
            {
                chr = read();
                if (chr == EOT) while (wrd.Length + temp.Length < 12) temp += '0';
                else if (chr == SPC || chr == EOL)
                {
                    if (temp.Length > 0)
                    {
                        if (temp.Length < 3)
                        {
                            if (cmd) while (temp.Length < 3) temp += '0';
                            else while (temp.Length < 3) temp = '0' + temp;
                        }
                    }
                    else if (chr == EOL) temp = "000";
                }
                else temp += ((char)chr).ToString();
                if (temp.Length == 3)
                {
                    wrd += temp;
                    temp = "";
                    if (wrd.Length == 3) cmd = false;
                    if (wrd.Length == 6) cmd = true;
                    if (wrd.Length == 9) cmd = false;
                }
            }
            if (temp.Length > 0) wrd += temp;
            ++pos;
            while (wrd.Length < 12) wrd += '0';
            for (i = 0; i < 12; i++) ret[i] = CPU.asciiToUnivac(wrd[i]);
            return ret;
        }

        public int[] readBackwardsWord()
        {
            int[] ret;
            if (--pos < 0) pos = 0;
            ret = readWord();
            if (--pos < 0) pos = 0;
            return ret;
        }


    }
}
