using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univac
{
    class CPU
    {
        public const int STOP_KBD = 1;
        public const int STOP_HALT = 2;
        public const int STOP_OVER = 3;
        public const int STOP_ADD_ALPHA = 4;
        public const int STOP_COND_BREAK = 5;
        public const int STOP_DISP_BREAK = 6;

        public const int ERROR_TANK_SEL_4 = 1;
        public const int ERROR_TANK_SEL_5 = 2;
        public const int ERROR_FT_INTER = 3;

        public const int OUTPUT_M = 1;
        public const int OUTPUT_A = 2;
        public const int OUTPUT_X = 3;
        public const int OUTPUT_L = 4;
        public const int OUTPUT_F = 5;
        public const int OUTPUT_C = 6;
        public const int OUTPUT_CR = 7;
        public const int OUTPUT_SYI = 8;
        public const int OUTPUT_EMPTY = 0;

        public const int IOS_NORMAL = 0;
        public const int IOS_ONE_OPER = 1;
        public const int IOS_ONE_INST = 2;
        public const int IOS_ONE_STEP = 3;
        public const int IOS_ONE_ADTN = 4;

        private UnivacWord regA;
        private UnivacWord regL;
        private UnivacWord regF;
        private UnivacWord regX;
        private UnivacWord[] regV;
        private UnivacWord[] regY;
        private UnivacWord[] regI;
        private UnivacWord[] regO;
        private UnivacWord regCR;
        private UnivacWord regCC;
        private int jump;
        private UnivacWord[] memory;
        private Boolean running;
        private Boolean debug;
        private int stopReason;
        private int keyboardAddress;
        private String debugLine;
        private String printer;
        private TapeDrive[] tapeDrives;
        private int[] result;
        private int[] value;
        private int[] argA;
        private int[] argB;
        private int[] argNeg;
        private int phase;
        private int pc;
        private int[] regSR;
        private Boolean overflow;
        private int bootDrive;
        private int outputBreakpoint;
        private Boolean stopFF;
        private Boolean breakpoint;
        private int conditionalBreakpoints;
        private int transferMode;
        private int outputSelector;
        private int blockSubdivisionSelector;
        private Boolean sciCrFill;
        private int stallTimer;
        private Boolean[] errorFF;
        private int inputSyncCounter;
        private int inputTankCounter;
        private int outputSyncCounter;
        private int outputTankCounter;
        private Boolean changePhase;
        private int transferNoTransfer;
        private int iosSwitch;

        public CPU()
        {
            int i;
            regA = new UnivacWord();
            regL = new UnivacWord();
            regF = new UnivacWord();
            regX = new UnivacWord();
            regCR = new UnivacWord();
            regV = new UnivacWord[2]; for (i = 0; i < 2; i++) regV[i] = new UnivacWord();
            regY = new UnivacWord[10]; for (i = 0; i < 10; i++) regY[i] = new UnivacWord();
            regI = new UnivacWord[60]; for (i = 0; i < 60; i++) regI[i] = new UnivacWord();
            regO = new UnivacWord[60]; for (i = 0; i < 60; i++) regO[i] = new UnivacWord();
            regCC = new UnivacWord();
            result = new int[23];
            value = new int[12];
            regSR = new int[6];
            argA = new int[23];
            argB = new int[23];
            argNeg = new int[23];
            memory = new UnivacWord[1000];
            for (i = 0; i < 1000; i++) memory[i] = new UnivacWord();
            tapeDrives = new TapeDrive[10];
            for (i = 0; i < 10; i++) tapeDrives[i] = new TapeDrive();
            debug = false;
            debugLine = "";
            printer = "";
            bootDrive = 1;
            outputBreakpoint = 1;
            breakpoint = false;
            stopFF = true;
            conditionalBreakpoints = 0;
            transferMode = 1;
            outputSelector = 1;
            blockSubdivisionSelector = 0;
            sciCrFill = false;
            stallTimer = 3000;
            errorFF = new Boolean[35];
            for (i = 0; i < 35; i++) errorFF[i] = false;
            inputSyncCounter = 0x03;
            inputTankCounter = 1;
            outputSyncCounter = 0x03;
            outputTankCounter = 1;
            transferNoTransfer = 0;
            iosSwitch = 0;
            reset();
        }

        public int BootDrive
        {
            get { return bootDrive; }
            set { bootDrive = value; }
        }

        public int BlockSubdivisionSelector
        {
            get { return blockSubdivisionSelector; }
            set { blockSubdivisionSelector = value; }
        }

        public Boolean Breakpoint
        {
            get { return breakpoint; }
            set { breakpoint = value; }
        }

        public int ConditionalBreakpoints
        {
            get { return conditionalBreakpoints; }
            set { conditionalBreakpoints = value; }
        }

        public Boolean Debug
        {
            get { return debug; }
            set { debug = value; }
        }

        public Boolean[] ErrorFF
        {
            get { return errorFF; }
        }

        public int InputSyncCounter
        {
            get { return inputSyncCounter; }
        }

        public int InputTankCounter
        {
            get { return inputTankCounter; }
        }

        public int IosSwitch
        {
            get { return iosSwitch; }
            set { iosSwitch = value; }
        }

        public int Jump
        {
            get { return jump; }
        }

        public int OutputSyncCounter
        {
            get { return outputSyncCounter; }
        }

        public int OutputTankCounter
        {
            get { return outputTankCounter; }
        }

        public Boolean Running
        {
            get { return running; }
        }

        public UnivacWord[] Memory
        {
            get { return memory; }
        }

        public String DebugLine
        {
            get { return debugLine; }
        }

        public int OutputBreakpoint
        {
            get { return outputBreakpoint; }
            set { outputBreakpoint = value; }
        }

        public int OutputSelector
        {
            get { return outputSelector; }
            set { outputSelector = value; }
        }

        public int Pc
        {
            get { return pc; }
        }

        public int Phase
        {
            get { return phase; }
        }

        public int StallTimer
        {
            get { return stallTimer; }
        }

        public Boolean StopFF
        {
            get { return stopFF; }
        }

        public Boolean Overflow
        {
            get { return overflow; }
            set { overflow = value; }
        }

        public int[] RegSR
        {
            get { return regSR; }
        }

        public Boolean SciCrFill
        {
            get { return sciCrFill; }
            set { sciCrFill = value; }
        }

        public int StopReason
        {
            get { return stopReason; }
        }

        public int TransferMode
        {
            get { return transferMode; }
            set { transferMode = value; }
        }

        public int TransferNoTransfer
        {
            get { return transferNoTransfer; }
            set { transferNoTransfer = value; }
        }

        public void clearError(int num)
        {
            errorFF[num] = false;
            errorFF[num] = false;
        }

        public String getPrinter()
        {
            String ret;
            ret = printer;
            printer = "";
            return ret;
        }

        public void mountTape(int drive, List<String> tape)
        {
            tapeDrives[drive].mount(tape);
            tapeDrives[drive].rewind();
        }

        public List<String> retrieveTape(int drive)
        {
            return tapeDrives[drive].retrieve();
        }

        public void rewind(int drive)
        {
            tapeDrives[drive].rewind();
        }

        public void keyboardInput(String s)
        {
            int i;
            int[] value;
            value = new int[12];
            for (i = 0; i < 12; i++) value[i] = 3;
            for (i = 0; i < s.Length; i++) value[i] = asciiToUnivac(s[i]);
            memory[keyboardAddress].set(value);
            stopReason = 0; ;
            running = true;
        }

        public static int asciiToUnivac(char c)
        {
            switch (c)
            {
                case 'i': return 0x00;
                case 'd': return 0x01;
                case '-': return 0x02;
                case '0': return 0x03;
                case '1': return 0x04;
                case '2': return 0x05;
                case '3': return 0x06;
                case '4': return 0x07;
                case '5': return 0x08;
                case '6': return 0x09;
                case '7': return 0x0a;
                case '8': return 0x0b;
                case '9': return 0x0c;
                case '\'': return 0x0d;
                case '&': return 0x0e;
                case '(': return 0x0f;
                case 'r': return 0x10;
                case ',': return 0x11;
                case '.': return 0x12;
                case ';': return 0x13;
                case 'A': return 0x14;
                case 'B': return 0x15;
                case 'C': return 0x16;
                case 'D': return 0x17;
                case 'E': return 0x18;
                case 'F': return 0x19;
                case 'G': return 0x1a;
                case 'H': return 0x1b;
                case 'I': return 0x1c;
                case '#': return 0x1d;
                case 'c': return 0x1e;
                case '@': return 0x1f;
                case 't': return 0x20;
                case '"': return 0x21;
                case '!': return 0x22;
                case ')': return 0x23;
                case 'J': return 0x24;
                case 'K': return 0x25;
                case 'L': return 0x26;
                case 'M': return 0x27;
                case 'N': return 0x28;
                case 'O': return 0x29;
                case 'P': return 0x2a;
                case 'Q': return 0x2b;
                case 'R': return 0x2c;
                case '$': return 0x2d;
                case '*': return 0x2e;
                case '?': return 0x2f;
                case 'e': return 0x30;
                case 'b': return 0x31;
                case ':': return 0x32;
                case '+': return 0x33;
                case '/': return 0x34;
                case 'S': return 0x35;
                case 'T': return 0x36;
                case 'U': return 0x37;
                case 'V': return 0x38;
                case 'W': return 0x39;
                case 'X': return 0x3a;
                case 'Y': return 0x3b;
                case 'Z': return 0x3c;
                case '%': return 0x3d;
                case '=': return 0x3e;
                case ' ': return 0x3f;
            }
            return 0;
        }

        public static char univacToAscii(int b)
        {
            switch (b)
            {
                case 0x00: return 'i';
                case 0x01: return 'd';
                case 0x02: return '-';
                case 0x03: return '0';
                case 0x04: return '1';
                case 0x05: return '2';
                case 0x06: return '3';
                case 0x07: return '4';
                case 0x08: return '5';
                case 0x09: return '6';
                case 0x0a: return '7';
                case 0x0b: return '8';
                case 0x0c: return '9';
                case 0x0d: return '\'';
                case 0x0e: return '&';
                case 0x0f: return '(';
                case 0x10: return 'r';
                case 0x11: return ',';
                case 0x12: return '.';
                case 0x13: return ';';
                case 0x14: return 'A';
                case 0x15: return 'B';
                case 0x16: return 'C';
                case 0x17: return 'D';
                case 0x18: return 'E';
                case 0x19: return 'F';
                case 0x1a: return 'G';
                case 0x1b: return 'H';
                case 0x1c: return 'I';
                case 0x1d: return '#';
                case 0x1e: return 'c';
                case 0x1f: return '@';
                case 0x20: return 't';
                case 0x21: return '"';
                case 0x22: return '!';
                case 0x23: return ')';
                case 0x24: return 'J';
                case 0x25: return 'K';
                case 0x26: return 'L';
                case 0x27: return 'M';
                case 0x28: return 'N';
                case 0x29: return 'O';
                case 0x2a: return 'P';
                case 0x2b: return 'Q';
                case 0x2c: return 'R';
                case 0x2d: return '$';
                case 0x2e: return '*';
                case 0x2f: return '?';
                case 0x30: return 'e';
                case 0x31: return 'b';
                case 0x32: return ':';
                case 0x33: return '+';
                case 0x34: return '/';
                case 0x35: return 'S';
                case 0x36: return 'T';
                case 0x37: return 'U';
                case 0x38: return 'V';
                case 0x39: return 'W';
                case 0x3a: return 'X';
                case 0x3b: return 'Y';
                case 0x3c: return 'Z';
                case 0x3d: return '%';
                case 0x3e: return '=';
                case 0x3f: return ' ';
            }
            return ' ';
        }

        public void reset()
        {
            int i;
            running = false;
            regCC.clear();
            regA = new UnivacWord();
            regL = new UnivacWord();
            regF = new UnivacWord();
            regX = new UnivacWord();
            for (i = 0; i < 2; i++) regV[i] = new UnivacWord();
            for (i = 0; i < 10; i++) regY[i] = new UnivacWord();
            for (i = 0; i < 60; i++) regI[i] = new UnivacWord();
            for (i = 0; i < 60; i++) regO[i] = new UnivacWord();
            overflow = false;
            stopReason = 0;
            phase = 1;
            pc = 1;
        }

        public void start()
        {
            if (stopReason == STOP_COND_BREAK)
            {
                if (transferNoTransfer == 1) jump = 0;
                if (transferNoTransfer == -1) jump = -1;
            }
            stopReason = 0;
            stopFF = false;
            running = true;
        }

        public void stop()
        {
            running = false;
        }

        public void boot()
        {
            int i;
            inputTankCounter = 1;
            inputSyncCounter = 0x03;
            for (i = 0; i < 60; i++)
            {
                regI[i].or(tapeDrives[bootDrive-1].readWord());
                memory[i].set(regI[i]);
                regI[i].erase();
            }
            regCC.clear();
            phase = 1;
            stopReason = 0;
            inputTankCounter = 7;
            inputSyncCounter = 0x03;
        }

        public void clearC()
        {
            regCC.clear();
            phase = 1;
            pc = 1;
        }

        public void clearCy()
        {
            phase = 1;
        }

        public void clearPc()
        {
            pc = 1;
        }

        public void clearIAndO()
        {
            int i;
            for (i = 0; i < 60; i++)
            {
                regI[i].erase();
                regO[i].erase();
            }
        }

        private int extractAddress(int[] inst)
        {
            int ret;
            ret = 0;
            if (inst.Length > 1) ret = inst[inst.Length - 1] - 3;
            if (inst.Length > 2) ret += ((inst[inst.Length - 2] - 3) * 10);
            if (inst.Length > 3) ret += ((inst[inst.Length - 3] - 3) * 100);
            return ret;
        }

        private int tapeNumber(int inst)
        {
            if (inst >= 0x04 && inst <= 0x0c) return inst - 4;
            if (inst == 0x02) return 9;
            return -1;
        }

        private void excess3Add(int[] src, int[] dst, int offset)
        {
            int i;
            Boolean carry;
            carry = false;
            for (i = src.Length - 1; i > 0; i--)
            {
                dst[i+offset] = (src[i] & 0xf) + (dst[i+offset] & 0xf) + ((carry) ? 1 : 0);
                carry = (dst[i+offset] > 15) ? true : false;
                dst[i+offset] -= (carry) ? 13 : 3;
            }
            if (carry)
            {
                dst[offset] += 4;
                dst[offset] -= (dst[offset] > 15) ? 13 : 3;
            }
  
        }

        private void multiply(UnivacWord ier, UnivacWord icand)
        {
            int i,j;
            regF.clear();
            regF.addUnsigned(regL); regF.addUnsigned(regL); regF.addUnsigned(regL);
            for (i = 0; i < 23; i++) result[i] = 3;
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < (ier.Val[i] - 3); j++)
                {
                    excess3Add(icand.Val, result, i);
                }
            }
            if (ier.Val[0] != icand.Val[0]) result[0] = 0x02;
        }

        private Boolean isZero(int[] value)
        {
            int i;
            for (i = 1; i < value.Length; i++)
                if (value[i] != 0x03) return false;
            return true;
        }

        private Boolean greaterEqual(int[] a, int[] b)
        {
            int i;
            for (i = 1; i < a.Length; i++)
                if (b[i] > a[i]) return false;
                else if (b[i] < a[i]) return true;
            return true;
        }

        private String intArrayToString(int[] v)
        {
            int i;
            String ret;
            ret = "";
            for (i = 0; i < v.Length; i++) ret += univacToAscii(v[i]);
            return ret;
        }

        private Boolean divide()
        {
            int i;
            int pos;
            int cnt;
            int sign;
            sign = (regA.Val[0] == regL.Val[0]) ? 0x03 : 0x02;
            for (i = 0; i < 23; i++)
            {
                argA[i] = 0x03;
                argB[i] = 0x03;
                result[i] = 0x03;
                argNeg[i] = 0x0c;
            }
            for (i = 1; i < 12; i++)
            {
                argA[i] = regA.Val[i] & 0xf;
                argB[i] = regL.Val[i] & 0xf;
                argNeg[i] = argB[i];
            }
            for (i = 1; i < 23; i++) argNeg[i] = (~argNeg[i]) & 0xf;
            i = 22;
            argNeg[22] += 1;
            while (i > 1 && argNeg[i] > 0xc)
            {
                argNeg[i] -= 10;
                argNeg[i - 1]++;
                i--;
            }
            pos = 0;
            while (isZero(argA) == false && isZero(argB) == false)
            {
                cnt = 0;
                while (greaterEqual(argA,argB) & cnt < 20) {
                    result[pos]++;
                    if (pos == 0 && result[pos] > 0x03)
                    {
                        return true;
                    }
                    excess3Add(argNeg, argA, 0);
                    cnt++;
                }
                pos++;
                for (i = 22; i > 0; i--)
                {
                    argB[i] = argB[i - 1];
                    argNeg[i] = argNeg[i - 1];
                }
                argB[0] = 0x03;
                argNeg[0] = 0x0c;
            }
            for (i = 1; i < 12; i++) regX.Val[i] = result[i];
            regX.Val[0] = sign;
            for (i = 0; i < 12; i++) value[i] = 0x03;
            value[11] = 0x04;
            excess3Add(value, result,0);
            for (i = 1; i < 12; i++) regA.Val[i] = result[i];
            regA.Val[0] = sign;
            return false;
        }

        private void getOutputToPrint(int address)
        {
            switch (outputSelector)
            {
                case OUTPUT_M:
                    printer = memory[address].get(false);
                    break;
                case OUTPUT_A:
                    printer = regA.get(false);
                    break;
                case OUTPUT_X:
                    printer = regX.get(false);
                    break;
                case OUTPUT_L:
                    printer = regL.get(false);
                    break;
                case OUTPUT_F:
                    printer = regF.get(false);
                    break;
                case OUTPUT_C:
                    printer = regCC.get(false);
                    break;
                case OUTPUT_CR:
                    printer = regCR.get(false);
                    break;
            }
        }

        private Boolean exec()
        {
            int i;
            int address;
            int address2;
            int tape;
            int status;
            Boolean res;
            res = true;
            if (debug & pc == 1)
            {
                for (i = 0; i < regSR.Length; i++)
                {
                    if (i == 3) debugLine += " ";
                    debugLine += univacToAscii(regSR[i]);
                }
                debugLine += "  ";
            }
            if (regSR[4] < 0x03 || regSR[4] > 0x0c)
            {
                errorFF[ERROR_TANK_SEL_4] = true;
                running = false;
            }
            if (regSR[5] < 0x03 || regSR[5] > 0x0c)
            {
                errorFF[ERROR_TANK_SEL_5] = true;
                running = false;
            }
            if (running == false) return false;
            address = extractAddress(regSR);
            address2 = address + 1;
            if (address2 >= 1000) address2 = 0;
            if (jump >= 0) jump = address;
            switch (regSR[0])
            {
                case 0x02:                                                        // -
                    changePhase = false;
                    if (debug && pc == 1) debugLine += "A = " + regA.get(true) + " >> " + address.ToString() + " = ";
                    if (pc <= (regSR[1] - 3))
                    {
                        regA.shiftRight(1);
                        pc++;
                    }
                    else
                    {
                        if (debug) debugLine += regA.get(true);
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x03:                                                        // 0
                    if (debug && regSR[1] == 0x03) debugLine += "Skip";            // 0
                    if (regSR[1] != 0x03)                                          // nonzero
                    {
                        changePhase = false;
                        if (debug && pc == 1) debugLine += "A = " + regA.get(true) + " << " + address.ToString() + " = ";
                        if (pc <= (regSR[1] - 3))
                        {
                            regA.shiftLeft(1);
                            pc++;
                        }
                        else
                        {
                            if (debug) debugLine += regA.get(true);
                            pc = 1;
                            changePhase = true;
                        }
                    }
                    break;
                case 0x04:                                                        // 1
                    tape = tapeNumber(regSR[1]);
                    if (regSR[1] == 3)                                             // 0
                    {
                        running = false;
                        stopReason = STOP_KBD;
                        keyboardAddress = address;
                        if (debug)
                        {
                            debugLine += "Stopped awaiting keyboard input";
                        }
                        return false;
                    }
                    else if (tape >= 0)                                           // 1-9,-
                    {
                        if (debug) debugLine += "Read tape to I";
                        inputTankCounter = 1;
                        inputSyncCounter = 0x03;
                        for (i = 0; i < 60; i++)
                        {
                            regI[i].set(tapeDrives[tape].readWord());
                        }
                        inputTankCounter = 7;
                        inputSyncCounter = 0x03;
                    }
                    break;
                case 0x05:                                                        // 2
                    tape = tapeNumber(regSR[1]);
                    if (tape >= 0)                                                // 1-9,-
                    {
                        if (debug) debugLine += "Read backwards tape to I";
                        inputTankCounter = 1;
                        inputSyncCounter = 0x03;
                        for (i = 59; i >= 0; i--)
                        {
                            regI[i].set(tapeDrives[tape].readBackwardsWord());
                        }
                        inputTankCounter = 7;
                        inputSyncCounter = 0x0c;
                    }
                    break;
                case 0x06:                                                        // 3
                    tape = tapeNumber(regSR[1]);
                    address /= 10;
                    address *= 10;
                    if (regSR[1] == 3 || tape >= 0)
                    {
                        if (debug) debugLine += "I->[" + address.ToString("D3") + "]";
                        for (i = 0; i < 60; i++)
                        {
                            memory[address].set(regI[i]);
                            regI[i].erase();
                            if (++address >= 1000) address = 0;
                        }
                    }
                    if (tape >= 0)
                    {
                        if (debug) debugLine += ", Read tape to I";
                        inputTankCounter = 1;
                        inputSyncCounter = 0x03;
                        for (i = 0; i < 60; i++)
                        {
                            regI[i].set(tapeDrives[tape].readWord());
                        }
                        inputTankCounter = 7;
                        inputSyncCounter = 0x0c;
                    }
                    break;
                case 0x07:                                                        // 4
                    tape = tapeNumber(regSR[1]);
                    address /= 10;
                    address *= 10;
                    if (regSR[1] == 3 || tape >= 0)
                    {
                        if (debug) debugLine += "I->[" + address.ToString("D3") + "]";
                        for (i = 0; i < 60; i++)
                        {
                            memory[address].set(regI[i]);
                            regI[i].erase();
                            if (++address >= 1000) address = 0;
                        }
                    }
                    if (tape >= 0)
                    {
                        if (debug) debugLine += "Read backwards tape to I";
                        inputTankCounter = 1;
                        inputSyncCounter = 0x03;
                        for (i = 59; i >= 0; i--)
                        {
                            regI[i].set(tapeDrives[tape].readBackwardsWord());
                        }
                        inputTankCounter = 7;
                        inputSyncCounter = 0x0c;
                    }
                    break;
                case 0x08:                                                        // 5
                    tape = tapeNumber(regSR[1]);
                    if (regSR[1] == 3)                                             // 0
                    {
                        if (pc == 1)
                        {
                            switch (outputBreakpoint)
                            {
                                case 0: break;
                                case 1: break;
                                case 2:
                                    stopFF = true;
                                    stopReason = STOP_DISP_BREAK;
                                    break;
                            }
                            pc = 2;
                            changePhase = false;
                        }
                        else
                        {
                            if (outputBreakpoint != 0)
                            {
                                getOutputToPrint(address);
                            }
                            pc = 1;
                        }
                    }
                    else if (tape >= 0)                                           // 1-9,-
                    {
                        address /= 10;
                        address *= 10;
                        if (debug) debugLine += "Write [" + address.ToString("D3") + "] to tape " + (tape + 1).ToString();
                        outputTankCounter = 1;
                        outputSyncCounter = 0x03;
                        for (i = 0; i < 60; i++)
                        {
                            regO[i].set(memory[address]);
                            tapeDrives[tape].writeWord(memory[address].get(false));
                            if (++address >= 1000) address = 0;
                        }
                        outputTankCounter = 7;
                        outputSyncCounter = 0x0c;
                    }
                    break;
                case 0x09:                                                        // 6
                    tape = tapeNumber(regSR[1]);
                    if (tape >= 0)                                                // 1-9,-
                    {
                        if (debug) debugLine += "Rewind tape " + (tape + 1).ToString();
                        tapeDrives[tape].rewind();
                    }
                    break;
                case 0x0a:                                                        // 7
                    tape = tapeNumber(regSR[1]);
                    address /= 10;
                    address *= 10;
                    if (tape >= 0)                                                // 1-9,-
                    {
                        if (debug) debugLine += "Write [" + address.ToString("D3") + "] to tape " + (tape + 1).ToString();
                        outputTankCounter = 1;
                        outputSyncCounter = 0x03;
                        for (i = 0; i < 60; i++)
                        {
                            regO[i].set(memory[address]);
                            tapeDrives[tape].writeWord(memory[address].get(false));
                            if (++address >= 1000) address = 0;
                        }
                        outputTankCounter = 7;
                        outputSyncCounter = 0x0c;
                    }
                    break;
                case 0x0b:                                                        // 8
                    tape = tapeNumber(regSR[1]);
                    if (tape >= 0)                                                // 1-9,-
                    {
                        if (debug) debugLine += "Rewind tape " + (tape + 1).ToString();
                        tapeDrives[tape].rewind();
                    }
                    break;
                case 0x0c:                                                        // 9
                    if (regSR[1] == 3)                                             // 0
                    {
                        running = false;
                        stopReason = STOP_HALT;
                        if (debug)
                        {
                            debugLine += "Machine stopped";
                        }
                        return false;
                    }
                    break;
                case 0x11:                                                        // ,
                    if (breakpoint)
                    {
                        if (debug) debugLine += "Breakpoint triggered";
                        stopFF = true;
                    }
                    else
                    {
                        if (debug) debugLine += "Breakpoint skipped";
                    }
                    break;
                case 0x12:                                                        // .
                    changePhase = false;
                    if (debug && pc == 1) debugLine += "A = " + regA.get(true) + " >> " + address.ToString() + " = ";
                    if (pc <= (regSR[1] - 3))
                    {
                        regA.shiftRightUnsigned(1);
                        pc++;
                    }
                    else
                    {
                        if (debug) debugLine += regA.get(true);
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x13:                                                        // ;
                    changePhase = false;
                    if (debug && pc == 1) debugLine += "A = " + regA.get(true) + " << " + address.ToString() + " = ";
                    if (pc <= (regSR[1] - 3))
                    {
                        regA.shiftLeftUnsigned(1);
                        pc++;
                    }
                    else
                    {
                        if (debug) debugLine += regA.get(true);
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x14:                                                        // A
                    if (pc == 1)
                    {
                        regX.set(memory[address]);
                        changePhase = false;
                        pc = 2;
                    }
                    else
                    {
                        if (debug) debugLine += "A = " + regA.get(true) + " + " + regX.get(true) + " = ";
                        status = regA.add(regX);
                        if (status != 0)
                        {
                            stopReason = status;
                            running = false;
                        }
                        else if (regA.Overflow)
                        {
                            if (debug) debugLine += "overflowed ";
                            if (regSR[1] != 0x02) overflow = true;
                            else
                            {
                                stopReason = STOP_OVER;
                                running = false;
                            }
                        }
                        if (debug) debugLine += regA.get(true);
                    }
                    break;
                case 0x15:                                                        // B
                    regA.set(memory[address]);
                    regX.set(memory[address]);
                    if (debug)
                    {
                        debugLine += "A = " + regA.get(true) + ", X=" + regX.get(true);
                    }
                    break;
                case 0x16:                                                        // C
                    memory[address].set(regA);
                    regA.clear();
                    if (debug)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true) + ", A = 0";
                    }
                    break;
                case 0x17:                                                        // D
                    regA.set(memory[address]);
                    if (debug) debugLine += "A,X = " + regA.get(true) + " / " + regX.get(true) + " = ";
                    if (divide())
                    {
                        if (debug) debugLine += "overflowed ";
                        if (regSR[1] != 0x02) overflow = true;
                        else
                        {
                            stopReason = STOP_OVER;
                            running = false;
                        }
                    }
                    if (debug) debugLine += regA.get(true) + "," + regX.get(true);
                    break;
                case 0x18:                                                        // E
                    if (debug) debugLine += "A=" + regA.get(true) + " extract " + regF.get(true);
                    regA.extract(regF, memory[address]);
                    if (debug) debugLine += " = " + regA.get(true);
                    break;
                case 0x19:                                                        // F
                    regF.set(memory[address]);
                    if (debug)
                    {
                        debugLine += "F=" + regF.get(true);
                    }
                    break;
                case 0x1a:                                                        // G
                    memory[address].set(regF);
                    if (debug)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true);
                    }
                    break;
                case 0x1b:                                                        // H
                    memory[address].set(regA);
                    if (debug)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true);
                    }
                    break;
                case 0x24:                                                        // J
                    memory[address].set(regX);
                    if (debug)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true);
                    }
                    break;
                case 0x25:                                                        // K
                    regL.set(regA);
                    regA.clear();
                    if (debug)
                    {
                        debugLine += "L=" + regL.get(true) + ", A=0";
                    }
                    break;
                case 0x26:                                                        // L
                    regL.set(memory[address]);
                    regX.set(memory[address]);
                    if (debug)
                    {
                        debugLine += "L=" + regL.get(true) + ", X=" + regX.get(true);
                    }
                    break;
                case 0x27:                                                        // M
                    regX.set(memory[address]);
                    if (debug) debugLine += "A=" + regL.get(true) + " * " + regX.get(true);
                    multiply(regL, regX);
                    regA.set(result);
                    if (debug) debugLine += " = " + regA.get(true);
                    break;
                case 0x28:                                                        // N
                    regX.set(memory[address]);
                    regX.chs();
                    if (debug) debugLine += "A=" + regL.get(true) + " * " + regX.get(true);
                    multiply(regL, regX);
                    regA.set(result);
                    if (debug) debugLine += " = " + regA.get(true);
                    break;
                case 0x2a:                                                        // P
                    regX.set(memory[address]);
                    if (debug) debugLine += "A,X=" + regL.get(true) + " * " + regX.get(true);
                    multiply(regL, regX);
                    regA.set(result);
                    regX.setLeast(result);
                    if (debug) debugLine += " = " + regA.get(true) + "," + regX.get(true);
                    break;
                case 0x2b:                                                        // Q
                    if (pc == 1)
                    {
                        if (regA.equals(regL))
                        {
                            jump = address;
                            if (debug) debugLine += "A=L, Jump to " + address.ToString("D3");
                            res = false;
                        }
                        else
                        {
                            if (debug) debugLine += "A<>L, Jump not taken";
                        }
                        pc++;
                        changePhase = false;
                        i = 1 << (regSR[1] - 0x03);
                        if ((conditionalBreakpoints & i) == i)
                        {
                            stopReason = STOP_COND_BREAK;
                            running = false;
                            return false;
                        }
                    }
                    else
                    {
                        pc = 1;
                    }
                    break;
                case 0x2c:                                                        // R
                    value = new int[12];
                    for (i = 0; i < 6; i++) value[i] = 0x03;
                    value[6] = 0x37; value[7] = 0x03; value[8] = 0x03;
                    for (i = 9; i <= 11; i++) value[i] = regCC.Val[i];
                    memory[address].set(value);
                    if (debug)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true);
                    }
                    break;
                case 0x35:                                                        // S
                    if (pc == 1)
                    {
                        regX.set(memory[address]);
                        regX.chs();
                        changePhase = false;
                        pc = 2;
                    }
                    else
                    {
                        if (debug)
                        {
                            debugLine += "A = " + regA.get(true) + " + " + regX.get(true) + " = ";
                        }
                        regA.add(regX);
                        if (regA.Overflow)
                        {
                            if (debug) debugLine += "overflowed ";
                            if (regSR[1] != 0x02) overflow = true;
                            else
                            {
                                stopReason = STOP_OVER;
                                running = false;
                            }
                        }
                        if (debug)
                        {
                            debugLine += regA.get(true);
                        }
                    }
                    break;
                case 0x36:                                                        // T
                    if (pc == 1)
                    {
                        if (regA.greater(regL))
                        {
                            jump = address;
                            if (debug) debugLine += "A>L, Jump to " + address.ToString("D3");
                            res = false;
                        }
                        else
                        {
                            if (debug)
                            {
                                debugLine += "A<=L, Jump not taken";
                            }
                        }
                        changePhase = false;
                        pc++;
                    }
                    else
                    {
                        pc = 1;
                    }
                    break;
                case 0x37:                                                        // U
                    jump = address;
                    if (debug)
                    {
                        debugLine += "Unconditional Jump to " + address.ToString("D3");
                    }
                    return false;
                case 0x38:                                                        // V
                    changePhase = false;
                    address += (pc - 1);
                    if (address >= 1000) address -= 1000;
                    regV[pc-1].set(memory[address]);
                    if (debug && pc == 1) debugLine += "V=" + regV[0].get(true) + ", " + regV[1].get(true);
                    pc++;
                    if (pc == 3)
                    {
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x39:                                                        // W
                    changePhase = false;
                    address += (pc - 1);
                    if (address >= 1000) address -= 1000;
                    memory[address].set(regV[pc-1]);
                    if (debug & pc == 1)
                    {
                        debugLine += "[" + address.ToString("D3") + "] = " + memory[address].get(true);
                        debugLine += ", [" + address2.ToString("D3") + "] = " + memory[address2].get(true);
                    }
                    pc++;
                    if (pc == 3)
                    {
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x3A:                                                        // X
                    if (debug)
                    {
                        debugLine += "A = " + regA.get(true) + " + " + regX.get(true) + " = ";
                    }
                    regA.add(regX);
                    if (regA.Overflow)
                    {
                        if (debug) debugLine += "overflowed ";
                        if (regSR[1] != 0x02) overflow = true;
                        else
                        {
                            stopReason = STOP_OVER;
                            running = false;
                        }
                    }
                    if (debug)
                    {
                        debugLine += regA.get(true);
                    }
                    break;

                case 0x3b:                                                        // Y
                    address = (address / 10);
                    address *= 10;
                    address2 = address + 9;
                    if (address2 >= 1000) address2 -= 1000;
                    changePhase = false;
                    address += (pc - 1);
                    if (address >= 1000) address -= 1000;
                    regY[pc-1].set(memory[address]);
                    if (debug && pc == 1) debugLine += "Y = [" + address.ToString() + "] thru [" + address2.ToString() + "]";
                    pc++;
                    if (pc == 11)
                    {
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                case 0x3c:                                                        // Z
                    address = (address / 10);
                    address *= 10;
                    address2 = address + 9;
                    if (address2 >= 1000) address2 -= 1000;
                    changePhase = false;
                    address += (pc - 1);
                    if (address >= 1000) address -= 1000;
                    memory[address].set(regY[pc-1]);
                    if (debug && pc == 1) debugLine += "[" + address.ToString() + "] thru [" + address2.ToString() + "] = Y";
                    pc++;
                    if (pc == 11)
                    {
                        pc = 1;
                        changePhase = true;
                    }
                    break;
                default:
                    errorFF[ERROR_FT_INTER] = true;
                    running = false;
                    res = false;
                    break;
            }
            return res;
        }

        public Boolean cycle()
        {
            int i;
            if (!running) return false;
            switch (phase)
            {
                case 1:
                    for (i = 0; i < 3; i++) regSR[i] = 0x03;
                    regSR[3] = regCC.Val[9];
                    regSR[4] = regCC.Val[10];
                    regSR[5] = regCC.Val[11];
                    phase = 2;
                    pc = 1;
                    if (iosSwitch == IOS_ONE_INST ||
                        iosSwitch == IOS_ONE_OPER) running = false;
                    break;
                case 2:
                    regCR.set(memory[regCC.toInt() % 1000]);
                    if (debug) debugLine = "[" + regCC.toInt().ToString("D3") + "] ";
                    regCC.decimalInc();
                    stallTimer = 3000;
                    phase = 3;
                    if (iosSwitch == IOS_ONE_INST ||
                        iosSwitch == IOS_ONE_OPER) running = false;
                    break;
                case 3:
                    overflow = false;
                    jump = -1;
                    for (i = 0; i < 6; i++) regSR[i] = regCR.Val[i];
                    changePhase = true;
                    exec();
                    if (changePhase)
                    {
                        phase = 4;
                        pc = 1;
                        if (iosSwitch == IOS_ONE_INST) running = false;
                    }
                    if (iosSwitch == IOS_ONE_OPER) running = false;
                    break;
                case 4:
                    if (debug & pc == 1) debugLine += "\r\n      ";
                    for (i = 0; i < 6; i++) regSR[i] = regCR.Val[i+6];
                    changePhase = true;
                    exec();
                    if (changePhase)
                    {
                        phase = (overflow) ? 5 : 1;
                        if (jump >= 0)
                        {
                            for (i = 9; i < 12; i++) regCC.Val[i] = regCR.Val[i];
                            jump = -1;
                        }
                        if (iosSwitch == IOS_ONE_INST) running = false;
                        pc = 1;
                    }
                    if (iosSwitch == IOS_ONE_OPER) running = false;
                    break;
                case 5:
                    for (i = 0; i < 6; i++) regSR[i] = 0x03;
                    phase = 6;
                    if (iosSwitch == IOS_ONE_INST ||
                        iosSwitch == IOS_ONE_OPER) running = false;
                    break;
                case 6:
                    regCR.set(memory[0]);
                    if (debug) debugLine = "      ";
                    phase = 3;
                    if (iosSwitch == IOS_ONE_INST ||
                        iosSwitch == IOS_ONE_OPER) running = false;
                    break;
            }
            if (stopFF) running = false;
            if (phase == 3 && pc == 1)
            {
                for (i = 0; i < 6; i++) regSR[i] = regCR.Val[i];
            }
            if (phase == 4 && pc == 1)
            {
                for (i = 0; i < 6; i++) regSR[i] = regCR.Val[i + 6];
            }
            return running;
        }

        public Boolean millisecondTimer()
        {
            if (stallTimer > 0) stallTimer-=10;
            if (stallTimer < 0) stallTimer = 0;
            return (stallTimer == 0) ? false : true;
        }
    }
}
