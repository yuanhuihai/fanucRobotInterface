using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FRRJIf;
using FRRobotIFLib;

namespace fanucRobotInterfaceComm
{
    public class robotInterfaceComm
    {

        private FRRJIf.Core mobjCore;
        private FRRJIf.DataTable mobjDataTable;
        private FRRJIf.DataTable mobjDataTable2;
        private FRRJIf.DataCurPos mobjCurPos;
        private FRRJIf.DataCurPos mobjCurPosUF;
        private FRRJIf.DataCurPos mobjCurPos2;
        private FRRJIf.DataTask mobjTask;
        private FRRJIf.DataTask mobjTaskIgnoreMacro;
        private FRRJIf.DataTask mobjTaskIgnoreKarel;
        private FRRJIf.DataTask mobjTaskIgnoreMacroKarel;
        private FRRJIf.DataPosReg mobjPosReg;
        private FRRJIf.DataPosReg mobjPosReg2;
        private FRRJIf.DataPosRegXyzwpr mobjPosRegXyzwpr;
        private FRRJIf.DataPosRegMG mobjPosRegMG;
        private FRRJIf.DataSysVar mobjSysVarInt;
        private FRRJIf.DataSysVar mobjSysVarInt2;
        private FRRJIf.DataSysVar mobjSysVarReal;
        private FRRJIf.DataSysVar mobjSysVarReal2;
        private FRRJIf.DataSysVar mobjSysVarString;
        private FRRJIf.DataSysVarPos mobjSysVarPos;
        private FRRJIf.DataSysVar[] mobjSysVarIntArray;
        private FRRJIf.DataNumReg mobjNumReg;
        private FRRJIf.DataNumReg mobjNumReg2;
        private FRRJIf.DataNumReg mobjNumReg3;
        private FRRJIf.DataAlarm mobjAlarm;
        private FRRJIf.DataAlarm mobjAlarmCurrent;
        private FRRJIf.DataSysVar mobjVarString;
        private FRRJIf.DataString mobjStrReg;
        private FRRJIf.DataString mobjStrRegComment;



