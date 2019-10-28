using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Univac
{
    public partial class MainForm : Form
    {
        private CPU cpu;

        public MainForm()
        {
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
            cpu = new CPU();
            tapeDriveSelect.SelectedIndex = 0;
            initialLoadSwitch.Image = images16x32.Images[1];
            stopSwitch.Image = images16x32.Images[1];
            clearIOSwitch.Image = images16x32.Images[1];
            clearCSwitch.Image = images16x32.Images[1];
            clearCYSwitch.Image = images16x32.Images[1];
            transferSwitch.Image = images16x32.Images[1];
            sciCrSwitch.Image = images16x32.Images[1];
            sciCrFillSwitch.Image = images16x32.Images[2];
            sw1.Image = images16x32.Images[1];
            sw2.Image = images16x32.Images[1];
            sw3.Image = images16x32.Images[1];
            sw4.Image = images16x32.Images[1];
            sw5.Image = images16x32.Images[1];
            sw6.Image = images16x32.Images[1];
            sw7.Image = images16x32.Images[1];
            sw8.Image = images16x32.Images[1];
            sw9.Image = images16x32.Images[1];
            sw10.Image = images16x32.Images[1];
            sw11.Image = images16x32.Images[1];
            sw12.Image = images16x32.Images[1];
            sw13.Image = images16x32.Images[1];
            sw14.Image = images16x32.Images[1];
            sw15.Image = images16x32.Images[1];
            sw16.Image = images16x32.Images[1];
            sw17.Image = images16x32.Images[1];
            sw18.Image = images16x32.Images[1];
            sw19.Image = images16x32.Images[1];
            sw20.Image = images16x32.Images[1];
            sw21.Image = images16x32.Images[1];
            sw22.Image = images16x32.Images[1];
            sw23.Image = images16x32.Images[1];
            sw24.Image = images16x32.Images[1];
            sw25.Image = images16x32.Images[1];
            sw26.Image = images16x32.Images[1];
            sw27.Image = images16x32.Images[1];
            sw28.Image = images16x32.Images[1];
            sw29.Image = images16x32.Images[1];
            sw30.Image = images16x32.Images[1];
            sw31.Image = images16x32.Images[1];
            sw32.Image = images16x32.Images[1];
            sw33.Image = images16x32.Images[1];
            sw34.Image = images16x32.Images[1];
            sw35.Image = images16x32.Images[1];
            errorLamp1.Image = images16x16.Images[0];
            errorLamp2.Image = images16x16.Images[0];
            errorLamp3.Image = images16x16.Images[0];
            errorLamp4.Image = images16x16.Images[0];
            errorLamp5.Image = images16x16.Images[0];
            errorLamp6.Image = images16x16.Images[0];
            errorLamp7.Image = images16x16.Images[0];
            errorLamp8.Image = images16x16.Images[0];
            errorLamp9.Image = images16x16.Images[0];
            errorLamp10.Image = images16x16.Images[0];
            errorLamp11.Image = images16x16.Images[0];
            errorLamp12.Image = images16x16.Images[0];
            errorLamp13.Image = images16x16.Images[0];
            errorLamp14.Image = images16x16.Images[0];
            errorLamp15.Image = images16x16.Images[0];
            errorLamp16.Image = images16x16.Images[0];
            errorLamp17.Image = images16x16.Images[0];
            errorLamp18.Image = images16x16.Images[0];
            errorLamp19.Image = images16x16.Images[0];
            errorLamp20.Image = images16x16.Images[0];
            errorLamp21.Image = images16x16.Images[0];
            errorLamp22.Image = images16x16.Images[0];
            errorLamp23.Image = images16x16.Images[0];
            errorLamp24.Image = images16x16.Images[0];
            errorLamp25.Image = images16x16.Images[0];
            errorLamp26.Image = images16x16.Images[0];
            errorLamp27.Image = images16x16.Images[0];
            errorLamp28.Image = images16x16.Images[0];
            errorLamp29.Image = images16x16.Images[0];
            errorLamp30.Image = images16x16.Images[0];
            errorLamp31.Image = images16x16.Images[0];
            errorLamp32.Image = images16x16.Images[0];
            errorLamp33.Image = images16x16.Images[0];
            stallLamp.Image = images16x16.Images[0];
            updateTapeButtons();
            updateConditionalButtons();
            updateOutputSelectorButtons();
            updateBlockSelectorButtons();
            stopLamp.Image = images16x16.Images[1];
            srPanel1.Image = images16x16.Images[0];
            srPanel2.Image = images16x16.Images[0];
            srPanel3.Image = images16x16.Images[0];
            srPanel4.Image = images16x16.Images[0];
            srPanel5.Image = images16x16.Images[0];
            srPanel6.Image = images16x16.Images[0];
            srPanel7.Image = images16x16.Images[0];
            srPanel8.Image = images16x16.Images[0];
            srPanel9.Image = images16x16.Images[0];
            srPanel10.Image = images16x16.Images[0];
            srPanel11.Image = images16x16.Images[0];
            srPanel12.Image = images16x16.Images[0];
            srGroup0.Image = images16x16.Images[0];
            srGroup1.Image = images16x16.Images[0];
            srGroup2.Image = images16x16.Images[0];
            srGroup3.Image = images16x16.Images[0];
            srWord1Bit0.Image = images16x16.Images[0];
            srWord1Bit1.Image = images16x16.Images[0];
            srWord1Bit2.Image = images16x16.Images[0];
            srWord1Bit3.Image = images16x16.Images[0];
            srWord1Bit4.Image = images16x16.Images[0];
            srWord1Bit5.Image = images16x16.Images[0];
            srWord2Bit0.Image = images16x16.Images[0];
            srWord2Bit1.Image = images16x16.Images[0];
            srWord2Bit2.Image = images16x16.Images[0];
            srWord2Bit3.Image = images16x16.Images[0];
            srWord2Bit4.Image = images16x16.Images[0];
            srWord2Bit5.Image = images16x16.Images[0];
            srWord4Bit0.Image = images16x16.Images[0];
            srWord4Bit1.Image = images16x16.Images[0];
            srWord4Bit2.Image = images16x16.Images[0];
            srWord4Bit3.Image = images16x16.Images[0];
            srWord4Bit4.Image = images16x16.Images[0];
            srWord4Bit5.Image = images16x16.Images[0];
            srWord5Bit0.Image = images16x16.Images[0];
            srWord5Bit1.Image = images16x16.Images[0];
            srWord5Bit2.Image = images16x16.Images[0];
            srWord5Bit3.Image = images16x16.Images[0];
            srWord5Bit4.Image = images16x16.Images[0];
            srWord5Bit5.Image = images16x16.Images[0];
            srWord6Bit0.Image = images16x16.Images[0];
            srWord6Bit1.Image = images16x16.Images[0];
            srWord6Bit2.Image = images16x16.Images[0];
            srWord6Bit3.Image = images16x16.Images[0];
            srWord6Bit4.Image = images16x16.Images[0];
            srWord6Bit5.Image = images16x16.Images[0];
            srSwitch11.Image = images16x32.Images[1];
            srSwitch12.Image = images16x32.Images[1];
            srSwitch13.Image = images16x32.Images[1];
            srSwitch14.Image = images16x32.Images[1];
            srSwitch15.Image = images16x32.Images[1];
            srSwitch16.Image = images16x32.Images[1];
            srSwitch21.Image = images16x32.Images[1];
            srSwitch22.Image = images16x32.Images[1];
            srSwitch23.Image = images16x32.Images[1];
            srSwitch24.Image = images16x32.Images[1];
            srSwitch25.Image = images16x32.Images[1];
            srSwitch26.Image = images16x32.Images[1];
            srSwitch41.Image = images16x32.Images[1];
            srSwitch42.Image = images16x32.Images[1];
            srSwitch43.Image = images16x32.Images[1];
            srSwitch44.Image = images16x32.Images[1];
            srSwitch45.Image = images16x32.Images[1];
            srSwitch46.Image = images16x32.Images[1];
            srSwitch51.Image = images16x32.Images[1];
            srSwitch52.Image = images16x32.Images[1];
            srSwitch53.Image = images16x32.Images[1];
            srSwitch54.Image = images16x32.Images[1];
            srSwitch55.Image = images16x32.Images[1];
            srSwitch56.Image = images16x32.Images[1];
            srSwitch61.Image = images16x32.Images[1];
            srSwitch62.Image = images16x32.Images[1];
            srSwitch63.Image = images16x32.Images[1];
            srSwitch64.Image = images16x32.Images[1];
            srSwitch65.Image = images16x32.Images[1];
            srSwitch66.Image = images16x32.Images[1];
            srZeroSwitch.Image = images16x32.Images[1];
            srZeroInstSwitch.Image = images16x32.Images[1];
            srZeroMemSwitch.Image = images16x32.Images[1];
            outputBreakpointSwitch.Image = images16x32.Images[1];
            breakpointSwitch.Image = images16x32.Images[1];
            clearPcSwitch.Image = images16x32.Images[1];
            cycle1.Image = images16x16.Images[0];
            cycle2.Image = images16x16.Images[0];
            pc1.Image = images16x16.Images[0];
            pc2.Image = images16x16.Images[0];
            pc3.Image = images16x16.Images[0];
            pc4.Image = images16x16.Images[0];
            mqCounter1.Image = images16x16.Images[0];
            mqCounter2.Image = images16x16.Images[0];
            mqCounter3.Image = images16x16.Images[0];
            mqCounter4.Image = images16x16.Images[0];
            ierLamp.Image = images16x16.Images[0];
            orLamp.Image = images16x16.Images[0];
            ierorLamp.Image = images16x16.Images[0];
            greater3Lamp.Image = images16x16.Images[0];
            repLamp.Image = images16x16.Images[0];
            toLamp.Image = images16x16.Images[0];
            tsLamp.Image = images16x16.Images[0];
            s1CpLamp.Image = images16x16.Images[0];
            s1XLamp.Image = images16x16.Images[0];
            conditionalTransferLamp.Image = images16x16.Images[0];
            inputSyncCounter1.Image = images16x16.Images[0];
            inputSyncCounter2.Image = images16x16.Images[0];
            inputSyncCounter3.Image = images16x16.Images[0];
            inputSyncCounter4.Image = images16x16.Images[0];
            outputSyncCounter1.Image = images16x16.Images[0];
            outputSyncCounter2.Image = images16x16.Images[0];
            outputSyncCounter3.Image = images16x16.Images[0];
            outputSyncCounter4.Image = images16x16.Images[0];
            inputTankCounter1.Image = images16x16.Images[0];
            inputTankCounter2.Image = images16x16.Images[0];
            inputTankCounter3.Image = images16x16.Images[0];
            outputTankCounter1.Image = images16x16.Images[0];
            outputTankCounter2.Image = images16x16.Images[0];
            outputTankCounter3.Image = images16x16.Images[0];
            syi1Lamp.Image = images16x16.Images[0];
            digitLamp.Image = images16x16.Images[0];
            syi2Lamp.Image = images16x16.Images[0];
            inputReadyLamp.Image = images16x16.Images[0];
            outputReadyLamp.Image = images16x16.Images[0];
            inputErrorLamp.Image = images16x16.Images[0];
            iosSwitch.Image = images32x32.Images[0];
            updatePanel();
        }

        private void updateBlockSelectorButtons()
        {
            int buttons;
            buttons = cpu.BlockSubdivisionSelector;
            blockSelector1.Image = ((buttons & 1) == 1) ? images24x24.Images[2] : images24x24.Images[3];
            blockSelector2.Image = ((buttons & 2) == 2) ? images24x24.Images[4] : images24x24.Images[5];
            blockSelector3.Image = ((buttons & 4) == 4) ? images24x24.Images[6] : images24x24.Images[7];
            blockSelector4.Image = ((buttons & 8) == 8) ? images24x24.Images[8] : images24x24.Images[9];
            blockSelector5.Image = ((buttons & 16) == 16) ? images24x24.Images[10] : images24x24.Images[11];
            blockSelector6.Image = ((buttons & 32) == 32) ? images24x24.Images[12] : images24x24.Images[13];
            blockSelector7.Image = ((buttons & 64) == 64) ? images24x24.Images[14] : images24x24.Images[15];
            blockSelector8.Image = ((buttons & 128) == 128) ? images24x24.Images[16] : images24x24.Images[17];
            blockSelector9.Image = ((buttons & 256) == 256) ? images24x24.Images[18] : images24x24.Images[19];
            blockSelectorDash.Image = ((buttons & 512) == 512) ? images24x24.Images[28] : images24x24.Images[29];
            blockSelectorNone.Image = images24x24.Images[41];
            blockLamp1.Image = ((buttons & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp2.Image = ((buttons & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp3.Image = ((buttons & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp4.Image = ((buttons & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp5.Image = ((buttons & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp6.Image = ((buttons & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp7.Image = ((buttons & 64) == 64) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp8.Image = ((buttons & 128) == 128) ? images16x16.Images[1] : images16x16.Images[0];
            blockLamp9.Image = ((buttons & 256) == 256) ? images16x16.Images[1] : images16x16.Images[0];
            blockLampDash.Image = ((buttons & 512) == 512) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void updateOutputSelectorButtons()
        {
            int buttons;
            buttons = cpu.OutputSelector;
            outputSelectorM.Image = (buttons == 1) ? images24x24.Images[36] : images24x24.Images[37];
            outputSelectorA.Image = (buttons == 2) ? images24x24.Images[22] : images24x24.Images[23];
            outputSelectorX.Image = (buttons == 3) ? images24x24.Images[42] : images24x24.Images[43];
            outputSelectorL.Image = (buttons == 4) ? images24x24.Images[34] : images24x24.Images[35];
            outputSelectorF.Image = (buttons == 5) ? images24x24.Images[32] : images24x24.Images[33];
            outputSelectorC.Image = (buttons == 6) ? images24x24.Images[24] : images24x24.Images[27];
            outputSelectorCR.Image = (buttons == 7) ? images24x24.Images[25] : images24x24.Images[26];
            outputSelectorSYI.Image = (buttons == 8) ? images24x24.Images[39] : images24x24.Images[40];
            outputSelectorEmpty.Image = (buttons == 9) ? images24x24.Images[30] : images24x24.Images[31];
        }

        private void updateTapeButtons()
        {
            int bootdrive;
            bootdrive = cpu.BootDrive;
            tapeButton1.Image = (bootdrive == 1) ? images24x24.Images[2] : images24x24.Images[3];
            tapeButton2.Image = (bootdrive == 2) ? images24x24.Images[4] : images24x24.Images[5];
            tapeButton3.Image = (bootdrive == 3) ? images24x24.Images[6] : images24x24.Images[7];
            tapeButton4.Image = (bootdrive == 4) ? images24x24.Images[8] : images24x24.Images[9];
            tapeButton5.Image = (bootdrive == 5) ? images24x24.Images[10] : images24x24.Images[11];
            tapeButton6.Image = (bootdrive == 6) ? images24x24.Images[12] : images24x24.Images[13];
            tapeButton7.Image = (bootdrive == 7) ? images24x24.Images[14] : images24x24.Images[15];
            tapeButton8.Image = (bootdrive == 8) ? images24x24.Images[16] : images24x24.Images[17];
            tapeButton9.Image = (bootdrive == 9) ? images24x24.Images[18] : images24x24.Images[19];
            tapeButton10.Image = (bootdrive == 10) ? images24x24.Images[28] : images24x24.Images[29];
        }

        private void updateConditionalButtons()
        {
            int breakpoints;
            breakpoints = cpu.ConditionalBreakpoints;
            conditionalSwitch0.Image = ((breakpoints & 1) == 1) ? images24x24.Images[0] : images24x24.Images[1];
            conditionalSwitch1.Image = ((breakpoints & 2) == 2) ? images24x24.Images[2] : images24x24.Images[3];
            conditionalSwitch2.Image = ((breakpoints & 4) == 4) ? images24x24.Images[4] : images24x24.Images[5];
            conditionalSwitch3.Image = ((breakpoints & 8) == 8) ? images24x24.Images[6] : images24x24.Images[7];
            conditionalSwitch4.Image = ((breakpoints & 16) == 16) ? images24x24.Images[8] : images24x24.Images[9];
            conditionalSwitch5.Image = ((breakpoints & 32) == 32) ? images24x24.Images[10] : images24x24.Images[11];
            conditionalSwitch6.Image = ((breakpoints & 64) == 64) ? images24x24.Images[12] : images24x24.Images[13];
            conditionalSwitch7.Image = ((breakpoints & 128) == 128) ? images24x24.Images[14] : images24x24.Images[15];
            conditionalSwitch8.Image = ((breakpoints & 256) == 256) ? images24x24.Images[16] : images24x24.Images[17];
            conditionalSwitch9.Image = ((breakpoints & 512) == 512) ? images24x24.Images[18] : images24x24.Images[19];
            conditionalSwitchAll.Image = images24x24.Images[21];
            conditionalSwitchNone.Image = images24x24.Images[41];
            breakpointLampAll.Image = (breakpoints == 1023) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp0.Image = ((breakpoints & 1 )== 1) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp1.Image = ((breakpoints & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp2.Image = ((breakpoints & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp3.Image = ((breakpoints & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp4.Image = ((breakpoints & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp5.Image = ((breakpoints & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp6.Image = ((breakpoints & 64) == 64) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp7.Image = ((breakpoints & 128) == 128) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp8.Image = ((breakpoints & 256) == 256) ? images16x16.Images[1] : images16x16.Images[0];
            breakpointLamp9.Image = ((breakpoints & 512) == 512) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void updateSR()
        {
            int[] sr;
            sr = cpu.RegSR;
            srPanel1.Image = ((sr[0] & 0xf) == 0x01) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel2.Image = ((sr[0] & 0xf) == 0x02) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel3.Image = ((sr[0] & 0xf) == 0x03) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel4.Image = ((sr[0] & 0xf) == 0x04) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel5.Image = ((sr[0] & 0xf) == 0x05) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel6.Image = ((sr[0] & 0xf) == 0x06) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel7.Image = ((sr[0] & 0xf) == 0x07) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel8.Image = ((sr[0] & 0xf) == 0x08) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel9.Image = ((sr[0] & 0xf) == 0x09) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel10.Image = ((sr[0] & 0xf) == 0x0a) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel11.Image = ((sr[0] & 0xf) == 0x0b) ? images16x16.Images[1] : images16x16.Images[0];
            srPanel12.Image = ((sr[0] & 0xf) == 0x0c) ? images16x16.Images[1] : images16x16.Images[0];
            srGroup0.Image = ((sr[0] & 0x30) == 0x00) ? images16x16.Images[1] : images16x16.Images[0];
            srGroup1.Image = ((sr[0] & 0x30) == 0x10) ? images16x16.Images[1] : images16x16.Images[0];
            srGroup2.Image = ((sr[0] & 0x30) == 0x20) ? images16x16.Images[1] : images16x16.Images[0];
            srGroup3.Image = ((sr[0] & 0x30) == 0x30) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit0.Image = ((sr[0] & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit1.Image = ((sr[0] & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit2.Image = ((sr[0] & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit3.Image = ((sr[0] & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit4.Image = ((sr[0] & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            srWord1Bit5.Image = ((sr[0] & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit0.Image = ((sr[1] & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit1.Image = ((sr[1] & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit2.Image = ((sr[1] & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit3.Image = ((sr[1] & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit4.Image = ((sr[1] & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            srWord2Bit5.Image = ((sr[1] & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit0.Image = ((sr[3] & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit1.Image = ((sr[3] & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit2.Image = ((sr[3] & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit3.Image = ((sr[3] & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit4.Image = ((sr[3] & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            srWord4Bit5.Image = ((sr[3] & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit0.Image = ((sr[4] & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit1.Image = ((sr[4] & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit2.Image = ((sr[4] & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit3.Image = ((sr[4] & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit4.Image = ((sr[4] & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            srWord5Bit5.Image = ((sr[4] & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit0.Image = ((sr[5] & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit1.Image = ((sr[5] & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit2.Image = ((sr[5] & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit3.Image = ((sr[5] & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit4.Image = ((sr[5] & 16) == 16) ? images16x16.Images[1] : images16x16.Images[0];
            srWord6Bit5.Image = ((sr[5] & 32) == 32) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond0.Image = ((sr[1] & 0xf) == 0x03) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond1.Image = ((sr[1] & 0xf) == 0x04) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond2.Image = ((sr[1] & 0xf) == 0x05) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond3.Image = ((sr[1] & 0xf) == 0x06) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond4.Image = ((sr[1] & 0xf) == 0x07) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond5.Image = ((sr[1] & 0xf) == 0x08) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond6.Image = ((sr[1] & 0xf) == 0x09) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond7.Image = ((sr[1] & 0xf) == 0x0a) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond8.Image = ((sr[1] & 0xf) == 0x0b) ? images16x16.Images[1] : images16x16.Images[0];
            srSecond9.Image = ((sr[1] & 0xf) == 0x0c) ? images16x16.Images[1] : images16x16.Images[0];
            srSecondDash.Image = ((sr[1] & 0xf) == 0x02) ? images16x16.Images[1] : images16x16.Images[0];
            overflowLamp.Image = (cpu.Overflow) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void updateCycleCounter()
        {
            int phase;
            phase = cpu.Phase - 1;
            cycle1.Image = ((phase & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            cycle2.Image = ((phase & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            phase = cpu.Pc - 1;
            pc1.Image = ((phase & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            pc2.Image = ((phase & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            pc3.Image = ((phase & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            pc4.Image = ((phase & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void updatePanel()
        {
            updateSR();
            updateCycleCounter();
            updateIOCounters();
        }

        private void updateMemoryPage()
        {
            int i;
            UnivacWord[] ram;
            ram = cpu.Memory;
            memoryGrid.Rows.Clear();
            for (i = 0; i < 1000; i++)
            {
                memoryGrid.Rows.Add();
                memoryGrid.Rows[i].Cells[0].Value = i.ToString();
                memoryGrid.Rows[i].Cells[1].Value = ram[i].get(true);
                memoryGrid.Rows[i].Cells[2].Value = ram[i].getAsBitmap();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == memoryPage) updateMemoryPage();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            stopLamp.Image = images16x16.Images[0];
            conditionalTransferLamp.Image = images16x16.Images[0];
            outputReadyLamp.Image = images16x16.Images[0];
            cpu.start();
        }

        private void print(String buffer)
        {
            int i;
            for (i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 'd') teleprinter.AppendText(" ");
                else if (buffer[i] == 'r') teleprinter.AppendText("\r\n");
                else if (buffer[i] == 't') teleprinter.AppendText("\t");
                else if (buffer[i] != 'i') teleprinter.AppendText(((char)buffer[i]).ToString());
            }
        }

        private void updateErrors()
        {
            errorLamp22.Image = (cpu.ErrorFF[CPU.ERROR_FT_INTER]) ? images16x16.Images[1] : images16x16.Images[0];
            errorLamp23.Image = (cpu.ErrorFF[CPU.ERROR_TANK_SEL_4]) ? images16x16.Images[1] : images16x16.Images[0];
            errorLamp24.Image = (cpu.ErrorFF[CPU.ERROR_TANK_SEL_5]) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void updateIOCounters()
        {
            int c;
            c = cpu.InputSyncCounter;
            inputSyncCounter1.Image = ((c & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            inputSyncCounter2.Image = ((c & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            inputSyncCounter3.Image = ((c & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            inputSyncCounter4.Image = ((c & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            c = cpu.InputTankCounter;
            inputTankCounter1.Image = ((c & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            inputTankCounter2.Image = ((c & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            inputTankCounter3.Image = ((c & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            c = cpu.OutputSyncCounter;
            outputSyncCounter1.Image = ((c & 8) == 8) ? images16x16.Images[1] : images16x16.Images[0];
            outputSyncCounter2.Image = ((c & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            outputSyncCounter3.Image = ((c & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            outputSyncCounter4.Image = ((c & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];
            c = cpu.OutputTankCounter;
            outputTankCounter1.Image = ((c & 4) == 4) ? images16x16.Images[1] : images16x16.Images[0];
            outputTankCounter2.Image = ((c & 2) == 2) ? images16x16.Images[1] : images16x16.Images[0];
            outputTankCounter3.Image = ((c & 1) == 1) ? images16x16.Images[1] : images16x16.Images[0];

        }

        private void mainClock_Tick(object sender, EventArgs e)
        {
            int i;
            String printer;
            mainClock.Enabled = false;
            if (cpu.millisecondTimer())
            {
                stallLamp.Image = images16x16.Images[0];
            }
            else
            {
                stallLamp.Image = images16x16.Images[1];
            }
            if (cpu.Running)
            {
                for (i = 0; i < 40; i++)
                {
                    cpu.cycle();
                    if (updatePanelWhileRunning.Checked)
                    {
                        updatePanel();
                        Application.DoEvents();
                    }
                    printer = cpu.getPrinter();
                    if (printer != null && printer.Length > 0) print(printer);
                    if (enableDebug.Checked && (cpu.Phase == 1 || cpu.Phase == 5 || cpu.Running == false)) debugOutput.AppendText(cpu.DebugLine + "\r\n");
                    if (cpu.StopReason == CPU.STOP_KBD)
                    {
                        enterButton.Enabled = true;
                        inputReadyLamp.Image = images16x16.Images[1];
                    }
                    if (cpu.StopReason == CPU.STOP_OVER) debugOutput.AppendText("Machine stopped on overflow\r\n");
                    if (cpu.StopReason == CPU.STOP_HALT) debugOutput.AppendText("Machine stopped on 9 instruction\r\n");
                    if (cpu.StopReason == CPU.STOP_ADD_ALPHA)
                    {
                        debugOutput.AppendText("Machine stopped on alpha addition\r\n");
                        errorLamp9.Image = images16x16.Images[1];
                    }
                    if (cpu.StopReason == CPU.STOP_COND_BREAK)
                    {
                        debugOutput.AppendText("Machine stopped on conditional breakpoint\r\n");
                        conditionalTransferLamp.Image = (cpu.Jump >= 0) ? images16x16.Images[1] : images16x16.Images[0];
                    }
                    if (cpu.StopReason == CPU.STOP_DISP_BREAK)
                    {
                        debugOutput.AppendText("Machine stopped on display breakpoint\r\n");
                        outputReadyLamp.Image = images16x16.Images[1];
                    }
                    if (cpu.Running == false)
                    {
                        stopLamp.Image = images16x16.Images[1];
                        updatePanel();
                        updateErrors();
                        i = 99999;
                    }
                }
            }
            mainClock.Enabled = true;
        }

        private void enableDebug_CheckedChanged(object sender, EventArgs e)
        {
            cpu.Debug = enableDebug.Checked;
        }

        private void clearDebugButton_Click(object sender, EventArgs e)
        {
            debugOutput.Clear();
        }

        private void tapeMountButton_Click(object sender, EventArgs e)
        {
            List<String> tape;
            int i;
            int pos;
            String num;
            pos = 0;
            tape = new List<String>();
            for (i = 0; i < tapeInput.Lines.Count(); i++)
            {
                if (((String)tapeInput.Lines[i]).Length > 0 && ((String)tapeInput.Lines[i])[0] == '<')
                {
                    num = ((String)tapeInput.Lines[i]).Substring(1);
                    if (num.IndexOf('>') >= 0)
                    {
                        num = num.Substring(0, num.IndexOf('>'));
                        pos = Convert.ToInt32(num);
                    }
                }
                while ((pos+1) > tape.Count) tape.Add("");
                tape[pos] = tapeInput.Lines[i];
                pos++;
            }
            cpu.mountTape(tapeDriveSelect.SelectedIndex, tape);
        }

        private void tapeRetrieveButton_Click(object sender, EventArgs e)
        {
            List<String> tape;
            int i;
            tape = cpu.retrieveTape(tapeDriveSelect.SelectedIndex);
            tapeInput.Clear();
            for (i = 0; i < tape.Count; i++) tapeInput.AppendText(tape[i] + "\r\n");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int i;
            StreamWriter file;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = new StreamWriter(saveFileDialog.FileName);
                if (file != null)
                {
                    for (i = 0; i < tapeInput.Lines.Count(); i++)
                        file.WriteLine(tapeInput.Lines[i]);
                    file.Close();
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            String buffer;
            StreamReader file;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = new StreamReader(openFileDialog.FileName);
                if (file != null)
                {
                    tapeInput.Clear();
                    while (!file.EndOfStream)
                    {
                        buffer = file.ReadLine();
                        tapeInput.AppendText(buffer+"\r\n");
                    }
                    file.Close();
                }
            }
        }

        private void bootButton_Click(object sender, EventArgs e)
        {
            cpu.boot();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (teletype.Text.Length < 12)
            {
                inputErrorLamp.Image = images16x16.Images[1];
            }
            else
            {
                enterButton.Enabled = false;
                inputReadyLamp.Image = images16x16.Images[0];
                digitLamp.Image = images16x16.Images[0];
                cpu.keyboardInput(teletype.Text);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            tapeInput.Clear();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            cpu.reset();
        }

        private void rewindButton_Click(object sender, EventArgs e)
        {
            cpu.rewind(tapeDriveSelect.SelectedIndex);
        }

        private void rewindAllButton_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 10; i++) cpu.rewind(i);
        }

        private void tapeButton_Click(object sender, EventArgs e)
        {
            int tag;
            tag = Convert.ToInt32(((PictureBox)sender).Tag);
            cpu.BootDrive = tag;
            updateTapeButtons();
        }

        private void srSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int[] sr;
            int tag;
            int wrd;
            int pos;
            tag = Convert.ToInt32(((PictureBox)sender).Tag);
            wrd = (tag / 10) - 1;
            pos = tag % 10;
            pos = 1 << (pos - 1);
            sr = cpu.RegSR;
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Image = images16x32.Images[2];
                sr[wrd] |= pos;
            }
            else
            {
                ((PictureBox)sender).Image = images16x32.Images[0];
                sr[wrd] &= ((pos ^ 0x3f) & 0x3f);
            }
            updateSR();
        }

        private void srSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = images16x32.Images[1];
        }

        private void srZeroSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            int[] sr;
            sr = cpu.RegSR;
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Image = images16x32.Images[2];
                for (i = 0; i < 6; i++) sr[i] = 0x0;
            }
            else
            {
                ((PictureBox)sender).Image = images16x32.Images[0];
                for (i = 0; i < 6; i++) sr[i] = 0x03;
            }
            updateSR();
        }

        private void srZeroInstSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            int[] sr;
            sr = cpu.RegSR;
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Image = images16x32.Images[2];
                for (i = 0; i < 2; i++) sr[i] = 0x0;
            }
            else
            {
                ((PictureBox)sender).Image = images16x32.Images[0];
                for (i = 0; i < 2; i++) sr[i] = 0x03;
            }
            updateSR();
        }

        private void srZeroMemSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            int[] sr;
            sr = cpu.RegSR;
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Image = images16x32.Images[2];
                for (i = 3; i < 6; i++) sr[i] = 0x0;
            }
            else
            {
                ((PictureBox)sender).Image = images16x32.Images[0];
                for (i = 3; i < 6; i++) sr[i] = 0x03;
            }
            updateSR();
        }

        private void outputBreakpointSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int pos;
            pos = cpu.OutputBreakpoint;
            if (e.Button == MouseButtons.Left)
            {
                if (++pos > 2) pos = 2;
            }
            else
            {
                if (--pos < 0) pos = 0;
            }
            cpu.OutputBreakpoint = pos;
            switch (pos)
            {
                case 0: outputBreakpointSwitch.Image = images16x32.Images[0]; break;
                case 1: outputBreakpointSwitch.Image = images16x32.Images[1]; break;
                case 2: outputBreakpointSwitch.Image = images16x32.Images[2]; break;
            }
        }

        private void breakpointSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cpu.Breakpoint = true;
            }
            else
            {
                cpu.Breakpoint = false;
            }
            breakpointSwitch.Image = (cpu.Breakpoint) ? images16x32.Images[2] : images16x32.Images[1];
        }

        private void neutralSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            String tag;
            tag = (String)((PictureBox)sender).Tag;
            if (e.Button == MouseButtons.Left) ((PictureBox)sender).Image = images16x32.Images[2];
            if (e.Button == MouseButtons.Right) ((PictureBox)sender).Image = images16x32.Images[0];
            if (tag.CompareTo("InitialRead") == 0) cpu.boot();
            if (tag.CompareTo("Stop") == 0) cpu.stop();
            if (tag.CompareTo("ClearC") == 0) cpu.clearC();
            if (tag.CompareTo("ClearCY") == 0) cpu.clearCy();
            if (tag.CompareTo("ClearPC") == 0) cpu.clearPc();
            if (tag.CompareTo("ClearIO") == 0) cpu.clearIAndO();
            if (tag.CompareTo("AdderAlpha") == 0) errorLamp9.Image = images16x16.Images[0];
            if (tag.CompareTo("TankSel") == 0)
            {
                cpu.clearError(CPU.ERROR_TANK_SEL_4);
                cpu.clearError(CPU.ERROR_TANK_SEL_5);
                updateErrors();
            }
            if (tag.CompareTo("FtInter") == 0)
            {
                cpu.clearError(CPU.ERROR_FT_INTER);
                updateErrors();
            }
            updatePanel();
        }

        private void neutralSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = images16x32.Images[1];
        }

        private void conditionalSwitch_Click(object sender, EventArgs e)
        {
            int tag;
            int breakpoints;
            breakpoints = cpu.ConditionalBreakpoints;
            tag = Convert.ToInt32(((PictureBox)sender).Tag);
            if (tag == -1) breakpoints = 1023;
            else if (tag == -2) breakpoints = 0;
            else if ((breakpoints & tag) == tag)
            {
                breakpoints &= ((~tag) & 0x3ff);
            }
            else
            {
                breakpoints += tag;
            }
            cpu.ConditionalBreakpoints = breakpoints;
            updateConditionalButtons();
        }

        private void transferSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int pos;
            pos = cpu.TransferMode;
            if (e.Button == MouseButtons.Left)
            {
                if (++pos > 2) pos = 2;
            }
            else
            {
                if (--pos < 0) pos = 0;
            }
            cpu.TransferMode = pos;
            switch (pos)
            {
                case 0: transferSwitch.Image = images16x32.Images[0]; cpu.TransferNoTransfer = 1;  break;
                case 1: transferSwitch.Image = images16x32.Images[1]; cpu.TransferNoTransfer = 0;  break;
                case 2: transferSwitch.Image = images16x32.Images[2]; cpu.TransferNoTransfer = -1;  break;
            }
        }

        private void outputSelectorSwitch_Click(object sender, EventArgs e)
        {
            int tag;
            int output;
            output = cpu.OutputSelector;
            tag = Convert.ToInt32(((PictureBox)sender).Tag);
            output = tag;
            cpu.OutputSelector = output;
            updateOutputSelectorButtons();
        }

        private void blockSelectorSwitch_Click(object sender, EventArgs e)
        {
            int tag;
            int blocks;
            blocks = cpu.BlockSubdivisionSelector;
            tag = Convert.ToInt32(((PictureBox)sender).Tag);
            if (tag == -1) blocks = 0;
            else if ((blocks & tag) == tag)
            {
                blocks &= ((~tag) & 0x3ff);
            }
            else
            {
                blocks += tag;
            }
            cpu.BlockSubdivisionSelector = blocks;
            updateBlockSelectorButtons();
        }

        private void sciCrFillSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            Boolean fill;
            fill = cpu.SciCrFill;
            if (e.Button == MouseButtons.Right) fill = true; else fill = false;
            cpu.SciCrFill = fill;
            sciCrFillSwitch.Image = (fill) ? images16x32.Images[0] : images16x32.Images[2];
        }

        private void teletype_TextChanged(object sender, EventArgs e)
        {
            inputErrorLamp.Image = images16x16.Images[0];
            digitLamp.Image = (teletype.Text.Length == 12) ? images16x16.Images[1] : images16x16.Images[0];
        }

        private void iosSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            int x;
            int y;
            int zone;
            zone = -1;
            x = e.Location.X;
            y = e.Location.Y;
            if (x >= 8 && x < 24 && y >= 8 && y < 24) zone = CPU.IOS_NORMAL;
            if (y < 8 && x >= 8 && x < 24) zone = zone = CPU.IOS_ONE_OPER;
            if (y >= 24 && x >= 8 && x < 24) zone = zone = CPU.IOS_ONE_INST;
            if (x < 8 && y >= 8 && y < 24) zone = zone = CPU.IOS_ONE_STEP;
            if (x >= 24 && y >= 8 && y < 24) zone = zone = CPU.IOS_ONE_ADTN;
            if (zone >= 0)
            {
                cpu.IosSwitch = zone;
                switch (cpu.IosSwitch)
                {
                    case CPU.IOS_NORMAL:
                        iosSwitch.Image = images32x32.Images[0];
                        break;
                    case CPU.IOS_ONE_OPER:
                        iosSwitch.Image = images32x32.Images[1];
                        break;
                    case CPU.IOS_ONE_INST:
                        iosSwitch.Image = images32x32.Images[2];
                        break;
                    case CPU.IOS_ONE_STEP:
                        iosSwitch.Image = images32x32.Images[3];
                        break;
                    case CPU.IOS_ONE_ADTN:
                        iosSwitch.Image = images32x32.Images[4];
                        break;
                }
            }
        }

        private void clearTeleprinterButton_Click(object sender, EventArgs e)
        {
            teleprinter.Clear();
        }


    }
}