        private void msubInit(string strHost)
        {



            mobjCore = new FRRJIf.Core();

            // You need to set data table before connecting.
            mobjDataTable = mobjCore.DataTable;

            {
                mobjAlarm = mobjDataTable.AddAlarm(FRRJIf.FRIF_DATA_TYPE.ALARM_LIST, 5, 0);
                mobjAlarmCurrent = mobjDataTable.AddAlarm(FRRJIf.FRIF_DATA_TYPE.ALARM_CURRENT, 1, 0);
                mobjCurPos = mobjDataTable.AddCurPos(FRRJIf.FRIF_DATA_TYPE.CURPOS, 1);
                mobjCurPosUF = mobjDataTable.AddCurPosUF(FRRJIf.FRIF_DATA_TYPE.CURPOS, 1, 15);
                mobjCurPos2 = mobjDataTable.AddCurPos(FRRJIf.FRIF_DATA_TYPE.CURPOS, 2);
                mobjTask = mobjDataTable.AddTask(FRRJIf.FRIF_DATA_TYPE.TASK, 1);
                mobjTaskIgnoreMacro = mobjDataTable.AddTask(FRRJIf.FRIF_DATA_TYPE.TASK_IGNORE_MACRO, 1);
                mobjTaskIgnoreKarel = mobjDataTable.AddTask(FRRJIf.FRIF_DATA_TYPE.TASK_IGNORE_KAREL, 1);
                mobjTaskIgnoreMacroKarel = mobjDataTable.AddTask(FRRJIf.FRIF_DATA_TYPE.TASK_IGNORE_MACRO_KAREL, 1);
                mobjPosReg = mobjDataTable.AddPosReg(FRRJIf.FRIF_DATA_TYPE.POSREG, 1, 1, 10);
                mobjPosReg2 = mobjDataTable.AddPosReg(FRRJIf.FRIF_DATA_TYPE.POSREG, 2, 1, 4);
                mobjSysVarInt = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$FAST_CLOCK");
                mobjSysVarInt2 = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[10].$TIMER_VAL");
                mobjSysVarReal = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_REAL, "$MOR_GRP[1].$CURRENT_ANG[1]");
                mobjSysVarReal2 = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_REAL, "$DUTY_TEMP");
                mobjSysVarString = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_STRING, "$TIMER[10].$COMMENT");
                mobjSysVarPos = mobjDataTable.AddSysVarPos(FRRJIf.FRIF_DATA_TYPE.SYSVAR_POS, "$MNUTOOL[1,1]");
                mobjVarString = mobjDataTable.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_STRING, "$[HTTPKCL]CMDS[1]");
                mobjNumReg = mobjDataTable.AddNumReg(FRRJIf.FRIF_DATA_TYPE.NUMREG_INT, 1, 5);
                mobjNumReg2 = mobjDataTable.AddNumReg(FRRJIf.FRIF_DATA_TYPE.NUMREG_REAL, 6, 10);
                mobjPosRegXyzwpr = mobjDataTable.AddPosRegXyzwpr(FRRJIf.FRIF_DATA_TYPE.POSREG_XYZWPR, 1, 1, 10);
                mobjPosRegMG = mobjDataTable.AddPosRegMG(FRRJIf.FRIF_DATA_TYPE.POSREGMG, "C,J6", 1, 10);
                mobjStrReg = mobjDataTable.AddString(FRRJIf.FRIF_DATA_TYPE.STRREG, 1, 3);
                mobjStrRegComment = mobjDataTable.AddString(FRRJIf.FRIF_DATA_TYPE.STRREG_COMMENT, 1, 3);

            }

            // 2nd data table.
            // You must not set the first data table.
            mobjDataTable2 = mobjCore.DataTable2;
            mobjNumReg3 = mobjDataTable2.AddNumReg(FRRJIf.FRIF_DATA_TYPE.NUMREG_INT, 1, 5);
            mobjSysVarIntArray = new FRRJIf.DataSysVar[10];
            mobjSysVarIntArray[0] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[1].$TIMER_VAL");
            mobjSysVarIntArray[1] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[2].$TIMER_VAL");
            mobjSysVarIntArray[2] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[3].$TIMER_VAL");
            mobjSysVarIntArray[3] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[4].$TIMER_VAL");
            mobjSysVarIntArray[4] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[5].$TIMER_VAL");
            mobjSysVarIntArray[5] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[6].$TIMER_VAL");
            mobjSysVarIntArray[6] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[7].$TIMER_VAL");
            mobjSysVarIntArray[7] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[8].$TIMER_VAL");
            mobjSysVarIntArray[8] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[9].$TIMER_VAL");
            mobjSysVarIntArray[9] = mobjDataTable2.AddSysVar(FRRJIf.FRIF_DATA_TYPE.SYSVAR_INT, "$TIMER[10].$TIMER_VAL");




            mobjCore.Connect(strHost);

        }


        private void msubDisconnected()
        {



            msubClearVars();



        }


        private void msubClearVars()
        {

            mobjCore.Disconnect();

            mobjCore = null;
            mobjDataTable = null;
            mobjDataTable2 = null;
            mobjAlarm = null;
            mobjAlarmCurrent = null;
            mobjCurPos = null;
            mobjCurPos2 = null;
            mobjTask = null;
            mobjTaskIgnoreMacro = null;
            mobjTaskIgnoreKarel = null;
            mobjTaskIgnoreMacroKarel = null;
            mobjPosReg = null;
            mobjPosReg2 = null;
            mobjSysVarInt = null;
            mobjSysVarReal = null;
            mobjSysVarReal2 = null;
            mobjSysVarString = null;
            mobjSysVarPos = null;
            mobjNumReg = null;
            mobjNumReg2 = null;
            mobjNumReg3 = null;
            mobjVarString = null;
            mobjStrReg = null;
            mobjStrRegComment = null;
            for (int ii = mobjSysVarIntArray.GetLowerBound(0); ii <= mobjSysVarIntArray.GetUpperBound(0); ii++)
            {
                mobjSysVarIntArray[ii] = null;
            }

        }

        private string mstrIO(string strIOType, short StartIndex, short EndIndex, ref Array values)
        {
            string tmp = null;
            int ii = 0;

            tmp = strIOType + "[" + Convert.ToString(StartIndex) + "-" + Convert.ToString(EndIndex) + "]=";
            for (ii = 0; ii <= EndIndex - StartIndex; ii++)
            {
                if ((short)values.GetValue(ii) == 0)
                {
                    tmp = tmp + "0";
                }
                else
                {
                    tmp = tmp + "1";
                }
            }

            return tmp;
        }

        private string mstrIO2(string strIOType, short StartIndex, short EndIndex, ref Array values)
        {
            string tmp = null;
            int ii = 0;

            tmp = strIOType + "[" + Convert.ToString(StartIndex) + "-" + Convert.ToString(EndIndex) + "]=";
            for (ii = 0; ii <= EndIndex - StartIndex; ii++)
            {
                if (ii != 0)
                {
                    tmp = tmp + ",";
                }
                tmp = tmp + values.GetValue(ii);
            }

            return tmp;
        }

    
        #region mstrAlarm
        private string mstrAlarm(ref FRRJIf.DataAlarm objAlarm, int Count)
        {
            string tmp = null;
            short intID = 0;
            short intNumber = 0;
            short intCID = 0;
            short intCNumber = 0;
            short intSeverity = 0;
            short intY = 0;
            short intM = 0;
            short intD = 0;
            short intH = 0;
            short intMn = 0;
            short intS = 0;
            string strM1 = "";
            string strM2 = "";
            string strM3 = "";
            bool blnRes = false;

            blnRes = objAlarm.GetValue(Count, ref intID, ref intNumber, ref intCID, ref intCNumber, ref intSeverity, ref intY, ref intM, ref intD, ref intH,
            ref intMn, ref intS, ref strM1, ref strM2, ref strM3);
            tmp = "-- Alarm " + Count + " --\r\n";
            if (blnRes == false)
            {
                tmp = tmp + "Error\r\n";
                return tmp;
            }
            
            tmp = tmp + intY + "/" + intM + "/" + intD + ", " + intH + ":" + intMn + ":" + intS + "\r\n";
            if (!string.IsNullOrEmpty(strM1))
                tmp = tmp + strM1 + "\r\n";
            if (!string.IsNullOrEmpty(strM2))
                tmp = tmp + strM2 + "\r\n";
            if (!string.IsNullOrEmpty(strM3))
                tmp = tmp + strM3 + "\r\n";

            return tmp;
        }
        #endregion

        public  string[] xyzwpr(string ip)
        {

            msubInit(ip);


            string[] strTmp=new string[9];


            Array xyzwpr = new float[9];
            Array config = new short[7];
            Array joint = new float[9];
            short intUF = 0;
            short intUT = 0;
            short intValidC = 0;
            short intValidJ = 0;





            mobjDataTable.Refresh();

            {
                mobjCurPos2.GetValue(ref xyzwpr, ref config, ref joint, ref intUF, ref intUT, ref intValidC, ref intValidJ);


                for (int ii = 0; ii <= 8; ii++)
                {
                    strTmp[ii] = xyzwpr.GetValue(ii).ToString() ;
                }


            }


            msubDisconnected();

            return strTmp;


        }
        public string[] joint(string ip)
        {

            msubInit(ip);


            string[] strTmp = new string[9];


            Array xyzwpr = new float[9];
            Array config = new short[7];
            Array joint = new float[9];
            short intUF = 0;
            short intUT = 0;
            short intValidC = 0;
            short intValidJ = 0;





            mobjDataTable.Refresh();

            {
                mobjCurPos2.GetValue(ref xyzwpr, ref config, ref joint, ref intUF, ref intUT, ref intValidC, ref intValidJ);


                for (int ii = 0; ii <= 8; ii++)
                {
                    strTmp[ii] = joint.GetValue(ii).ToString();
                }


            }


            msubDisconnected();

            return strTmp;


        }


        public string readcurrAlarm(string ip)
        {

            msubInit(ip);


            string strTmp = null;
          
           mobjDataTable.Refresh(); 

            for (int ii = 1; ii <= 1; ii++)
            {
                strTmp = strTmp + mstrAlarm(ref mobjAlarmCurrent, ii);
            }


            return strTmp;


        }


        public string readhisAlarm(string ip)
        {

            msubInit(ip);


            string strTmp = null;
     
           mobjDataTable.Refresh();

            for (int ii = 1; ii <= 5; ii++)
            {
                strTmp = strTmp + mstrAlarm(ref mobjAlarm, ii);
            }


            return strTmp;


        }

    }
}
